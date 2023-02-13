using MediatR;

namespace ForumEngine.Application.Topic.Commands.UpdateTopic;

public class UpdateTopicCommand:IRequest
{
    public Guid AuthorId { get; set; }
    public Guid SectionId { get; set; }
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    public string Content { get; set; }
    
}