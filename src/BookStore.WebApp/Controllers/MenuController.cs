using System.Web.Mvc;
using BookStore.WebApp.Mappers;
using BookStore.Common.ApiClients.Design.Abstractions.BookServiceClient;
using System.Threading.Tasks;
using BookStore.WebApp.Models;
using System.Collections.Generic;

namespace BookStore.WebApp.Controllers
{
    public class MenuController : Controller
    {
        private readonly IGenresClient genresClient;

        public MenuController(IGenresClient genresClient)
        {
            this.genresClient = genresClient;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = GenreMapper.Map(await genresClient.GetGenres().ConfigureAwait(false));
             
            return PartialView(model);
        }

       
    }
}
