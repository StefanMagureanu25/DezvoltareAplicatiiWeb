using System.Linq;
using System.Threading.Tasks;
using IMDB.Data;
using IMDB.Models;
using IMDB.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Repositories.MovieRepository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly IMDBContext _dbContext;
 
        public MovieRepository(IMDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByDirectorNameAsync(string DirectorFirstName, string DirectorLastName)
        {
            return await _dbContext.Movies
                .Include(m => m.Director)
                .Where(m => m.Director.FirstName == DirectorFirstName && m.Director.LastName == DirectorLastName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesEarlierThanAsync(int year)
        {
            return await _dbContext.Movies
                .Where(m => DateTime.Parse(m.ToString()).Year< year)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesLaterThanAsync(int year)
        {
            return await _dbContext.Movies
                .Where(m => DateTime.Parse(m.ToString()).Year > year)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return _dbContext.Movies.ToList();
        }
    }
}
