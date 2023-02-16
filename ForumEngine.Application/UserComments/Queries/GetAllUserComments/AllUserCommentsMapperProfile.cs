using AutoMapper;
using ForumEngine.Application.UserComments.Queries.GetAllComments;
using ForumEngine.Domain;

namespace ForumEngine.Application.UserComments.Queries.GetAllUserComments;

public class AllUserCommentsMapperProfile:Profile
{
    public AllUserCommentsMapperProfile()
    {
        CreateMap<GetAllCommentsTopicDto, UserComment>().ReverseMap();
    }
}