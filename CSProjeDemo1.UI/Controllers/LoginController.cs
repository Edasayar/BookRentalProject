using CSProjeDemo1.Entitys;
using CSProjeDemo1.UI.Dtos.LoginDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSProjeDemo1.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        //private readonly SignInManager<Member> _signInManager;

        //public LoginController(SignInManager<Member> signInManager)
        //{
        //    _signInManager = signInManager;
        //}

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Index(LoginMemberDto loginMemberDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(loginMemberDto.UserName, loginMemberDto.Password, false, false);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index", "BookHistory");
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //    return View();
        //}




        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
                var json = JsonConvert.SerializeObject(loginMemberDto);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsync("https://localhost:44350/api/Login/login", data);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "BookHistory");
                }
                else
                {
                    // Handle unsuccessful login
                    return View();
                }
            }
            return View();
        }
    }
}
