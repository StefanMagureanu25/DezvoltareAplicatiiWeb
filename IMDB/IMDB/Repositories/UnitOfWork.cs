using IMDB.Data;
using IMDB.Repositories.DirectorRepository;
using IMDB.Repositories.MovieRepository;
using IMDB.Repositories.UserRepository;
using Microsoft.Data.SqlClient;

namespace IMDB.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
        public IDirectorRepository DirectorRepository { get; set; }
        public IMovieRepository MovieRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        public IDirectorRepository DirectorRepository { get; set; }
        public IMovieRepository MovieRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        private IMDBContext _dbcontext { get; set; }

        public UnitOfWork(IDirectorRepository directorRepository, IMovieRepository movieRepository, IUserRepository userRepository, IMDBContext dbcontext)
        {
            DirectorRepository = directorRepository;
            MovieRepository = movieRepository;
            UserRepository = userRepository;
            _dbcontext = dbcontext;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _dbcontext.SaveChangesAsync() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There is a problem!!!!");
                Console.WriteLine(ex);
            }

            return false;
        }
    }
}
