using ForumEngine.Application.Common.Exceptions;
using ForumEngine.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ForumEngine.Application.UserComments.Commands.UpdateComment;

public class UpdateCommentCommandHandler:IRequestHandler<UpdateCommentCommand>
{
    private readonly IForumEngineDbContext _context;

    public UpdateCommentCommandHandler(IForumEngineDbContext context)
    {
        _context = context;
    }
    
    public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.UserComments.FirstOrDefaultAsync(comment =>
            comment.Id == request.Id, cancellationToken);

        if (entity != null || entity.UserId != request.UserId ||
            entity.TopicId != request.TopicId || entity.SectionId != request.TopicId)
        {
            throw new NotFoundException(nameof(Domain.UserComment), request.Id);
        }
        
        entity.EditTime=DateTime.Today;
        entity.Comment = request.Comment;

        await  _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}