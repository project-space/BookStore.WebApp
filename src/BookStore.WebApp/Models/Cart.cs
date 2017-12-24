using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebApp.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public string GuestId { get; set; }
    }
}