using CSProjeDemo1.Entitys;
using CSProjeDemo1.UI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CSProjeDemo1.UI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<Member> _userManager;

        public RegisterController(UserManager<Member> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateNewMemberDto createNewMemberDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var random = new Random();
            var memberNumber = random.Next(1000, 9999);

            var member = new Member()
            {
                FirstName = createNewMemberDto.Name,
                Email = createNewMemberDto.Mail,
                LastName = createNewMemberDto.Surname,
                UserName = createNewMemberDto.UserName,
                MemberNumber= memberNumber
                

            };
            var result = await _userManager.CreateAsync(member, createNewMemberDto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
