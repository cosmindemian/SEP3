using grpc.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using persistance.Entity;

namespace persistance;

public class PostgresContext : DbContext
{
    public DbSet<Credential> Credentials { set; get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql($"Host={DatabaseConfig.Host}" +
                                 $";Database={DatabaseConfig.Database};" +
                                 $"Username={DatabaseConfig.Name};" +
                                 $"Password={DatabaseConfig.Password}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("authentication_provider");
        //set the email of Credential as unique
        modelBuilder.Entity<Credential>()
            .HasIndex(cr => cr.Email)
            .IsUnique();
    }
}