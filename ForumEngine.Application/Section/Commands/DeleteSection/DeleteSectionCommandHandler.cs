using ForumEngine.Application.Common.Exceptions;
using ForumEngine.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ForumEngine.Application.Section.Commands.DeleteSection;

public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand>
{
    private readonly IForumEngineDbContext _context;

    public DeleteSectionCommandHandler(IForumEngineDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Sections.FirstOrDefaultAsync(section =>
            section.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Domain.Section), request.Id);
        }

        _context.Sections.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}