namespace MediaVault.Models.DTOs.Shows
{
    public class ShowDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int GenreId { get; set; }            // ✅ added
        public string GenreName { get; set; } = ""; // ✅ added (from navigation)
        public int Seasons { get; set; }
        public string Type { get; set; } = "";
        public bool IsCompleted { get; set; }
        public string? Language { get; set; }
        public string? Country { get; set; }
        public string? Summary { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public double? Rating { get; set; }
    }
}
