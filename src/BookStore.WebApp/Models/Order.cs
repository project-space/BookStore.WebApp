﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public List<int> BookIds { get; set; }
        public string GuestId { get; set; }
        public string FullName { get; set; }
        public string Postcode { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public string PhoneNumber { get; set; }
    }
}