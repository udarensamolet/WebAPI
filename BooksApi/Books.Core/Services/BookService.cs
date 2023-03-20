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

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _repository.AllReadonly<Book>().ToListAsync();
        }
    }
}
