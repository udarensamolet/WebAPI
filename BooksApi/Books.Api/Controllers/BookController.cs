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

        /// <summary>
        /// Gets a list with all books.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/book
        ///     {
        ///     
        ///     }
        /// </remarks>
        /// <response code="200">Returns "OK" with a list of all books</response>
        [HttpGet]
        public async IAsyncEnumerable<IEnumerable<Book>> GetAllBooks()
        {
            yield return await _bookService.GetAllBooksAsync();
        }

        /// <summary>
        /// Gets a book by id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/book/{id}
        ///     {
        ///     
        ///     }
        /// </remarks>
        /// <response code="200">Returns "OK" with the book</response>
        /// <response code="404">Returns "Not Found" when a book with the given id doesn't exist</response>
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

        /// <summary>
        /// Creates a new book and adds it to the db.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/book
        ///     {
        ///         "title": "Title",
        ///         "author": "Author"
        ///     }
        /// </remarks>
        /// <response code="201">Returns "Created" with the created book</response>
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            book = await _bookService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBook), new {id = book.Id}, book);
        }

        /// <summary>
        /// Edits a book.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/book/{id}
        ///     {
        ///         "title": "Title",
        ///         "author": "Author"
        ///     }
        /// </remarks>
        /// <response code="200">Returns "Ok"</response>
        /// <response code="400">Returns "Bad Request" when a book when an invalid request is sent</response>
        /// <response code="404">Returns "Not Found" when a book with the given id doesn't exist</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditBook(int id, Book book)
        {
            var bookToEdit = await _bookService.GetBookAsync(id);
            if (bookToEdit == null)
            {
                return NotFound();
            }

            await _bookService.EditBookAsync(id, book);

            return Ok();
        }

        /// <summary>
        /// Edits a book partially.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PATCH /api/book/{id}
        ///     {
        ///         "title": "Title",
        ///     }
        /// </remarks>
        /// <response code="200">Returns "Ok"</response>
        /// <response code="404">Returns "Not Found" when a book with the given id doesn't exist</response>
        [HttpPatch("{id}")]
        public async Task<IActionResult> EditBookPartially(int id, Book book)
        {
            var bookToEdit = await _bookService.GetBookAsync(id);
            if (bookToEdit == null)
            {
                return NotFound();
            }

            await _bookService.EditBookPartiallyAsync(id, book);

            return Ok();
        }

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/book/{id}
        ///     {
        ///     
        ///     }
        /// </remarks>
        /// <response code="200">Returns "Ok"</response>
        /// <response code="404">Returns "Not Found" when a book with the given id doesn't exist</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _bookService.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
