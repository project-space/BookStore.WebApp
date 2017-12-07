using BookStore.WebApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace BookStore.WebApp.Controllers
{
    public class GenreController : Controller
    {
        [System.Web.Mvc.HttpGet]
        public ActionResult Index(int? id)
        {
            var genre = GetGenre($"genres/{id}");
            var books = GetBooks($"withGenre/{id}");

            var model = new GenrePage(genre, books);

            return View(model);
        }

        private List<Book> GetBooks(string action)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync($"http://localhost:55328/api/books/{action}").Result;
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<Book>>(json);
        }

        private Genre GetGenre(string action)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync($"http://localhost:55328/api/genres/{action}").Result;
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Genre>(json);
        }
    }
}
