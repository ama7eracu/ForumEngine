namespace ForumEngine.Application.UserComments.Queries.GetAllComments;

public class GetAllCommentsTopicDto
{
    public string UserName { get; set; }
    public string Comment { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditTime { get; set; }
}