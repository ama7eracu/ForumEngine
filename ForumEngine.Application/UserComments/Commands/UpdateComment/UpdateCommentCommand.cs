using MediatR;

namespace ForumEngine.Application.UserComments.Commands.UpdateComment;

public class UpdateCommentCommand:IRequest
{
    public Guid UserId { get; set; }
    public Guid SectionId { get; set; }
    public Guid TopicId { get; set; }
    public Guid Id { get; set; }
    
    public string Comment { get; set; }
}