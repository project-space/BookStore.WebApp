using BookStore.Common.PurchaseServiceClient;
using BookStore.WebApp.Mappers;
using BookStore.WebApp.Models;
using System.Web.Mvc;

namespace BookStore.WebApp.Controllers
{
    public class CartItemController : Controller
    {
        static CartItemClient cartItemClient = new CartItemClient();

        [HttpPost]
        public void Add(int cartId, int bookId)
        {
            var item = CartItemMapper.Map(new CartItem { CartId = cartId, BookId = bookId});
            cartItemClient.AddCartItem(item);
        }

        [HttpDelete]
        public void Delete(int itemId)
        {
            cartItemClient.DeleteCartItem(itemId);
        }
    }
}