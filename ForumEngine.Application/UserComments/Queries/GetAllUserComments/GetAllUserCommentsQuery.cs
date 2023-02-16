using MediatR;

namespace ForumEngine.Application.UserComments.Queries.GetAllUserComments;

public class GetAllUserCommentsQuery:IRequest<GetAllUserCommentsVm>
{
    public Guid UserId { get; set; }
}