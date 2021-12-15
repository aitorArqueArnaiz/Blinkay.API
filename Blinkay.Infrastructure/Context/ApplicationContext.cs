using Blinkay.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public ApplicationContext() : base()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }


}