using BooksAPI.Infrastructure.Models;

namespace BooksAPI.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
    }
}
