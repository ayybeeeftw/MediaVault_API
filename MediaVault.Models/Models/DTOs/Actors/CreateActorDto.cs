using System.ComponentModel.DataAnnotations;

namespace MediaVault.Models.DTOs.Actors
{
    public class CreateActorDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 80 characters.")]
        public string Name { get; set; } = "";

        [StringLength(1000, ErrorMessage = "Biography cannot exceed 1000 characters.")]
        public string? Biography { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [StringLength(50, ErrorMessage = "Nationality cannot exceed 50 characters.")]
        public string? Nationality { get; set; }

        [StringLength(20, ErrorMessage = "Gender cannot exceed 20 characters.")]
        public string? Gender { get; set; }
    }
}
