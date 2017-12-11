using BookStore.WebApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using BookStore.Common.BookServiceClient;
using System.Web.Mvc;
using BookStore.WebApp.Mappers;

namespace BookStore.WebApp.Controllers
{
    public class HomeController : Controller
    {
        static BooksClient booksClient = new BooksClient();

        [HttpGet]
        public ActionResult Index()
        {
            var novelties = BookMapper.Map(booksClient.GetBooks("novelties"));
            var popular = BookMapper.Map(booksClient.GetBooks("popular"));

            var model = new MainContentModel { Novelties = novelties, Popular = popular};
            
            return View(model);
        }


    }
}