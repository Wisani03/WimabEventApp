using Microsoft.EntityFrameworkCore;
using WimabEventApp.Models;

namespace WimabEventApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Guest> Guests => Set<Guest>();

    public DbSet<Gift> Gifts { get; set; }
}