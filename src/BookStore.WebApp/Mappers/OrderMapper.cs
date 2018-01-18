using BookStore.Common.PurchaseServiceClient.Models;
using BookStore.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebApp.Mappers
{
    public class OrderMapper
    {
        public static Common.PurchaseServiceClient.Models.Order Map(Models.Order order)
        {
            return new Common.PurchaseServiceClient.Models.Order
            {
                Id = order.Id,
                AccountId = order.AccountId,
                BookIds = order.BookIds,
                GuestId = order.GuestId,
                FullName = order.FullName,
                Postcode = order.Postcode,
                Country = order.Country,
                City = order.City,
                Street = order.Street,
                House = order.House,
                Apartment = order.Apartment,
                PhoneNumber = order.PhoneNumber
            };
        }

        public static List<Common.PurchaseServiceClient.Models.Order> Map(List<Models.Order> orders)
        {
            return orders.ConvertAll(Map);
        }
    }
}