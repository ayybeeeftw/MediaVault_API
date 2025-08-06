using System.ComponentModel.DataAnnotations;

namespace MediaVault.Models.DTOs.Genres
{
    public class DeleteGenreDto
    {
        [Required]
        public int Id { get; set; }
    }
}
