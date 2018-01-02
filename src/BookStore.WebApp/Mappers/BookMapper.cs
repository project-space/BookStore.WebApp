using BookStore.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebApp.Mappers
{
    public class BookMapper
    {
        public static Book Map(Common.BookServiceClient.Models.Book book)
        {
            return new Book
            {
                Id = book.Id,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                Description = book.Description,
                GenreId = book.GenreId,
                Price = book.Price,
                Rating = book.Rating,
                Title = book.Title
            };
        }

        public static BookInCart Map(Book book, int itemId)
        {
            return new BookInCart
            {
                Id = book.Id,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                Description = book.Description,
                GenreId = book.GenreId,
                Price = book.Price,
                Rating = book.Rating,
                Title = book.Title,
                CartItemId = itemId
            };
        }

        public static List<BookInCart> Map(List<Book> books, List<CartItem> items)
        {
            var booksInCart = new List<BookInCart>();
            foreach (var item in items)
            {
                foreach(var book in books)
                {
                    if(book.Id == item.BookId)
                    {
                        booksInCart.Add(Map(book,item.Id));
                    }
                }
            }
            return booksInCart;
        }

        public static List<Book> Map(List<Common.BookServiceClient.Models.Book> books)
        {
            return books.ConvertAll(Map);
        }
    }
}