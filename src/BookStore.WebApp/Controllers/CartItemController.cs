using BookStore.Common.ApiClients.Design.Abstractions.PurchaseServiceClient;
using BookStore.WebApp.Mappers;
using BookStore.WebApp.Models;
using System.Threading.Tasks;
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
        public async void Add(int cartId, int bookId)
        {
            var item = CartItemMapper.Map(new CartItem { CartId = cartId, BookId = bookId});
            int id = await cartItemClient.AddCartItem(item).ConfigureAwait(false);
        }

        [HttpDelete]
        public async Task Delete(int itemId) => await cartItemClient.DeleteCartItem(itemId).ConfigureAwait(false);
    }
}