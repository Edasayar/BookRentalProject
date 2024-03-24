using CSProjeDemo1.Entitys;
using CSProjeDemo1.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjeDemo1.API.Dtos;

namespace ProjeDemo1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookHistoryController : ControllerBase
    {
        private readonly IBookHistoryService _bookHistoryService;
        public BookHistoryController(IBookHistoryService bookHistoryService)
        {
            _bookHistoryService = bookHistoryService;
        }
        [HttpGet]
        public IActionResult BookList()
        {
            var values = _bookHistoryService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBook(BookHistory book)
        {
            _bookHistoryService.TInsert(book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int Id)
        {
            var values = _bookHistoryService.TGetById(Id);
            _bookHistoryService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBook(BookHistory book)
        {
            _bookHistoryService.TUpdate(book);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int Id)
        {
            var values = _bookHistoryService.TGetById(Id);
            return Ok(values);
        }

        [HttpPost("borrow/{id}")] // borrow endpoint'i /{id} ile eşleşecek şekilde güncellendi
        public IActionResult BorrowBook(int id, [FromBody] BorrowBookRequest request)
        {
            var book = _bookHistoryService.TGetById(id); // Kitap Id parametresi ile alınıyor
            if (book != null)
            {
                book.Status = CSProjeDemo1.Enums.Status.ÖdünçAlındı;
                _bookHistoryService.TUpdate(book);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("return")]
        public IActionResult ReturnBook([FromBody] BorrowBookRequest request)
        {
            _bookHistoryService.TReturnBook(request.Member, request.Book);
            return Ok();
        }
    }
}
