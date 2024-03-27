using CSProjeDemo1.Services.Abstract;
using CSProjeDemo1.UI.Dtos.BookScienceDto;
using CSProjeDemo1.UI.Dtos.MemberDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CSProjeDemo1.UI.Controllers
{
    public class MemberController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemberService _memberService;
        public MemberController(IHttpClientFactory httpClientFactory, IMemberService memberService)
        {

            _httpClientFactory = httpClientFactory;
            _memberService = memberService;

        }
      
        
        public async Task<IActionResult> Profile()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44350/api/MemberApi");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<MemberListDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
