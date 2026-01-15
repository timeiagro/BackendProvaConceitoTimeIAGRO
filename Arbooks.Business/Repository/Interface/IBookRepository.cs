using Arbooks.Business.DTOs;

namespace Arbooks.Business.Repository.Interface
{
    public interface IBookRepository
    {
        List<BookDTO> Load();
    }
}
