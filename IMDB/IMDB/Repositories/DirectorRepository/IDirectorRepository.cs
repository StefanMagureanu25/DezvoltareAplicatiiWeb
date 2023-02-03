using IMDB.Models;
using IMDB.Repositories.GenericRepository;

namespace IMDB.Repositories.DirectorRepository
{
    public interface IDirectorRepository : IGenericRepository<Director>
    {
        //Get a director with all his movies directed
        Task<IEnumerable<Director>> GetDirectorWithMoviesByNameAsync(string DirectorFirstName, string DirectorLastName);

        //Get all directors
        public Task<IEnumerable<Director>> GetAllDirectors();
    }
}

