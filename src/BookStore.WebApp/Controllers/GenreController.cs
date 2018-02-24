using BookStore.WebApp.Models;
using System.Web.Mvc;
using BookStore.WebApp.Mappers;
using BookStore.Common.ApiClients.Design.Abstractions.BookServiceClient;
using System.Threading.Tasks;

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
        public async Task<ActionResult> Index(int id)
        {
            var genre = GenreMapper.Map(await genresClient.GetGenre(id).ConfigureAwait(false));
            var books = BookMapper.Map(await booksClient.GetWithGenre(id).ConfigureAwait(false));

            var model = new GenrePage(genre, books);

            return View(model);
        }

    }
}
