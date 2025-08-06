using System.ComponentModel.DataAnnotations;

namespace MediaVault.Models.DTOs.Genres
{
    public class GetGenreDto
    {
        [Required]
        public int Id { get; set; }
    }
}
