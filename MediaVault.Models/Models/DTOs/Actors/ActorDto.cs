namespace MediaVault.Models.DTOs.Actors
{
    public class ActorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Biography { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Nationality { get; set; }
        public string? Gender { get; set; }
    }
}
