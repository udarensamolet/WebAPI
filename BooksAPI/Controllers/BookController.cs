using BooksAPI.Core.Contracts;
using BooksAPI.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
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

        //[HttpGet]
        //public async Task<IActionResult> GetAllBooks()
        //{
        //    return await _bookService.GetAllBooksAsync();
        //}
    }
}
