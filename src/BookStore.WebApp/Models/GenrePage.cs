using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebApp.Models
{
    public class GenrePage
    {
        public GenrePage(Genre genre, List<Book> books)
        {
            Genre = genre;
            Books = books;
        }

        public Genre Genre { get; set; }
        public List<Book> Books { get; set; }
    }
}