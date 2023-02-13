using ForumEngine.Application.Interfaces;
using MediatR;

namespace ForumEngine.Application.Topic.Commands.CreateTopic;

public class CreateTopicCommandHandler:IRequestHandler<CreateTopicCommand,Guid>
{
    private readonly IForumEngineDbContext _context;
    
    public CreateTopicCommandHandler(IForumEngineDbContext context)
    {
        _context = context;
    }
    
    public async Task<Guid> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = new ForumEngine.Domain.Topic
        {
            Title = request.Title,
            Content = request.Content,
            CreationDate = DateTime.Now,
            EditTime = null,
            SectionId = request.SectionId,
            Id = Guid.NewGuid(),
            AuthorId = request.AuthorId
        };

        await _context.Topics.AddAsync(topic, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return topic.Id;
    }
}