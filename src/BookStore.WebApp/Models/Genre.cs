using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebApp.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String IllustrationUrl { get; set; }
    }
}