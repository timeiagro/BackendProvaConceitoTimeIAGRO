using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebLivros.Models;

namespace WebLivro.repository;

public class BookModelRepository : IBookModelRepository
{
        private readonly string _fileUrl = "https://raw.githubusercontent.com/timeiagro/BackendProvaConceitoTimeIAGRO/main/books.json";
        private readonly HttpClient _httpClient;

        
        public BookModelRepository(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<ServiceReponse<BookModel>> GetServiceReponseBooks()
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

        private List<BookModel> DeserializarJson()
        {
            StreamReader r = new StreamReader("books.json");
            string jsonString = r.ReadToEnd();

            List<BookModel> bookModels = new List<BookModel>();
            
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonString);;
            
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
                bookModels.Add(book);

            }

            return bookModels;

        }

        public List<BookModel> GetBookModels()
        {
            return DeserializarJson();
        }
        
        public List<BookModel> GetByIllustrator(string illustrator)
        {
            List<BookModel> result = GetBookModels();
            return result.Where(x=>x.Specifications.Illustrator.Any(a=>a.ToLower().Contains(illustrator.ToLower()))).ToList();
        }

        public List<BookModel> GetByName(string name)
        {
            List<BookModel> result = GetBookModels();
            List<BookModel> query = result.Where(res => res.Name.ToLower().Contains(name.ToLower())).ToList();
            return query;
        }
        public List<BookModel> GetByAuthor(string author)
        {
            List<BookModel> result = GetBookModels();
            return result.Where(book=> book.Specifications.Author.Contains(author)).ToList();
        }
        
        public List<BookModel> GetByGenres(string genres)
        {
            List<BookModel> result = GetBookModels();
            return result.Where(x=>x.Specifications.Genres.Any(a=>a.ToLower().Contains(genres.ToLower()))).ToList();
        }

        public BookModel GetById(int id)
        {
            List<BookModel> result = GetBookModels();
            return result.Where(x=>x.Id == id).FirstOrDefault();
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