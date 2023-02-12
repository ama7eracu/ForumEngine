namespace ForumEngine.Domain;

public class Topic
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public Guid SectionId { get; set; }
    
    public string  Title { get; set; }
    public string  Content { get; set; }
    
    public DateTime CreationDate { get; set; }
    public DateTime? EditTime { get; set; }
}
