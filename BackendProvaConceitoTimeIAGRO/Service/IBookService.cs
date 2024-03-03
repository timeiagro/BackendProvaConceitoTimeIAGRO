using BackendProvaConceitoTimeIAGRO.Enums;
using BackendProvaConceitoTimeIAGRO.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendProvaConceitoTimeIAGRO.Service
{
    public interface IBookService
    {
        Task<ServiceReponse<BookModel>> GetBooks(AscDescEnum ordem);
        Task<ServiceReponse<BookModel>> GetByAuthor(AscDescEnum ordem, string author);
        Task<ServiceReponse<BookModel>> GetByName(AscDescEnum ordem, string name);
        Task<ServiceReponse<BookModel>> GetByPrice(AscDescEnum ordem, double price);
        Task<ServiceReponse<BookModel>> GetByPublished(AscDescEnum ordem, string published);
        Task<ServiceReponse<BookModel>> GetByIllustrator(AscDescEnum ordem, string illustrator);
        Task<ServiceReponse<BookModel>> GetByGenres(AscDescEnum ordem, string genres);
        Task<ServiceReponse<BookModel>> CalculateShipping(AscDescEnum ordem, string name);
    }
}
