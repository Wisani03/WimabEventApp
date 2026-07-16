using Microsoft.EntityFrameworkCore;
using WimabEventApp.Data;

var builder = WebApplication.CreateBuilder(args);

//SQLite database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=wimab_event.db"));

var app = builder.Build();

app.MapGet("/", () => "Wimab Holdings Event API is running!");

app.Run();