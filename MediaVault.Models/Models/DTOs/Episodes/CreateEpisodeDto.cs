using System.ComponentModel.DataAnnotations;

namespace MediaVault.Models.DTOs.Episodes
{
    public class CreateEpisodeDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 150 characters.")]
        public string Title { get; set; } = "";

        [Range(1, 1000, ErrorMessage = "Duration must be between 1 and 1000 minutes.")]
        public int Duration { get; set; }

        [Range(1, 100, ErrorMessage = "Season number must be at least 1.")]
        public int SeasonNumber { get; set; }

        [Range(1, 1000, ErrorMessage = "Episode number must be at least 1.")]
        public int EpisodeNumber { get; set; }

        [StringLength(2000, ErrorMessage = "Summary cannot exceed 2000 characters.")]
        public string? Summary { get; set; }

        [Required(ErrorMessage = "ShowId is required.")]
        public int ShowId { get; set; }
    }
}
