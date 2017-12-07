using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebApp.Models
{
    public class MainContentModel
    {
        public List<Book> Novelties { get; set; }
        public List<Book> Popular { get; set; }
    }
}