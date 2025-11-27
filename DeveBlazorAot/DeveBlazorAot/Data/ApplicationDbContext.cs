using Microsoft.EntityFrameworkCore;

namespace DeveBlazorAot.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CounterClick> CounterClicks { get; set; }
}
