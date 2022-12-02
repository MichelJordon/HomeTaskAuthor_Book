using Domain.Dto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController
    {
        private BookService _bookService;

        public BookController()
        {
            _bookService = new BookService();
        }
        [HttpGet]
        public List<GetBooks> GetBooks()
        {
            return _bookService.GetBooks();
        }

        [HttpPost("Insert")]
        public int InsertBooks(Book book)
        {
            return _bookService.InsertBooks(book);
        }

        [HttpPut("Update")]
        public int UpdateBooks(Book book)
        {
            return _bookService.UpdateBooks(book);
        }

        [HttpDelete("Delete")]
        public int DeleteBook(int id)
        {
            return _bookService.DeleteBook(id);
        }
    }
}