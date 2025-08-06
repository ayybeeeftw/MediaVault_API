namespace MediaVault.Models.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";             // e.g. "Action"
        public string? Description { get; set; }           // Optional detail
        public bool IsDeleted { get; set; }

        public ICollection<Show> Shows { get; set; } = new List<Show>();

        public static implicit operator Genre(string v)
        {
            throw new NotImplementedException();
        }
    }
}
