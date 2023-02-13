using ForumEngine.Application.Interfaces;
using MediatR;

namespace ForumEngine.Application.UserComments.Commands.CreateComment;

public class CreateCommentCommand:IRequest<Guid>
{
    public Guid UserId { get; set; }
    public Guid SectionId { get; set; }
    public Guid TopicId { get; set; }
    
    public string Comment { get; set; }
}