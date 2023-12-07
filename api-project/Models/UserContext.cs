using Microsoft.EntityFrameworkCore;
namespace Api.Models;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<WorkoutContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

}