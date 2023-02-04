using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
  public class AppDbContext:DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<ClassName> tbManagements { get; set; }
    public DbSet<Fees> tbFinances { get; set; }
    public DbSet<Mapping> tbFacilities { get; set; }
    public DbSet<Payment> sample { get; set; }
    public DbSet<Registration> payment { get; set; }
  }
}
