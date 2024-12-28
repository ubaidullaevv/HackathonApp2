using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Hackathon> Hackathons { get; set; }
    public DbSet<Team>  Teams { get; set; }
    public DbSet<Participant> Participants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Hackathon>()
      .HasMany(h=>h.Teams)
      .WithOne(t=>t.Hackathon)
      .HasForeignKey(t=>t.HackathonId);

      modelBuilder.Entity<Team>()
      .HasMany(t=>t.Participants)
      .WithOne(p=>p.Team)
      .HasForeignKey(p=>p.TeamId);
    }

}

