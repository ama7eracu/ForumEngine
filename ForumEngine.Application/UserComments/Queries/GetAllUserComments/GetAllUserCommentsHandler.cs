using AutoMapper;
using ForumEngine.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ForumEngine.Application.UserComments.Queries.GetAllUserComments;

public class GetAllUserCommentsHandler : IRequestHandler<GetAllUserCommentsQuery, GetAllUserCommentsVm>
{
    private readonly IForumEngineDbContext _context;
    private readonly IMapper _mapper;

    public GetAllUserCommentsHandler(IForumEngineDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetAllUserCommentsVm> Handle(GetAllUserCommentsQuery request, CancellationToken cancellationToken)
    {
        var CommentsList = await _context.UserComments.Where(comment =>
            comment.UserId == request.UserId).ToListAsync(cancellationToken);
        var CommentsListDto = CommentsList.Select(comment =>
            _mapper.Map<GetAllUserCommentsDto>(comment)).ToList();

        return new GetAllUserCommentsVm {UserComments = CommentsListDto};
    }
}