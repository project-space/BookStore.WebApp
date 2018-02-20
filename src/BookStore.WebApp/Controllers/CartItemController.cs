using BookStore.Common.ApiClients.Design.Abstractions.PurchaseServiceClient;
using BookStore.WebApp.Mappers;
using BookStore.WebApp.Models;
using System.Web.Mvc;

namespace BookStore.WebApp.Controllers
{
    public class CartItemController : Controller
    {
        private readonly ICartItemClient cartItemClient;

        public CartItemController(ICartItemClient cartItemClient)
        {
            this.cartItemClient = cartItemClient;
        }

        [HttpPost]
        public void Add(int cartId, int bookId)
        {
            var item = CartItemMapper.Map(new CartItem { CartId = cartId, BookId = bookId});
            int id = cartItemClient.AddCartItem(item).Result;
        }

        [HttpDelete]
        public void Delete(int itemId) => cartItemClient.DeleteCartItem(itemId);
    }
}