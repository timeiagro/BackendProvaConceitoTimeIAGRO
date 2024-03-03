
using BackendProvaConceitoTimeIAGRO.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Diagnostics;

namespace BackendProvaConceitoTimeIAGRO.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly string _fileUrl = "https://raw.githubusercontent.com/timeiagro/BackendProvaConceitoTimeIAGRO/main/books.json";
        private readonly HttpClient _httpClient;

        public BookRepository(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<ServiceReponse<BookModel>> GetBooks()
        {
            ServiceReponse<BookModel> booksResponse = new ServiceReponse<BookModel>();
            try
            {
                HttpResponseMessage httpResponse = await _httpClient.GetAsync(_fileUrl);
                httpResponse.EnsureSuccessStatusCode();

                string jsonString = await httpResponse.Content.ReadAsStringAsync();
                Trace.WriteLine(jsonString);

                dynamic jsonObject = JsonConvert.DeserializeObject(jsonString);

                foreach (var item in jsonObject)
                {

                    BookModel book = new BookModel
                    {
                        Id = item.id,
                        Name = item.name,
                        Price = item.price,
                        Specifications = new SpecificationsModel
                        {
                            Published = item.specifications["Originally published"],
                            Author = item.specifications["Author"],
                            Pages = item.specifications["Page count"],
                            Illustrator = ConvertToSingleOrList<string>(item.specifications["Illustrator"]),
                            Genres = ConvertToSingleOrList<string>(item.specifications["Genres"])
                        }
                    };

                    booksResponse.Dados.Add(book);
                }



                if (booksResponse.Dados == null || booksResponse.Dados.Count == 0)
                {
                    booksResponse.Mensagem = "Nenhum dado encontrado";
                    booksResponse.Sucesso = false;
                }
                else
                {
                    booksResponse.Sucesso = true;
                }
            }
            catch (Exception ex)
            {
                booksResponse.Mensagem = ex.Message;
                booksResponse.Sucesso = false;
            }



            return booksResponse;

        }
        private List<T> ConvertToSingleOrList<T>(dynamic value)
        {
            List<T> result = new List<T>();

            if (value is JArray)
            {
                JArray array = (JArray)value;
                foreach (var item in array)
                {
                    result.Add(item.ToObject<T>());
                }
            }
            else
            {
                result.Add((T)value);
            }

            return result;
        }
    }
}
