using BooksAPI.Core.Contracts;
using BooksAPI.Infrastructure.Data.Repositories;
using BooksAPI.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.Core.Services
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
    }
}
