using ArtExchange.Modules.ArtMeetings.Application.Abstractions.Data;
using ArtExchange.Modules.ArtMeetings.Domain.Meetings;
using Microsoft.EntityFrameworkCore;

namespace ArtExchange.Modules.ArtMeetings.Infrastructure.DataAccess;

public sealed class MeetingsDbContext(DbContextOptions<MeetingsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Meeting> Meetings { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Meetings);
    }
}
