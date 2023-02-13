using ForumEngine.Application.Common.Exceptions;
using ForumEngine.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ForumEngine.Application.Topic.Commands.UpdateTopic;

public class UpdateTopicCommandHandler : IRequestHandler<UpdateTopicCommand>
{
    private readonly IForumEngineDbContext _context;

    public UpdateTopicCommandHandler(IForumEngineDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Topics.FirstOrDefaultAsync(topic =>
            topic.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id || entity.AuthorId != request.Id
            || entity.SectionId != request.SectionId)
        {
            throw new NotFoundException(nameof(Domain.Topic), request.Id);
        }

        entity.Content = request.Content;
        entity.Title = request.Title;
        entity.EditTime = DateTime.Now;

        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}