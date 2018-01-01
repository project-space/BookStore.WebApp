using BookStore.WebApp.Models;
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

    }
}
