using CSProjeDemo1.Entitys;
using CSProjeDemo1.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjeDemo1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookScienceController : ControllerBase
    {
        private readonly IBookScienceService _bookScienceService;
        public BookScienceController(IBookScienceService bookScienceService)
        {
            _bookScienceService = bookScienceService;
        }

        [HttpGet]
        public IActionResult BookList()
        {
            var values = _bookScienceService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBook(BookScience book)
        {
            _bookScienceService.TInsert(book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int Id)
        {
            var values = _bookScienceService.TGetById(Id);
            _bookScienceService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBook(BookScience book)
        {
            _bookScienceService.TUpdate(book);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int Id)
        {
            var values = _bookScienceService.TGetById(Id);
            return Ok(values);
        }
    }
}
