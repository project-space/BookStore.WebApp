using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.WebApp.Models;

namespace BookStore.WebApp.Controllers
{
    public class PurchaseController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Checkout(Order order)
        {

        }
    }
}