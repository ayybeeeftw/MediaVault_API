namespace MediaVault.Models.DTOs.Episodes
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int Duration { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string? Summary { get; set; }
        public int ShowId { get; set; }
    }
}
