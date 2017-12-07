using System;
using System.Collections.Generic;
using BookStore.WebApp.Models;

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace BookStore.WebApp.Controllers
{
    public class MenuController : Controller
    {
        [System.Web.Mvc.HttpGet]
        public ActionResult Index()
        {
            var model = GetGenres("genres");
            return PartialView(model);
        }

        private List<Genre> GetGenres(string action)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync($"http://localhost:55328/api/genres/{action}").Result;
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<Genre>>(json);
        }
    }
}
