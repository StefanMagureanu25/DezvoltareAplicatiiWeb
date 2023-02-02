using IMDB.Data;
using IMDB.Models;
using IMDB.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IMDBContext _IMDBcontext;
        public UserRepository(IMDBContext IMDBcontext) : base(IMDBcontext)
        {
            _IMDBcontext = IMDBcontext;
        }

        public async Task<IEnumerable<User>> GetUsersWithSameFavouriteDirectorAsync(string DirectorFirstName, string DirectorLastName)
        {
            var UsersSameDirector = await (from user in _IMDBcontext.Users
                                join favouriteDirector in _IMDBcontext.Directors on user.DirectorId equals favouriteDirector.Id
                                where favouriteDirector.FirstName == DirectorFirstName && favouriteDirector.LastName == DirectorLastName
                                select user).ToListAsync();
            return UsersSameDirector;
        }

        public async Task<IEnumerable<IGrouping<Director, User>>> GetUsersGroupedByFavouriteDirectorAsync()
        {
            return await _IMDBtable.AsNoTracking().GroupBy(u => u.FavouriteDirector).ToListAsync();
        }
    }
}
