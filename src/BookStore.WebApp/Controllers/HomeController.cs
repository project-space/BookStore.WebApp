using BookStore.WebApp.Models;
using System.Web.Mvc;
using BookStore.WebApp.Mappers;
using BookStore.Common.ApiClients.Design.Abstractions.BookServiceClient;
using System.Threading.Tasks;

namespace BookStore.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBooksClient booksClient;

        public HomeController(IBooksClient booksClient)
        {
            this.booksClient = booksClient;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var novelties = BookMapper.Map(await booksClient.GetNovelties().ConfigureAwait(false));
            var popular = BookMapper.Map(await booksClient.GetPopular().ConfigureAwait(false));
            
            var model = new MainContentModel { Novelties = novelties, Popular = popular };

            return View(model);
        }


    }
}