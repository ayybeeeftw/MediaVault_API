using System.ComponentModel.DataAnnotations;

namespace MediaVault.Models.DTOs.Shows
{
    public class DeleteShowDto
    {
        [Required]
        public int Id { get; set; }
    }
}