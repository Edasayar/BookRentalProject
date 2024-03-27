using CSProjeDemo1.UI.Dtos.BookNovelDto;
using CSProjeDemo1.UI.Dtos.LibraryDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CSProjeDemo1.UI.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LibraryController(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }
        public async Task<IActionResult> MemberList()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44350/api/Library/members");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<LibraryListMemberDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        public async Task<IActionResult> BookList()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44350/api/Library/books");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<LibraryListMemberDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
