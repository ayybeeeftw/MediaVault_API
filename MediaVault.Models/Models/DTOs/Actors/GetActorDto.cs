using System.ComponentModel.DataAnnotations;

namespace MediaVault.Models.DTOs.Actors
{
    public class GetActorDto
    {
        [Required]
        public int Id { get; set; }
    }
}
