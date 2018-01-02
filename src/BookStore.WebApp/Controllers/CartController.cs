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
        CartItemClient cartItemClient = new CartItemClient();

        [HttpGet]
        public JsonResult Get()
        {
            return Json(CartMapper.Map(cartsClient.GetCart()), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ViewResult Index(int cartId)
        {
            var cartItems = CartItemMapper.Map(cartItemClient.GetItems(cartId));

            return View();
        }

        private List<int> GetBookIds(List<CartItem> items)
        {
            var bookIds = new List<int>();
            foreach (var item in items)
            {
               bookIds.Add(item.BookId);
            }
            return bookIds;
        }
    }
}