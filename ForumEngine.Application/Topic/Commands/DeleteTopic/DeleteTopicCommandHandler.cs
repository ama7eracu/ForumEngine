using ForumEngine.Application.Common.Exceptions;
using ForumEngine.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ForumEngine.Application.Topic.Commands.DeleteTopic;

public class DeleteTopicCommandHandler : IRequestHandler<DeleteTopicCommand>
{
    private readonly IForumEngineDbContext _context;

    public DeleteTopicCommandHandler(IForumEngineDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Topics.FirstOrDefaultAsync(topic =>
            topic.Id == request.Id, cancellationToken);

        if (entity == null || entity.SectionId != request.SectionId || entity.AuthorId != request.AuthorId)
        {
            throw new NotFoundException(nameof(Domain.Topic), request.Id);
        }

        _context.Topics.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}