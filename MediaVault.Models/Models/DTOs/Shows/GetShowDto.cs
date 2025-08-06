using System.ComponentModel.DataAnnotations;

namespace MediaVault.Models.DTOs.Shows
{
    public class GetShowDto
    {
        [Required]
        public int Id { get; set; }
    }
}
