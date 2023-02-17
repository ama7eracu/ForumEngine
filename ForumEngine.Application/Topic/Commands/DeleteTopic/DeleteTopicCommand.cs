using MediatR;

namespace ForumEngine.Application.Topic.Commands.DeleteTopic;

public class DeleteTopicCommand : IRequest
{
    public Guid SectionId { get; set; }
    public Guid AuthorId { get; set; }
    public Guid Id { get; set; }
}