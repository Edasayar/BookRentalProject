using CSProjeDemo1.Services.Abstract;
using CSProjeDemo1.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjeDemo1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        private readonly IMemberService _memberService;
        private readonly IBookHistoryService _bookHistoryService;
        private readonly IBookNovelService _bookNovelService;
        private readonly IBookScienceService _bookScienceService;
     

        public LibraryController(ILibraryService libraryService, IMemberService memberService, IBookHistoryService bookHistoryService,IBookNovelService bookNovelService, IBookScienceService bookScienceService)
        {
            _libraryService = libraryService;
            _memberService = memberService;
            _bookHistoryService = bookHistoryService;
            _bookNovelService = bookNovelService;
            _bookScienceService = bookScienceService;
        }

        [HttpGet("books")]
        public IActionResult BookList()
        {
            var books = _bookHistoryService.TGetList();
            return Ok(books);
        }

        [HttpGet("members")]
        public IActionResult GetMembers()
        {
            var members = _memberService.TGetList();
            return Ok(members);
        }

     
    }
}
