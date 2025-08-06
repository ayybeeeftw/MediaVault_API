using Microsoft.AspNetCore.Mvc;
using MediaVault.Models;
using MediaVault.Models.DTOs.Shows;
using MediaVault.Services.Interfaces;

namespace MediaVault.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowsController : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowsController(IShowService showService)
        {
            _showService = showService;
        }

        // GET: api/shows
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ShowDto>>>> GetAll()
        {
            var shows = await _showService.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<ShowDto>>.Success(shows, "Shows fetched successfully."));
        }

        // GET: api/shows/get-by-id?id=5
        [HttpGet("get-by-id")]
        public async Task<ActionResult<ApiResponse<ShowDto>>> GetById([FromQuery] GetShowDto dto)
        {
            var show = await _showService.GetByIdAsync(dto.Id);
            if (show == null)
                return NotFound(ApiResponse<ShowDto>.Fail("Show not found."));

            return Ok(ApiResponse<ShowDto>.Success(show));
        }

        // POST: api/shows
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ShowDto>>> Create([FromBody] CreateShowDto dto)
        {
            var created = await _showService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = created.Id },
                ApiResponse<ShowDto>.Success(created, "Show created."));
        }

        // PUT: api/shows
        [HttpPut]
        public async Task<ActionResult<ApiResponse<string>>> Update([FromBody] UpdateShowDto dto)
        {
            var updated = await _showService.UpdateAsync(dto.Id, dto);

            return updated
                ? Ok(ApiResponse<string>.Success("Show updated successfully."))
                : NotFound(ApiResponse<string>.Fail("Show not found."));
        }

        // DELETE: api/shows
        [HttpDelete]
        public async Task<ActionResult<ApiResponse<string>>> SoftDelete([FromBody] DeleteShowDto dto)
        {
            var deleted = await _showService.SoftDeleteAsync(dto.Id);

            return deleted
                ? Ok(ApiResponse<string>.Success("Show soft-deleted."))
                : NotFound(ApiResponse<string>.Fail("Show not found."));
        }
    }
}
