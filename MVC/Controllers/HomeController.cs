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

                // Redirect to list
                return RedirectToAction("BookList", "Home");
            }
            return View();
        }

        [HttpGet("/list")]
        public IActionResult BookList()
        {
            string jsonString = System.IO.File.ReadAllText("books.json");
            // Deserialize JSON
            var books = JsonSerializer.Deserialize<List<BookModel>>(jsonString) ?? new List<BookModel>();
            // If books.json is empty, return an empty list

            // Filter books with a higher score than 0
            var ratedBooks = books.Where(b => b.Rating > 0).ToList();

            // Calculate average rating
            double average = ratedBooks.Count > 0 ? ratedBooks.Average(b => (double)b.Rating) : 0;
            // If there are rated books, calculate the average rating, otherwise return 0

            // Send AverageRating with ViewBag
            ViewBag.AverageRating = average;

            return View(books);
        }
    }
}
