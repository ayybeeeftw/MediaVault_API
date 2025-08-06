namespace MediaVault.Models.Entities
{
    public class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";            // e.g. "Ozymandias"
        public int Duration { get; set; }                  // duration in minutes
        public int SeasonNumber { get; set; }              // e.g. 3
        public int EpisodeNumber { get; set; }             // e.g. 9
        public string? Summary { get; set; }               // short description
        public bool IsDeleted { get; set; }

        public int ShowId { get; set; }
        public Show? Show { get; set; }
    }
}
