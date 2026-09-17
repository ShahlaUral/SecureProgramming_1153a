namespace CampusDocs.Api.Models
{
    public class Documents
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int OwnerId { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}
