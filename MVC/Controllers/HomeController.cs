using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Text.Json;

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

        // Send form data POST
        [HttpPost("/form")]
        public IActionResult BookForm(BookModel model)
        {
            // Validate input
            if (ModelState.IsValid)
            {
                // Correct

                string jsonString = System.IO.File.ReadAllText("books.json");
                // Deserialize JSON
                var books = JsonSerializer.Deserialize<List<BookModel>>(jsonString);

                // Add new book
                if (books != null)
                {
                    books.Add(model);
                    // Serialize
                    jsonString = JsonSerializer.Serialize(books);
                    System.IO.File.WriteAllText("books.json", jsonString);
                }

                // Clear form
                ModelState.Clear();
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
