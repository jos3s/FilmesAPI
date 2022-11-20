using FilmesAPI.Data.DTO;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Mapper
{
    public class MovieMapper
    {
        public static Movie CreateMovieDTOToMovie(CreateMovieDTO movieDTO)
        {
            return new Movie
            {
                Title = movieDTO.Title,
                Director = movieDTO.Director,
                Genre = movieDTO.Genre,
                Duration = movieDTO.Duration,
            };
        }
    }
}
