namespace MediaVault.Models.Entities
{
    public class Show
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";            // e.g. "Breaking Bad"
        public int Seasons { get; set; }                   // e.g. 5
        public string Type { get; set; } = "";             // e.g. "TV Series", "Web Series", "Movie"
        public bool IsCompleted { get; set; }              // true if the series has ended
        public string? Language { get; set; }              // e.g. "English"
        public string? Country { get; set; }               // e.g. "USA"
        public string? Summary { get; set; }               // short description
        public DateTime? ReleaseDate { get; set; }         // release/start date
        public double? Rating { get; set; }                // user or critic rating

        public bool IsDeleted { get; set; }                // soft delete support

        public int GenreId { get; set; }               // FK
        public Genre Genre { get; set; } = null!;      // Navigation

        public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
        public ICollection<ShowActor> ShowActors { get; set; } = new List<ShowActor>();
    }
}
