using BookStore.WebApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace BookStore.WebApp.Controllers
{
    public class HomeController : Controller
    {
       
        [HttpGet]
        public ActionResult Index()
        {
            var novelties = GetBooks("novelties");
            var popular = GetBooks("popular");

            var model = new MainContentModel { Novelties = novelties, Popular = popular};

            return View(model);
        }


    }
}