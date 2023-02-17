using ForumEngine.Application.Common.Exceptions;
using ForumEngine.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ForumEngine.Application.Section.Commands.UpdateSection;

public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand>
{
    private readonly IForumEngineDbContext _context;

    public UpdateSectionCommandHandler(IForumEngineDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Sections.FirstOrDefaultAsync(section =>
            section.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Domain.Section), request.Id);
        }

        entity.Title = request.Title;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}