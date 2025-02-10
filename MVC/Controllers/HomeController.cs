using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Text.Json;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Try to fetch book from cookies
            var currentBookJson = Request.Cookies["CurrentBook"];
            BookModel currentBook = null;

            if (!string.IsNullOrEmpty(currentBookJson))
            {
                currentBook = JsonSerializer.Deserialize<BookModel>(currentBookJson);
            }
            return View(currentBook);
        }

        // Send current book to Cookie
        [HttpPost]
        public IActionResult SetCurrentBook(BookModel model)
        {
            if(ModelState.IsValid)
            {
                // Serialize book
                var bookJson = JsonSerializer.Serialize(model);

                // Set cookie
                Response.Cookies.Append("CurrentBook", bookJson, new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(30),
                    HttpOnly = true
                });

                return RedirectToAction("Index");
            }
            return View("Index", model);
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
