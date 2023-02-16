using AutoMapper;
using ForumEngine.Domain;

namespace ForumEngine.Application.UserComments.Queries.GetAllComments;

public class AllCommentsTopicMapperProfile : Profile
{
    public AllCommentsTopicMapperProfile()
    {
        CreateMap<GetAllCommentsTopicDto, UserComment>().ReverseMap();
    }
}