using BookStore.WebApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using BookStore.WebApp.Mappers;
using BookStore.Common.ApiClients.Design.Abstractions.BookServiceClient;

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
        public ActionResult Index()
        {
            var novelties = BookMapper.Map(booksClient.GetNovelties().Result);
            var popular = BookMapper.Map(booksClient.GetPopular().Result);

            var model = new MainContentModel { Novelties = novelties, Popular = popular};
            
            return View(model);
        }


    }
}