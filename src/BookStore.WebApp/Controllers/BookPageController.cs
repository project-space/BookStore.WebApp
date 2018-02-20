using BookStore.WebApp.Models;
using System.Web.Mvc;
using BookStore.WebApp.Mappers;
using BookStore.Common.ApiClients.Design.Abstractions.BookServiceClient;

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
        public ActionResult Index(int id)
        {
            Book book = BookMapper.Map(booksClient.GetBook(id).Result);
            return View(book);
        }     
    }
}