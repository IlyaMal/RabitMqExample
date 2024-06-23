using Microsoft.EntityFrameworkCore;
using ProducerService.DAL.Models;

namespace ProducerService.DAL;

public class DbHelper: DbContext
{
    public DbSet<UserModel> Users { get; set; } = null!;
    public DbHelper()
    {
        Database.EnsureCreated();
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=RabbitTest;Username=postgres;Password=Vomber123");
    }
}