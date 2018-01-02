using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebApp.Models
{
    public class BookInCart
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public string CoverUrl { get; set; }
        public int GenreId { get; set; }
        public int CartItemId { get; set; }
    }
}