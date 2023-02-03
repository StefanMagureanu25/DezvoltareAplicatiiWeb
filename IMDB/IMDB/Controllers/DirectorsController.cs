using IMDB.Data;
using IMDB.Models.DTOs.Directors;
using IMDB.Models;
using IMDB.Services.DirectorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _directorService;
        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Director>>> GetAllDirectors()
        {
            var directors = await _directorService.GetAllDirectors();
            return Ok(directors);
        }

        [HttpGet("{id}", Name = "GetDirectorById")]
        public ActionResult<Director> GetDirectorById(Guid id)
        {
            var director = _directorService.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }
            return Ok(director);
        }

        [HttpPost]
        public async Task<ActionResult<Director>> AddDirector(DirectorRequestDTO newDirector)
        {
            var director = await _directorService.AddDirector(newDirector);
            return CreatedAtRoute("GetDirectorById", new { id = director.Id }, director);
        }

        [HttpPut("{id}")]
        public ActionResult<Director> UpdateDirector(Guid id, DirectorRequestDTO updatedDirector)
        {
            var director = _directorService.UpdateDirector(updatedDirector, id);
            if (director == null)
            {
                return NotFound();
            }
            return Ok(director);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDirector(Guid id)
        {
            _directorService.DeleteDirector(id);
            return NoContent();
        }
    }
}
