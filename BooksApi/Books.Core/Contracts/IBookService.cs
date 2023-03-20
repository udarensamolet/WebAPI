using Books.Infrastructure.Models;

namespace Books.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();

        Task<Book> GetBookAsync(int id);
    }
}
