using BookStore.Common.BookServiceClient;
using BookStore.Common.PurchaseServiceClient;
using BookStore.WebApp.Mappers;
using BookStore.WebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.WebApp.Controllers
{
    public class CartController : Controller
    {
        static CartsClient cartsClient = new CartsClient();
        static CartItemClient cartItemClient = new CartItemClient();
        static BooksClient booksClient = new BooksClient();

        [HttpGet]
        public JsonResult Get()
        {
            return Json(CartMapper.Map(cartsClient.GetCart()), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ViewResult Index(int id)
        {
            var cartItems = CartItemMapper.Map(cartItemClient.GetItems(id));
            var bookIds = cartItems.ConvertAll(item => item.BookId);
            var books = BookMapper.Map(booksClient.GetBooks(bookIds));
            return View(books);
        }
    }
}