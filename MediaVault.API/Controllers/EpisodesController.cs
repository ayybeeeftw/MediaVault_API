using Microsoft.AspNetCore.Mvc;
using MediaVault.Models;
using MediaVault.Models.DTOs.Episodes;
using MediaVault.Services.Interfaces;

namespace MediaVault.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;

        public EpisodesController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<EpisodeDto>>>> GetAll()
        {
            var episodes = await _episodeService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<EpisodeDto>>
            {
                Status = "success",
                Message = "All episodes retrieved.",
                Data = episodes
            });
        }

        // GET: api/episodes/get-by-id?id=5
        [HttpGet("get-by-id")]
        public async Task<ActionResult<ApiResponse<EpisodeDto>>> GetById([FromQuery] GetEpisodeDto dto)
        {
            var episode = await _episodeService.GetByIdAsync(dto.Id);
            if (episode == null)
                return NotFound(new ApiResponse<EpisodeDto>
                {
                    Status = "fail",
                    Message = "Episode not found.",
                    Error = "Invalid ID"
                });

            return Ok(new ApiResponse<EpisodeDto>
            {
                Status = "success",
                Message = "Episode found.",
                Data = episode
            });
        }

        [HttpGet("by-show/{showId}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<EpisodeDto>>>> GetByShowId([FromRoute] int showId)
        {
            var episodes = await _episodeService.GetByShowIdAsync(showId);
            return Ok(new ApiResponse<IEnumerable<EpisodeDto>>
            {
                Status = "success",
                Message = $"Episodes for show ID = {showId}",
                Data = episodes
            });
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<EpisodeDto>>> Create([FromBody] CreateEpisodeDto dto)
        {
            var created = await _episodeService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, new ApiResponse<EpisodeDto>
            {
                Status = "success",
                Message = "Episode created.",
                Data = created
            });
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<string>>> Update([FromBody] UpdateEpisodeDto dto)
        {
            var result = await _episodeService.UpdateAsync(dto.Id, dto);
            if (!result)
                return NotFound(new ApiResponse<string>
                {
                    Status = "fail",
                    Message = $"No episode found with ID = {dto.Id}",
                    Error = "Update failed"
                });

            return Ok(new ApiResponse<string>
            {
                Status = "success",
                Message = "Episode updated.",
                Data = null
            });
        }

        [HttpDelete]
        public async Task<ActionResult<ApiResponse<string>>> Delete([FromBody] DeleteEpisodeDto dto)
        {
            var result = await _episodeService.SoftDeleteAsync(dto.Id);
            if (!result)
                return NotFound(new ApiResponse<string>
                {
                    Status = "fail",
                    Message = $"No episode found with ID = {dto.Id}",
                    Error = "Delete failed"
                });

            return Ok(new ApiResponse<string>
            {
                Status = "success",
                Message = "Episode deleted.",
                Data = null
            });
        }
    }
}
