using Microsoft.EntityFrameworkCore;
using WimabEventApp.Models;

namespace WimabEventApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Event> Events => Set<Event>();
    public DbSet<WishlistItem> WishlistItems => Set<WishlistItem>();
    public DbSet<Invitation> Invitations => Set<Invitation>();
}