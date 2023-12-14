using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace Api.Models;

public class SwimLogContext(IConfiguration configuration) : DbContext
{
    private readonly IConfiguration configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conString = configuration.GetConnectionString("connString1");
        optionsBuilder.UseNpgsql(conString);
    }

    // public DbSet<User> Users { get; set; }
    public DbSet<Workout> Workouts { get; set; }

}