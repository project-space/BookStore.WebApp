using BookStore.WebApp.Models;
using BookStore.Common.BookServiceClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebApp.Mappers
{
    public class GenreMapper
    {
        public static Models.Genre Map(Common.BookServiceClient.Models.Genre genre)
        {
            return new Models.Genre
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description,
                IllustrationUrl = genre.IllustrationUrl

            };
        }

        public static List<Models.Genre> Map(List<Common.BookServiceClient.Models.Genre> genres)
        {
            return genres.ConvertAll(Map);
        }
    }
}