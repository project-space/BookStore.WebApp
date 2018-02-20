using System.Collections.Generic;

namespace BookStore.WebApp.Mappers
{
    public class OrderMapper
    {
        public static Common.ApiClients.Design.Models.Order Map(Models.Order order)
        {
            return new Common.ApiClients.Design.Models.Order
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

        public static List<Common.ApiClients.Design.Models.Order> Map(List<Models.Order> orders)
        {
            return orders.ConvertAll(Map);
        }
    }
}