using System.Collections.Generic;

namespace BookStore.WebApp.Mappers
{
    public class GenreMapper
    {
        public static Models.Genre Map(Common.ApiClients.Design.Models.Genre genre)
        {
            return new Models.Genre
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description,
                IllustrationUrl = genre.IllustrationUrl
            };
        }

        public static List<Models.Genre> Map(List<Common.ApiClients.Design.Models.Genre> genres)
        {
            return genres.ConvertAll(Map);
        }
    }
}