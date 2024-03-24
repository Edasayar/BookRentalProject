using CSProjeDemo1.Entitys;
using CSProjeDemo1.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjeDemo1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookNovelController : ControllerBase
    {
        private readonly IBookNovelService _bookNovelService;
        public BookNovelController(IBookNovelService bookNovelService)
        {
            _bookNovelService = bookNovelService;
        }
        [HttpGet]
        public IActionResult BookList()
        {
            var values = _bookNovelService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBook(BookNovel book)
        {
            _bookNovelService.TInsert(book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int Id)
        {
            var values = _bookNovelService.TGetById(Id);
            _bookNovelService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBook(BookNovel book)
        {
            _bookNovelService.TUpdate(book);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int Id)
        {
            var values = _bookNovelService.TGetById(Id);
            return Ok(values);
        }
    }
}
