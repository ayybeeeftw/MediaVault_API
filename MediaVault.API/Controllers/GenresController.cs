using Microsoft.AspNetCore.Mvc;
using MediaVault.Models;
using MediaVault.Models.DTOs.Genres;
using MediaVault.Services.Interfaces;

namespace MediaVault.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<GenreDto>>>> GetAll()
        {
            var genres = await _genreService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<GenreDto>>
            {
                Status = "success",
                Message = "All genres retrieved.",
                Data = genres
            });
        }

        // GET: api/genres/get-by-id?id=5
        [HttpGet("get-by-id")]
        public async Task<ActionResult<ApiResponse<GenreDto>>> GetById([FromQuery] GetGenreDto dto)
        {
            var genre = await _genreService.GetByIdAsync(dto.Id);
            if (genre == null)
                return NotFound(new ApiResponse<GenreDto>
                {
                    Status = "fail",
                    Message = "Genre not found.",
                    Error = "Invalid ID"
                });

            return Ok(new ApiResponse<GenreDto>
            {
                Status = "success",
                Message = "Genre found.",
                Data = genre
            });
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<GenreDto>>> Create([FromBody] CreateGenreDto dto)
        {
            var created = await _genreService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, new ApiResponse<GenreDto>
            {
                Status = "success",
                Message = "Genre created.",
                Data = created
            });
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<string>>> Update([FromBody] UpdateGenreDto dto)
        {
            var result = await _genreService.UpdateAsync(dto.Id, dto);
            if (!result)
                return NotFound(new ApiResponse<string>
                {
                    Status = "fail",
                    Message = $"No genre found with ID = {dto.Id}",
                    Error = "Update failed"
                });

            return Ok(new ApiResponse<string>
            {
                Status = "success",
                Message = "Genre updated.",
                Data = null
            });
        }

        [HttpDelete]
        public async Task<ActionResult<ApiResponse<string>>> Delete([FromBody] DeleteGenreDto dto)
        {
            var result = await _genreService.DeleteAsync(dto.Id);
            if (!result)
                return NotFound(new ApiResponse<string>
                {
                    Status = "fail",
                    Message = $"No genre found with ID = {dto.Id}",
                    Error = "Delete failed"
                });

            return Ok(new ApiResponse<string>
            {
                Status = "success",
                Message = "Genre deleted.",
                Data = null
            });
        }
    }
}
