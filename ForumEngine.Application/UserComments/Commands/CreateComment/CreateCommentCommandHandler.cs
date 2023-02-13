using ForumEngine.Application.Interfaces;
using MediatR;
namespace ForumEngine.Application.UserComments.Commands.CreateComment;

public class CreateCommentCommandHandler:IRequestHandler<CreateCommentCommand,Guid>
{
    private readonly IForumEngineDbContext _context;

    public CreateCommentCommandHandler(IForumEngineDbContext context)
    {
        _context = context;
    }
    
    public async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new Domain.UserComment
        {
            Comment = request.Comment,
            CreationDate = DateTime.Now,
            EditTime = null,
            Id = Guid.NewGuid(),
            SectionId = request.SectionId,
            TopicId = request.TopicId,
            UserId = request.UserId
        };

       await _context.UserComments.AddAsync(comment, cancellationToken);
       await _context.SaveChangesAsync(cancellationToken);

       return comment.UserId;
    }
}