using MediatR;

namespace ForumEngine.Application.Topic.Queries.GetAllSectionTopics;

public class GetAllSectionTopicsQuery: IRequest<GetAllSectionTopicsVm>
{
    public Guid SectionId { get; set; }
}