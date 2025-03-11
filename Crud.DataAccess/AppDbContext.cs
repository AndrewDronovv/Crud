using Crud.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<Note> Notes { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>().HasKey(n => n.Id);
        modelBuilder.Entity<Note>().Property(n => n.Text).HasMaxLength(140);
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<DateTime>().HaveColumnType("timestamp without time zone");
        configurationBuilder.Properties<DateTime?>().HaveColumnType("timestamp with time zone");
    }
}
