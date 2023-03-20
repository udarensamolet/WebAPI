using Microsoft.EntityFrameworkCore;
using Books.Core.Contracts;
using Books.Infrastructure.Data.Repositories;
using Books.Infrastructure.Models;

namespace Books.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository _repository;

        public BookService(IBooksRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _repository.AllReadonly<Book>().ToListAsync();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await _repository.GetByIdAsync<Book>(id);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            var newBook = new Book()
            {
                Title = book.Title,
                Author = book.Author
            };

            await _repository.AddAsync(newBook);
            await _repository.SaveChangesAsync();

            return newBook;
        }

        public async Task EditBookAsync(int id, Book book)
        {
            var bookToEdit = await _repository.GetByIdAsync<Book>(id);    
            bookToEdit.Title = book.Title;
            bookToEdit.Author = book.Author;

            await _repository.SaveChangesAsync();
        }

        public async Task EditBookPartiallyAsync(int id, Book book)
        {
            var bookToEdit = await _repository.GetByIdAsync<Book>(id);
            bookToEdit.Title = String.IsNullOrEmpty(book.Title)
                ? bookToEdit.Title : book.Title;
            bookToEdit.Author = String.IsNullOrEmpty(book.Author)
                ? bookToEdit.Author : book.Author;

            await _repository.SaveChangesAsync();
        }

        public async Task<Book> DeleteBookAsync(int id)
        {
            var book = await _repository.GetByIdAsync<Book>(id);

            await _repository.DeleteAsync<Book>(id);
            await _repository.SaveChangesAsync();

            return book;
        }
    }
}
