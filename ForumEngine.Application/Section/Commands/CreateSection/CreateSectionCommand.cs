using MediatR;

namespace ForumEngine.Application.Section.Commands.CreateSection;

public class CreateSectionCommand : IRequest<Guid>
{
    public string Titile { get; set; }
    public string Description { get; set; }
}