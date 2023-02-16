using ForumEngine.Application.Topic.Queries.GetAllSectionTopics;
using MediatR;

namespace ForumEngine.Application.Topic.Queries.GetAllUserTopics;

public class GetAllUserTopicsQuery:IRequest<GetAllSectionTopicsVm>, IRequest<GetAllUserTopicsVm>
{
    public Guid UserId { get; set; }
}