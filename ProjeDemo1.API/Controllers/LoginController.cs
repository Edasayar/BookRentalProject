using CSProjeDemo1.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjeDemo1.API.Dtos.LoginDtos;

namespace ProjeDemo1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<Member> _signInManager;

        public LoginController(SignInManager<Member> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto loginMemberDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginMemberDto.UserName, loginMemberDto.Password, false, false);
                if (result.Succeeded)
                {
                    return Ok("Login successful");
                }
                else
                {
                    return BadRequest("Invalid username or password");
                }
            }
            return BadRequest("Invalid model state");
        }
    }
}
