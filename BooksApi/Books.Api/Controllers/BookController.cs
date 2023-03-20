using Microsoft.AspNetCore.Mvc;
using Books.Core.Contracts;
using Books.Infrastructure.Models;

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
        public async IAsyncEnumerable<IEnumerable<Book>> GetAllBooksAsync()
        {
            yield return await _bookService.GetAllBooksAsync();
        }
    }
}
