using Books.Infrastructure.Models;

namespace Books.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();

        Task<Book> GetBookAsync(int id);

        Task<Book> AddBookAsync(Book book);

        Task EditBookAsync(int id, Book book);

        Task EditBookPartiallyAsync(int id, Book book);

        Task<Book> DeleteBookAsync(int id);
    }
}
