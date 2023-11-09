using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using User.Data.DBO;

namespace User.Data.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly IConfiguration _configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(_configuration.GetConnectionString("NoDatabase")),
            options =>
            {
                options.UseNetTopologySuite();
            });
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDBO>().HasKey(x => x.Id);
    }
    
    public DbSet<UserDBO> Activities { get; set; } = null!;
}