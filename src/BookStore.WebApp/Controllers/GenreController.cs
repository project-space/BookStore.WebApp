using BookStore.WebApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using BookStore.WebApp.Mappers;
using BookStore.Common.BookServiceClient;

namespace BookStore.WebApp.Controllers
{
    public class GenreController : Controller
    {
        static BooksClient booksClient = new BooksClient();
        static GenresClient genresClient = new GenresClient();

        [HttpGet]
        public ActionResult Index(int? id)
        {
            var genre = GenreMapper.Map(genresClient.GetGenre($"genres/{id}"));
            var books = BookMapper.Map(booksClient.GetBooks($"withGenre/{id}"));

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
