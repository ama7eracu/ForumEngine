using MediatR;

namespace ForumEngine.Application.Topic.Commands.CreateTopic;

public class CreateTopicCommand : IRequest<Guid>
{
    public Guid AuthorId { get; set; }
    public Guid SectionId { get; set; }

    public string Title { get; set; }
    public string Content { get; set; }
}