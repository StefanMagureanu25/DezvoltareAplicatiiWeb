using IMDB.Models.DTOs.Movies;
using IMDB.Services.MovieService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(Guid id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] MovieRequestDTO newMovie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = await _movieService.AddMovie(newMovie);
            if (movie == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie([FromBody] MovieRequestDTO updatedMovie, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var movie = await _movieService.UpdateMovie(updatedMovie, id);
                if (movie == null)
                {
                    return NotFound();
                }
                return Ok(movie);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(Guid id)
        {
            _movieService.DeleteMovie(id);
            return NoContent();
        }
    }
}
