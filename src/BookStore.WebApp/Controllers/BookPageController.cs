using BookStore.WebApp.Models;
using System.Web.Mvc;
using BookStore.WebApp.Mappers;
using BookStore.Common.ApiClients.Design.Abstractions.BookServiceClient;
using System.Threading.Tasks;

namespace BookStore.WebApp.Controllers
{
    public class BookPageController:Controller
    {
        private readonly IBooksClient booksClient;

        public BookPageController(IBooksClient booksClient)
        {
            this.booksClient = booksClient;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int id)
        {
            Book book = BookMapper.Map(await booksClient.GetBook(id).ConfigureAwait(false));
            return View(book);
        }     
    }
}