using System.ComponentModel.DataAnnotations;

namespace MediaVault.Models.DTOs.Actors
{
    public class DeleteActorDto
    {
        [Required]
        public int Id { get; set; }
    }
}
