using System.ComponentModel.DataAnnotations;

namespace MediaVault.Models.DTOs.Episodes
{
    public class GetEpisodeDto
    {
        [Required]
        public int Id { get; set; }
    }
}
