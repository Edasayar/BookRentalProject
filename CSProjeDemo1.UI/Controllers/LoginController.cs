using CSProjeDemo1.Entitys;
using CSProjeDemo1.UI.Dtos.LoginDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CSProjeDemo1.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<Member> _signInManager;

        public LoginController(SignInManager<Member> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginMemberDto loginMemberDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginMemberDto.UserName, loginMemberDto.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "BookHistory");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}
