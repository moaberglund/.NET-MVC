using Microsoft.AspNetCore.Mvc;
using MVC.Models;

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

        [HttpPost("/form")]
        public IActionResult BookForm(BookModel model)
        {
            // Validate input
            if (!ModelState.IsValid)
            {
                // Korrekt
            } else
            {
                // Fel
            }
            return View();
        }

        [HttpGet("/list")]
        public IActionResult BookList()
        {
            return View();
        }
    }
}
