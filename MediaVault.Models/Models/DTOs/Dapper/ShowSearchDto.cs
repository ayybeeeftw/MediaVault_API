namespace MediaVault.Models.Models.DTOs.Dapper
{
    public class ShowSearchDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public string GenreName { get; set; } = string.Empty;
    }
}
