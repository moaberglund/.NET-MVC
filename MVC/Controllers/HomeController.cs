using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/form")]
        public IActionResult BookForm()
        {
            return View();
        }

        [HttpGet("/list")]
        public IActionResult BookList()
        {
            return View();
        }
    }
}
