using BackendProvaConceitoTimeIAGRO.Models;

namespace BackendProvaConceitoTimeIAGRO.Repository
{
    public interface IBookRepository
    {
        Task<ServiceReponse<BookModel>> GetBooks();
    }
}
