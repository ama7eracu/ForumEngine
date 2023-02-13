using ForumEngine.Application.Common.Exceptions;
using ForumEngine.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ForumEngine.Application.UserComments.Commands.DeleteComment;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
{
    private readonly IForumEngineDbContext _context;

    public DeleteCommentCommandHandler(IForumEngineDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.UserComments.FirstOrDefaultAsync(comment =>
            comment.Id == request.Id, cancellationToken);

        if (entity == null || entity.UserId != request.UserId || entity.SectionId != request.SectionId
            || entity.TopicId != request.TopicId)
        {
            throw new NotFoundException(nameof(Domain.UserComment), request.Id);
        }

        _context.UserComments.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}