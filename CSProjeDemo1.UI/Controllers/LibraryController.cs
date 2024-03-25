using Microsoft.AspNetCore.Mvc;

namespace CSProjeDemo1.UI.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
