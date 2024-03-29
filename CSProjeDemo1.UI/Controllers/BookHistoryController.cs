
using CSProjeDemo1.UI.Dtos.BookHistoryDto;
using CSProjeDemo1.UI.Dtos.BorrowRequestDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CSProjeDemo1.UI.Controllers
{
    [AllowAnonymous]
    public class BookHistoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookHistoryController(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }


        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44350/api/BookHistory");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ListBookHistoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult AddBookHistory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBookHistory(CreateBookHistoryDto createBookHistoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookHistoryDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44350/api/BookHistory", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> BorrowBook(int Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44350/api/BookHistory/borrow/{Id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BorrowBookRequestDto>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BorrowBook(BorrowBookRequestDto request)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44350/api/BookHistory/borrow/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ReturnBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReturnBook(BorrowBookRequestDto request)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44350/api/BookHistory/return", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }



        public async Task<IActionResult> DeleteBook(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44350/api/BookHistory/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBook(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44350/api/BookHistory/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookHistoryDto>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(UpdateBookHistoryDto updateBookHistoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookHistoryDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44350/api/BookHistory/", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }

    }
}
