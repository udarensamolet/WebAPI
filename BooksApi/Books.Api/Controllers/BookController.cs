using Microsoft.AspNetCore.Mvc;
using Books.Core.Contracts;
using Books.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Books.Api.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async IAsyncEnumerable<IEnumerable<Book>> GetAllBooks()
        {
            yield return await _bookService.GetAllBooksAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookService.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            book = await _bookService.AddBook(book);
            return await GetBook(book.Id);
        }
    }
}
