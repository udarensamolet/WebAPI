using Books.Infrastructure.Models;

namespace Books.Core.Contracts
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
    }
}
