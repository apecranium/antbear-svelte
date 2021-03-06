using Microsoft.EntityFrameworkCore;
using Svelte.Models;

namespace Svelte.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Pet> Pets { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Department> Departments { get; set; }
  }
}
