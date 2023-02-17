using MediatR;

namespace ForumEngine.Application.Section.Commands.UpdateSection;

public class UpdateSectionCommand : IRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}