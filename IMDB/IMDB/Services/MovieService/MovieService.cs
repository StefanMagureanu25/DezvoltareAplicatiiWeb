using IMDB.Models;
using IMDB.Models.DTOs.Movies;
using IMDB.Repositories.MovieRepository;

namespace IMDB.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> AddMovie(MovieRequestDTO newMovie)
        {
            var movie = new Movie
            {
                Id = Guid.NewGuid(),
                MovieTitle = newMovie.MovieTitle
            };
            _movieRepository.Create(movie);
            if (await _movieRepository.SaveAsync())
            {
                return movie;
            }
            else
            {
                return null;
            }
        }

        public async Task<Movie> UpdateMovie(MovieRequestDTO updatedMovie,Guid id)
        {
            var movie = _movieRepository.FindById(id);
            if(movie == null)
            {
                throw new ArgumentException($"Movie not found.");
            }
     
            movie.MovieTitle = updatedMovie.MovieTitle;

            _movieRepository.Update(movie);
            if (await _movieRepository.SaveAsync())
            {
                return movie;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _movieRepository.GetAllMovies();
        }

        public Movie GetMovieById(Guid id)
        {
            return _movieRepository.FindById(id);
        }

        public void DeleteMovie(Guid id)
        {
            _movieRepository.Delete(GetMovieById(id));
            _movieRepository.SaveAsync().Wait();
        }

        public bool Save()
        {
            return _movieRepository.SaveAsync().Result;
        }
    }
}
