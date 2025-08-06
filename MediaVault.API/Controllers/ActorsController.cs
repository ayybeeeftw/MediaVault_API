using Microsoft.AspNetCore.Mvc;
using MediaVault.Models.DTOs.Actors;
using MediaVault.Services.Interfaces;
using MediaVault.Models;

namespace MediaVault.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ActorDto>>>> GetAll()
        {
            var actors = await _actorService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<ActorDto>>
            {
                Status = "success",
                Message = "All actors retrieved.",
                Data = actors
            });
        }

        // Using GetActorDto for ID input (as query)
        [HttpGet("get-by-id")]
        public async Task<ActionResult<ApiResponse<ActorDto>>> GetById([FromQuery] GetActorDto dto)
        {
            var actor = await _actorService.GetByIdAsync(dto.Id);
            if (actor == null)
                return NotFound(new ApiResponse<ActorDto>
                {
                    Status = "fail",
                    Message = "Actor not found.",
                    Error = "Invalid ID"
                });

            return Ok(new ApiResponse<ActorDto>
            {
                Status = "success",
                Message = "Actor found.",
                Data = actor
            });
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<ActorDto>>> Create([FromBody] CreateActorDto dto)
        {
            var created = await _actorService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, new ApiResponse<ActorDto>
            {
                Status = "success",
                Message = "Actor created.",
                Data = created
            });
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<string>>> Update([FromBody] UpdateActorDto dto)
        {
            var result = await _actorService.UpdateAsync(dto.Id, dto);
            if (!result)
                return NotFound(new ApiResponse<string>
                {
                    Status = "fail",
                    Message = $"No actor found with ID = {dto.Id}",
                    Error = "Update failed"
                });

            return Ok(new ApiResponse<string>
            {
                Status = "success",
                Message = "Actor updated.",
                Data = null
            });
        }

        // Using DeleteActorDto for ID input (as body)
        [HttpDelete]
        public async Task<ActionResult<ApiResponse<string>>> Delete([FromBody] DeleteActorDto dto)
        {
            var result = await _actorService.SoftDeleteAsync(dto.Id);
            if (!result)
                return NotFound(new ApiResponse<string>
                {
                    Status = "fail",
                    Message = $"No actor found with ID = {dto.Id}",
                    Error = "Delete failed"
                });

            return Ok(new ApiResponse<string>
            {
                Status = "success",
                Message = "Actor deleted.",
                Data = null
            });
        }
    }
}
