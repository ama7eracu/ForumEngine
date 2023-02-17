using System.Collections.Specialized;
using ForumEngine.Application.Interfaces;
using MediatR;

namespace ForumEngine.Application.Section.Commands.CreateSection;

public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, Guid>
{
    private readonly IForumEngineDbContext _context;

    public CreateSectionCommandHandler(IForumEngineDbContext context) =>
        _context = context;

    public async Task<Guid> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
    {
        var section = new Domain.Section
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            Title = request.Titile
        };

        await _context.Sections.AddAsync(section, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return section.Id;
    }
}