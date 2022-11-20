using FilmesAPI.Data;
using FilmesAPI.Data.DTO;
using FilmesAPI.Data.Mapper;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [Controller]
    [Route("Movie")]
    public class MovieController : ControllerBase
    {

        private MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult InsertMovie(CreateMovieDTO movieDTO)
        {
            Movie movie = MovieMapper.CreateMovieDTOToMovie(movieDTO);
            
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMovieForId),  new { movie.Id },  movie);
        }

        [HttpGet]
        public IActionResult GetMovies() {
            return Ok(_context.Movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieForId(long id) {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            return movie == null ? NotFound() : Ok(movie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(long id, [FromBody] Movie newMovie)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null)  return NotFound();

            movie.Title = newMovie.Title;
            movie.Director = newMovie.Director;
            movie.Duration = newMovie.Duration;
            movie.Genre = newMovie.Genre;

            _context.Movies.Update(movie);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveMovie(long id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null) return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
