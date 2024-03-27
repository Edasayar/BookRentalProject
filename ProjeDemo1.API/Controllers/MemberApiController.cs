using CSProjeDemo1.Entitys;
using CSProjeDemo1.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjeDemo1.API.Dtos;

namespace ProjeDemo1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberApiController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public MemberApiController(IMemberService memberService)
        {
            _memberService = memberService;
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

        [HttpGet("{id}")]
        public IActionResult GetMemberById(int id)
        {
            var member =  _memberService.TGetById(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }




    }
}
