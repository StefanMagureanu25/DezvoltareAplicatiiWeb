using IMDB.Models;
using IMDB.Repositories.GenericRepository;

namespace IMDB.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    { 
        //get users with the same favourite director given
        public Task<IEnumerable<User>> GetUsersWithSameFavouriteDirectorAsync(string DirectorFirstName, string DirectorLastName);
        //Users grouped by their most liked director
        public Task<IEnumerable<IGrouping<Director, User>>> GetUsersGroupedByFavouriteDirectorAsync();
    }
}
