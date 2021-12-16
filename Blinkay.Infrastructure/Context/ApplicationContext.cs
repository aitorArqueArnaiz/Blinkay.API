using Blinkay.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Blinkay");

        modelBuilder.Entity<User>()
          .HasKey(b => b.iduser)

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> users { get; set; }


}