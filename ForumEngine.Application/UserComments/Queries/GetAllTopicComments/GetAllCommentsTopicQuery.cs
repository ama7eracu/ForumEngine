using MediatR;

namespace ForumEngine.Application.UserComments.Queries.GetAllComments;

public class GetAllCommentsTopicQuery : IRequest<AllCommentsTopicVm>
{
    public Guid TopicId { get; set; }
}