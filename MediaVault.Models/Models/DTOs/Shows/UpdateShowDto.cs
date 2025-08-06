using System.ComponentModel.DataAnnotations;

namespace MediaVault.Models.DTOs.Shows
{
    public class UpdateShowDto
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 150 characters.")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "GenreId is required.")]
        public int GenreId { get; set; }

        [Range(1, 100, ErrorMessage = "Seasons must be at least 1.")]
        public int Seasons { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters.")]
        public string Type { get; set; } = "";

        public bool IsCompleted { get; set; }

        [StringLength(30, ErrorMessage = "Language cannot exceed 30 characters.")]
        public string? Language { get; set; }

        [StringLength(50, ErrorMessage = "Country cannot exceed 50 characters.")]
        public string? Country { get; set; }

        [StringLength(2000, ErrorMessage = "Summary cannot exceed 2000 characters.")]
        public string? Summary { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10.")]
        public double? Rating { get; set; }
    }
}
