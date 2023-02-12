using MediatR;
namespace ForumEngine.Application.Topic.Commands;

public class CreateTopic:IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    
}