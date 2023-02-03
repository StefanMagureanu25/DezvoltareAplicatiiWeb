using IMDB.Models.DTOs.Movies;
using IMDB.Models;

namespace IMDB.Services.MovieService
{
    public interface IMovieService
    {
        Task<Movie> AddMovie(MovieRequestDTO newMovie);
        Task<Movie> UpdateMovie(MovieRequestDTO updatedMovie,Guid id);
        Task<IEnumerable<Movie>> GetAllMovies();
        Movie GetMovieById(Guid id);
        void DeleteMovie(Guid id);
        bool Save();
    }
}
