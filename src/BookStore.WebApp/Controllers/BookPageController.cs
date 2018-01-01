using BookStore.WebApp.Models;
using BookStore.Common.BookServiceClient;
using System.Web.Mvc;
using BookStore.WebApp.Mappers;

namespace BookStore.WebApp.Controllers
{
    public class BookPageController:Controller
    {
        static BooksClient booksClient = new BooksClient();

        [HttpGet]
        public ActionResult Index(int id)
        {
            Book book = BookMapper.Map(booksClient.GetBook($"{id}"));
            return View(book);
        }

        
    }
}