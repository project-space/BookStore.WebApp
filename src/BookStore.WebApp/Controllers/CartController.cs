using BookStore.Common.PurchaseServiceClient;
using BookStore.WebApp.Mappers;
using BookStore.WebApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookStore.WebApp.Controllers
{
    public class CartController : Controller
    {
        static CartsClient cartsClient = new CartsClient();

        [HttpGet]
        public JsonResult Get()
        {
            return Json(CartMapper.Map(cartsClient.GetCart()), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ViewResult Index(int cartId)
        {

            return View();
        }
    }
}