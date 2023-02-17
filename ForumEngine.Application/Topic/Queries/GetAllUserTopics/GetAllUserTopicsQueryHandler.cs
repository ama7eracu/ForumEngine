using AutoMapper;
using ForumEngine.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ForumEngine.Application.Topic.Queries.GetAllUserTopics;

public class GetAllUserTopicsQueryHandler : IRequestHandler<GetAllUserTopicsQuery, GetAllUserTopicsVm>
{
    private readonly IForumEngineDbContext _context;
    private readonly IMapper _mapper;

    public GetAllUserTopicsQueryHandler(IForumEngineDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _mapper = mapper;
    }


    public async Task<GetAllUserTopicsVm> Handle(GetAllUserTopicsQuery request, CancellationToken cancellationToken)
    {
        var topics = await _context.Topics.Where(topic => topic.AuthorId == request.UserId)
            .ToListAsync(cancellationToken);

        var topicsDto = topics.Select(topic =>
            _mapper.Map<GetAllUserTopicsDto>(topic)).ToList();

        return new GetAllUserTopicsVm {Topics = topicsDto};
    }
}