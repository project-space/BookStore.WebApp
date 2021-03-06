﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebApp.Mappers
{
    public class CartItemMapper
    {
        public static Common.ApiClients.Design.Models.CartItem Map(Models.CartItem item)
        {
            return new Common.ApiClients.Design.Models.CartItem
            {
                Id = item.Id,
                CartId = item.CartId,
                BookId = item.BookId
            };
        }

        public static Models.CartItem Map(Common.ApiClients.Design.Models.CartItem item)
        {
            return new Models.CartItem
            {
                Id = item.Id,
                CartId = item.CartId,
                BookId = item.BookId
            };
        }

        public static List<Common.ApiClients.Design.Models.CartItem> Map(List<Models.CartItem> items)
        {
            return items.ConvertAll(Map);
        }

        public static List<Models.CartItem> Map(List<Common.ApiClients.Design.Models.CartItem> items)
        {
            return items.ConvertAll(Map);
        }
    }
}