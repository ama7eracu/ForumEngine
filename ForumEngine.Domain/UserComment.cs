namespace ForumEngine.Domain;

public class UserComment
{
    public Guid Id { get; set; }
    public Guid TopicId { get; set; }
    public Guid UserId { get; set; }
    public Guid SectionId { get; set; }
    
    public string Comment { get; set; }
    
    public DateTime CreationDate { get; set; }
    public DateTime? EditTime { get; set; }
}