using IMDB.Data;
using IMDB.Models;
using IMDB.Repositories.DirectorRepository;
using IMDB.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Repositories.DirectorRepository
{
    public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
    {
        private readonly IMDBContext _context;

        public DirectorRepository(IMDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Director>> GetDirectorWithMoviesByNameAsync(string DirectorFirstName, string DirectorLastName)
        {
            return await _context.Directors
                .Where(d => d.FirstName == DirectorFirstName && d.LastName == DirectorLastName)
                .Include(d => d.Movies)
                .ToListAsync();
        }
        public async Task<IEnumerable<Director>> GetAllDirectors()
        {
            return _context.Directors.ToList();
        }
    }
}
