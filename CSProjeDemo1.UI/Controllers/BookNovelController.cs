using CSProjeDemo1.UI.Dtos.BookHistoryDto;
using CSProjeDemo1.UI.Dtos.BookNovelDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSProjeDemo1.UI.Controllers
{
    public class BookNovelController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookNovelController(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/BookNovel");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListBookNovelDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult AddBookNovel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBookNovel(CreateBookNovelDto createBookNovelDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookNovelDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7290/api/BookNovel", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
