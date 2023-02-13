using MediatR;

namespace ForumEngine.Application.UserComments.Commands.DeleteComment;

public class DeleteCommentCommand:IRequest
{
    public Guid UserId { get; set; }
    public Guid SectionId { get; set; }
    public Guid TopicId { get; set; }
    public Guid Id { get; set; }
}