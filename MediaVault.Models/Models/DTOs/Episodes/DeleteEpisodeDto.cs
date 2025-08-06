using System.ComponentModel.DataAnnotations;

namespace MediaVault.Models.DTOs.Episodes
{
    public class DeleteEpisodeDto
    {
        [Required]
        public int Id { get; set; }
    }
}
