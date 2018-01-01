using BookStore.Common.BookServiceClient;
using System.Web.Mvc;
using BookStore.WebApp.Mappers;

namespace BookStore.WebApp.Controllers
{
    public class MenuController : Controller
    {
        GenresClient genreClient = new GenresClient();

        [HttpGet]
        public ActionResult Index()
        {
            var model = GenreMapper.Map(genreClient.GetGenres());
            return PartialView(model);
        }

       
    }
}
