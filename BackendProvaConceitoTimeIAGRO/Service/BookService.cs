using BackendProvaConceitoTimeIAGRO.Enums;
using BackendProvaConceitoTimeIAGRO.Models;
using BackendProvaConceitoTimeIAGRO.Repository;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackendProvaConceitoTimeIAGRO.Service
{
    public class BookService : IBookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = (BookRepository?)bookRepository;
        }     

        public async Task<ServiceReponse<BookModel>> GetBooks(AscDescEnum ordem)
        {
            ServiceReponse<BookModel> booksResponse = new();
            try
            {
                booksResponse = await _bookRepository.GetBooks();
            }catch (Exception ex)
            {
                booksResponse.Mensagem = ex.Message;
                booksResponse.Sucesso = false;
            }
            booksResponse.Dados = ordem == AscDescEnum.Asc ? booksResponse.Dados.OrderBy(book => book.Price).ToList() : booksResponse.Dados.OrderByDescending(book => book.Price).ToList();

            return booksResponse;
        }
        public async Task<ServiceReponse<BookModel>> GetByAuthor(AscDescEnum ordem, string author)
        {
            ServiceReponse<BookModel> booksResponse = new();
            try
            {
                booksResponse = await GetBooks(ordem);
                booksResponse.Dados = booksResponse.Dados.Where(book => book.Specifications.Author.ToLower().Equals(author)).ToList();
                if (booksResponse.Dados == null || booksResponse.Dados.Count == 0)
                {
                    booksResponse.Mensagem = "Nenhum dado encontrado";
                    booksResponse.Sucesso = false;
                }

            }
            catch (Exception ex)
            {
                booksResponse.Mensagem = ex.Message;
                booksResponse.Sucesso = false;
            }
            return booksResponse;
        }
        public async Task<ServiceReponse<BookModel>> GetByName(AscDescEnum ordem, string name)
        {
            ServiceReponse<BookModel> booksResponse = new();
            try
            {
                booksResponse = await GetBooks(ordem);
                booksResponse.Dados = booksResponse.Dados.Where(book => book.Name.ToLower().Equals(name)).ToList();
                if (booksResponse.Dados == null || booksResponse.Dados.Count == 0)
                {
                    booksResponse.Mensagem = "Nenhum dado encontrado";
                    booksResponse.Sucesso = false;
                }

            }
            catch (Exception ex)
            {
                booksResponse.Mensagem = ex.Message;
                booksResponse.Sucesso = false;
            }
            return booksResponse;
        }
        public async Task<ServiceReponse<BookModel>> GetByPrice(AscDescEnum ordem, double price)
        {
            ServiceReponse<BookModel> booksResponse = new();
            try
            {
                booksResponse = await GetBooks(ordem);
                booksResponse.Dados = booksResponse.Dados.Where(book => book.Price.Equals(price)).ToList();
                if (booksResponse.Dados == null || booksResponse.Dados.Count == 0)
                {
                    booksResponse.Mensagem = "Nenhum dado encontrado";
                    booksResponse.Sucesso = false;
                }

            }
            catch (Exception ex)
            {
                booksResponse.Mensagem = ex.Message;
                booksResponse.Sucesso = false;
            }
            return booksResponse;
        }
        public async Task<ServiceReponse<BookModel>> GetByPublished(AscDescEnum ordem, string published)
        {
            ServiceReponse<BookModel> booksResponse = new();
            try
            {
                booksResponse = await GetBooks(ordem);
                booksResponse.Dados = booksResponse.Dados.Where(book => book.Specifications.Published.Equals(published)).ToList();
                if (booksResponse.Dados == null || booksResponse.Dados.Count == 0)
                {
                    booksResponse.Mensagem = "Nenhum dado encontrado";
                    booksResponse.Sucesso = false;
                }

            }
            catch (Exception ex)
            {
                booksResponse.Mensagem = ex.Message;
                booksResponse.Sucesso = false;
            }
            return booksResponse;
        }
        public async Task<ServiceReponse<BookModel>> GetByIllustrator(AscDescEnum ordem, string illustrator)
        {
            ServiceReponse<BookModel> booksResponse = new();
            try
            {
                booksResponse = await GetBooks(ordem);
                booksResponse.Dados = booksResponse.Dados.Where(book => book.Specifications.Illustrator.Contains(illustrator)).ToList();
                if (booksResponse.Dados == null || booksResponse.Dados.Count == 0)
                {
                    booksResponse.Mensagem = "Nenhum dado encontrado";
                    booksResponse.Sucesso = false;
                }

            }
            catch (Exception ex)
            {
                booksResponse.Mensagem = ex.Message;
                booksResponse.Sucesso = false;
            }
            return booksResponse;
        }

        public async Task<ServiceReponse<BookModel>> GetByGenres(AscDescEnum ordem, string genres)
        {
            ServiceReponse<BookModel> booksResponse = new();
            try
            {
                booksResponse = await GetBooks(ordem);
                booksResponse.Dados = booksResponse.Dados.Where(book => book.Specifications.Illustrator.Contains(genres)).ToList();
                if (booksResponse.Dados == null || booksResponse.Dados.Count == 0)
                {
                    booksResponse.Mensagem = "Nenhum dado encontrado";
                    booksResponse.Sucesso = false;
                }

            }
            catch (Exception ex)
            {
                booksResponse.Mensagem = ex.Message;
                booksResponse.Sucesso = false;
            }
            return booksResponse;
        }



        public async Task<ServiceReponse<BookModel>> CalculateShipping(AscDescEnum ordem, string name)
        {
            ServiceReponse<BookModel> booksResponse = new();
            try
            {
                booksResponse = await GetBooks(ordem);
                booksResponse.Dados = booksResponse.Dados.Where(book => book.Name.ToLower().Equals(name)).ToList();
                if (booksResponse.Dados == null || booksResponse.Dados.Count == 0)
                {
                    booksResponse.Mensagem = "Nenhum dado encontrado";
                    booksResponse.Sucesso = false;
                }
                else
                {
                    booksResponse.Dados.ForEach(book =>
                    {
                        book.Price += book.CalculateFee();
                    });
                }

            }
            catch (Exception ex)
            {
                booksResponse.Mensagem = ex.Message;
                booksResponse.Sucesso = false;
            }
            return booksResponse;
        }
    }
}
