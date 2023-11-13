using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.DTOs;
using System.Reflection.Metadata.Ecma335;

namespace MoviesApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenresController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetGenresAsync()
        {
            var Genres = await _context.Genres.OrderBy(x=>x.Name).AsNoTracking().ToListAsync();
            return Ok(Genres);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetGenreByIdAsync(byte id)
        {
            var genre =await _context.Genres.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
            if (genre != null)
            {
                return Ok(genre);
            }
            else
            {
                return NotFound($"No Genre was found by ID: {id}");
            }

        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateGenreAsync(CreateGenreDto dto)
        {
            Genre genre = new() { Name = dto.Name }; 
            await _context.Genres.AddAsync(genre);
            _context.SaveChanges();
            return Ok(genre);
        } 
        
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateGenreAsync(byte id , [FromBody] CreateGenreDto dto)
        {
            var genre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == id);

            if (genre != null)
            {
                genre.Name = dto.Name;
                _context.Genres.Update(genre);
                _context.SaveChanges();
                return Ok(genre);
            }
            else
            {
                return NotFound($"No Genre was found by ID: {id}");

            }

        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGenreAsync(byte id)
        {
            var genre =await _context.Genres.FindAsync(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
                return Ok(genre);
            }
            else
            {
                return NotFound($"No Genre was found by ID: {id}");

            }

        }


    }
}
