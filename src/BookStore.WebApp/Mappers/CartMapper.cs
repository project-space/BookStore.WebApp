using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebApp.Mappers
{
    public class CartMapper
    {
        public static Models.Cart Map(Common.ApiClients.Design.Models.Cart cart) => new Models.Cart
        {
            Id = cart.Id,
            GuestId = cart.GuestId,
            AccountId = cart.AccountId
        };

        public static List<Models.Cart> Map(List<Common.ApiClients.Design.Models.Cart> carts) => carts.ConvertAll(Map);
    }
}