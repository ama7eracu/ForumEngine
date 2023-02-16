using AutoMapper;
using ForumEngine.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ForumEngine.Application.Topic.Queries.GetAllSectionTopics;

public class GetAllSectionTopicsQueryHandler:IRequestHandler<GetAllSectionTopicsQuery,GetAllSectionTopicsVm>
{
    private readonly IForumEngineDbContext _context;
    private readonly IMapper _mapper;

    public GetAllSectionTopicsQueryHandler(IForumEngineDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<GetAllSectionTopicsVm> Handle(GetAllSectionTopicsQuery request, 
        CancellationToken cancellationToken)
    {
        var topicsList = await _context.Topics.Where(Topic =>
            Topic.SectionId == request.SectionId).ToListAsync(cancellationToken);

        var topicListDto = topicsList.Select(topic =>
            _mapper.Map<GetAllSectionTopicsDto>(topic)).ToList();

        return new GetAllSectionTopicsVm {Topics = topicListDto};
    }
}