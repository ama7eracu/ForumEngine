using Microsoft.EntityFrameworkCore;

namespace ForumEngine.Application.Interfaces;
using Domain;

public interface IForumEngineDbContext
{
    DbSet<Topic> Topics { get; set; }
    DbSet<Section> Sections { get; set; }
    DbSet<UserComment> UserComments { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}