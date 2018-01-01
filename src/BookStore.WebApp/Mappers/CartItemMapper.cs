using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebApp.Mappers
{
    public class CartItemMapper
    {
        public static Common.PurchaseServiceClient.Models.CartItem Map(Models.CartItem item)
        {
            return new Common.PurchaseServiceClient.Models.CartItem
            {
                Id = item.Id,
                CartId = item.CartId,
                BookId = item.BookId
            };
        }

        public static List<Common.PurchaseServiceClient.Models.CartItem> Map(List<Models.CartItem> items)
        {
            return items.ConvertAll(Map);
        }
    }
}