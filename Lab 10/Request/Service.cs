using Microsoft.EntityFrameworkCore;

namespace Request;

public class Ticker
{
    public int Id { get; set; }
    public string? ticker { get; set; }
}

public class Price
{
    public int tickerId { get; set; }
    public double price { get; set; }
    public string date { get; set; }
}

public class Condition
{
    public int tickerId { get; set; }
    public bool state { get; set; }
}

public sealed class ApplicationContext : DbContext
{
    
    public DbSet<Ticker> tickers { get; set; } = null!;
    public DbSet<Price> prices { get; set; } = null!;

    public DbSet<Condition> todayscondition { get; set; } = null!;
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=123qwe!@#QWE;database=ticker;", 
            new MySqlServerVersion(new Version(8, 0, 35)));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Condition>().HasKey("tickerId");
        modelBuilder.Entity<Price>().HasKey("tickerId");
        modelBuilder.Entity<Ticker>().HasKey("Id");
    }
}