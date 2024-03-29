using CSProjeDemo1.Services.Abstract;
using CSProjeDemo1.UI.Dtos.BookScienceDto;
using CSProjeDemo1.UI.Dtos.BorrowRequestDTO;
using CSProjeDemo1.UI.Dtos.MemberDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CSProjeDemo1.UI.Controllers
{
   
    public class MemberController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
      
        public MemberController(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;
          

        }

        public async Task<IActionResult> ViewProfile(int userId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44350/api/MemberApi/{userId}");

            if (response.IsSuccessStatusCode)
            {
                var userData = await response.Content.ReadAsStringAsync();
                var userProfile = JsonConvert.DeserializeObject<MemberDto>(userData);
                return View(userProfile); // Profil sayfasını görüntüle ve model olarak kullanıcı profili verisini gönder
            }
            else
            {
                // Handle error case
                return View("Error");
            }
        }



        [HttpGet]
        public async Task<IActionResult> BorrowBook(int bookId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44350/api/MemberApi/borrow/{bookId}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var borrowRequestDto = new BorrowBookRequestDto
                {
                    BookId = bookId
                };
                return View(borrowRequestDto);
            }
            return View();
        }

    }
}
