using IMDB.Models.DTOs.Directors;
using IMDB.Models;

namespace IMDB.Services.DirectorService
{
    public interface IDirectorService
    {
        Task<Director> AddDirector(DirectorRequestDTO newDirector);
        public Director UpdateDirector(DirectorRequestDTO updatedDirector, Guid id);
        Task<IEnumerable<Director>> GetAllDirectors();
        Director GetDirectorById(Guid id);
        void DeleteDirector(Guid id);
        bool Save();
    }
}
