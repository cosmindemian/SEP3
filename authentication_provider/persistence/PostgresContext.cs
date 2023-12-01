
using persistance.Config;
using Microsoft.EntityFrameworkCore;
using persistance.Entity;

namespace persistance;

public class PostgresContext : DbContext
{
    public DbSet<Credential> Credentials { set; get; }
    public DbSet<EmailVerificationCode> EmailVerificationCodes { set; get; }
    public DbSet<Role> Roles { set; get; }

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
        modelBuilder.Entity<Credential>() //sets the email of Credential as unique
            .HasIndex(cr => cr.Email)
            .IsUnique();
        modelBuilder.Entity<Role>() //sets the name of Role as unique
            .HasIndex(r => r.Name)
            .IsUnique();
        modelBuilder.Entity<Credential>()
            .HasOne(e=>e.EmailVerificationCode)
            .WithOne(e => e.Credential)
            .HasForeignKey<EmailVerificationCode>( e=> e.CredentialId)
            .IsRequired(false);
            
    }
}