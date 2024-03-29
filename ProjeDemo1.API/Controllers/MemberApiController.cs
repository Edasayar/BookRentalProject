using CSProjeDemo1.Entitys;
using CSProjeDemo1.Services.Abstract;
using CSProjeDemo1.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjeDemo1.API.Dtos;
using System.Security.Claims;

namespace ProjeDemo1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberApiController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IBookHistoryService _bookHistoryService;
        public MemberApiController(IMemberService memberService, IBookHistoryService bookHistoryService)
        {
            _memberService = memberService;
            _bookHistoryService = bookHistoryService;
        }
        [HttpGet]
        public IActionResult MemberList()
        {
            var values = _memberService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddMember(Member member)
        {
            _memberService.TInsert(member);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int Id)
        {
            var values = _memberService.TGetById(Id);
            _memberService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMember(Member member)
        {
            _memberService.TUpdate(member);
            return Ok();
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserProfile(int userId)
        {
            var user = _memberService.TGetById(userId);
            if (user == null)
            {
                return NotFound(); // Kullanıcı bulunamadıysa 404 hatası gönder
            }
            return Ok(user); // Kullanıcıyı JSON formatında döndür
        }




        [HttpPost("borrow/{bookId}")]
        public IActionResult BorrowBook(int bookId)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (!string.IsNullOrEmpty(userId))
            {

                var book = _bookHistoryService.TGetById(bookId);


                if (book != null)
                {

                    if (book.Status == CSProjeDemo1.Enums.Status.Mevcut)
                    {
                        book.Status = CSProjeDemo1.Enums.Status.ÖdünçAlındı;
                        _bookHistoryService.TUpdate(book);
                        return Ok();
                    }
                    else if (book.Status == CSProjeDemo1.Enums.Status.ÖdünçAlındı)
                    {

                        return BadRequest("Seçilen kitap zaten ödünç alınmış durumda.");
                    }
                    else
                    {

                        return BadRequest("Seçilen kitap mevcut değil veya başka bir durumda.");
                    }
                }
                else
                {

                    return NotFound("Seçilen kitap bulunamadı.");
                }
            }
            else
            {

                return Unauthorized("Kullanıcı oturumda değil.");
            }
        }





    }
}
