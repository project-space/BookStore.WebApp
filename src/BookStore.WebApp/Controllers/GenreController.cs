using BookStore.WebApp.Models;
using System.Web.Mvc;
using BookStore.WebApp.Mappers;
using BookStore.Common.ApiClients.Design.Abstractions.BookServiceClient;

namespace BookStore.WebApp.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenresClient genresClient;
        private readonly IBooksClient booksClient;

        public GenreController(IGenresClient genresClient, IBooksClient booksClient)
        {
            this.booksClient = booksClient;
            this.genresClient = genresClient;
        }

        [HttpGet]
        /*поменяла в int? на int в параметрах*/
        public ActionResult Index(int id)
        {
            var genre = GenreMapper.Map(genresClient.GetGenre(id).Result);
            var books = BookMapper.Map(booksClient.GetWithGenre(id).Result);

            var model = new GenrePage(genre, books);

            return View(model);
        }

    }
}
