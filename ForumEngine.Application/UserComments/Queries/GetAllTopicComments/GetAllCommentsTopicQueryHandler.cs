using AutoMapper;
using ForumEngine.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ForumEngine.Application.UserComments.Queries.GetAllComments;

public class GetAllCommentsTopicQueryHandler : IRequestHandler<GetAllCommentsTopicQuery, AllCommentsTopicVm>
{
    private readonly IForumEngineDbContext _context;
    private readonly IMapper _mapper;

    public GetAllCommentsTopicQueryHandler(IForumEngineDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AllCommentsTopicVm> Handle(GetAllCommentsTopicQuery request, CancellationToken cancellationToken)
    {
        var CommentsList = await _context.UserComments.Where(comment =>
            comment.TopicId == request.TopicId).ToListAsync(cancellationToken);

        var CommentListDtos = CommentsList.Select(comment =>
            _mapper.Map<GetAllCommentsTopicDto>(comment)).ToList();

        return new AllCommentsTopicVm {Comments = CommentListDtos};
    }
}