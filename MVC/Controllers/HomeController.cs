using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookForm()
        {
            return View();
        }

        public IActionResult BookList()
        {
            return View();
        }
    }
}
