using IMDB.Models;
using IMDB.Repositories.GenericRepository;

namespace IMDB.Repositories.MovieRepository
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        //Get all movies by director's Name
        Task<IEnumerable<Movie>> GetMoviesByDirectorNameAsync(string DirectorFirstName, string DirectorLastName);

        //Get all movies earlier than the given year
        Task<IEnumerable<Movie>> GetMoviesEarlierThanAsync(int year);

        //Get all movies later than the given year
        Task<IEnumerable<Movie>> GetMoviesLaterThanAsync(int year);

        //Get all movies
       Task<IEnumerable<Movie>> GetAllMovies();
    }
}
