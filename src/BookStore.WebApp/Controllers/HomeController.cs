using BookStore.WebApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace BookStore.WebApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:55328/api/books/").Result;
            var json = response.Content.ReadAsStringAsync().Result;

            var books = JsonConvert.DeserializeObject<List<Book>>(json);

            return View(books);
        }
    }
}