﻿using IMDB.Models.DTOs.Directors;
using IMDB.Models;
using IMDB.Repositories.GenericRepository;
using IMDB.Repositories.DirectorRepository;

namespace IMDB.Services.DirectorService
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task<Director> AddDirector(DirectorRequestDTO newDirector)
        {
            var director = new Director
            {
                FirstName = newDirector.FirstName,
                LastName = newDirector.LastName
            };
            await _directorRepository.CreateAsync(director);
            return director;
        }

        public Director UpdateDirector(DirectorRequestDTO updatedDirector, Guid id)
        {
            var director = _directorRepository.GetById(id);
            if (director == null)
            {
                throw new ArgumentException("Director not found");
            }
            director.FirstName = updatedDirector.FirstName;
            director.LastName = updatedDirector.LastName;
            _directorRepository.Update(director);
            return director;
        }

        public async Task<IEnumerable<Director>> GetAllDirectors()
        {
            return await _directorRepository.GetAllDirectors();
        }

        public Director GetDirectorById(Guid id)
        {
            return _directorRepository.GetById(id);
        }

        public void DeleteDirector(Guid id)
        {
            _directorRepository.Delete(GetDirectorById(id));
            _directorRepository.SaveAsync().Wait();
        }

        public bool Save()
        {
            return _directorRepository.SaveAsync().Result;
        }
    }
}
