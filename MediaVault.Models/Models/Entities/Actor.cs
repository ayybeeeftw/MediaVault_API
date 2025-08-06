namespace MediaVault.Models.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";             // Full name
        public string? Biography { get; set; }             // Short bio
        public DateTime? BirthDate { get; set; }           // Date of birth
        public string? Nationality { get; set; }           // e.g. "American"
        public string? Gender { get; set; }                // "Male", "Female", etc.
        public bool IsDeleted { get; set; }

        public ICollection<ShowActor> ShowActors { get; set; } = new List<ShowActor>();
    }
}
