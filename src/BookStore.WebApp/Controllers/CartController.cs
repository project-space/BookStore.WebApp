using BookStore.Common.ApiClients.Design.Abstractions.BookServiceClient;
using BookStore.Common.ApiClients.Design.Abstractions.PurchaseServiceClient;
using BookStore.WebApp.Mappers;
using BookStore.WebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartsClient cartsClient;
        private readonly IBooksClient booksClient;
        private readonly ICartItemClient cartItemClient;

        public CartController(ICartItemClient cartItemClient, ICartsClient cartsClient, IBooksClient booksClient)
        {
            this.cartsClient = cartsClient;
            this.booksClient = booksClient;
            this.cartItemClient = cartItemClient;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(CartMapper.Map(cartsClient.GetCart().Result), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ViewResult Index(int id)
        {
            var cartItems = CartItemMapper.Map(cartItemClient.GetItems(id).Result);
            var bookIds = cartItems.ConvertAll(item => item.BookId);
            var books = BookMapper.Map(booksClient.GetBooks(bookIds).Result);
            var model = BookMapper.Map(books,cartItems);
            
            return View(model);
        }
    }
}