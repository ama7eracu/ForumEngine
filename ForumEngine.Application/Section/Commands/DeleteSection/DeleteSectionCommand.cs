using MediatR;

namespace ForumEngine.Application.Section.Commands.DeleteSection;

public class DeleteSectionCommand : IRequest
{
    public Guid Id { get; set; }
}