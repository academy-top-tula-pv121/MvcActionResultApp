using Microsoft.AspNetCore.Mvc;
using MvcActionResultApp.Models;
using System;
using System.Diagnostics;
using System.Text.Json;

namespace MvcActionResultApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //return View();
            //return new HtmlResult("<h1>Home page</h1>");
            
            //ContentResult result = new ContentResult();
            //result.Content = "Home Page";
            //return result;

            return Content("Home Page");

        }

        public IActionResult Json()
        {
            var user = new { Name = "Bob", Age = 23 };

            //return new JsonResult(user);

            var jsonSettings = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            };

            return Json(user, jsonSettings);
        }

        public IActionResult Privacy()
        {
            //return View();
            return new HtmlResult("<h1>Privacy page</h1>");
        }

        public IActionResult MyPrivacy()
        {
            return LocalRedirectPermanent("~/Home/Privacy");
        }

        public IActionResult Search()
        {
            return RedirectPermanent("https://ya.ru");
        }

        public IActionResult Find()
        {
            return RedirectToAction("Search", "Home");
        }

        public IActionResult MyUser(string name, int age) 
            => Content($"Name {name}, Age {age}");

        public IActionResult UserObj()
        {
            return RedirectToAction("MyUser", "Home", new { name = "Bob", age = 34 });
        }

        public IActionResult SendFile()
        {
            string fileName = "database.png";
            //string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Files/{fileName}");

            //return PhysicalFile(filePath, "images/png", fileName);

            //byte[] buffer = System.IO.File.ReadAllBytes(filePath);
            //return File(buffer, "images/png", fileName);

            //FileStream stream = new(filePath, FileMode.Open);
            //return File(stream, "images/png", fileName);

            return File($"Files/{fileName}", "image/png", fileName);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}