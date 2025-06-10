using Microsoft.EntityFrameworkCore;
using SpringBoard_JackCollett.Components;
using TimesheetNameSpace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=timesheets.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
    DbInitializer.Seed(db);
}

app.Run();

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {

        if (!context.TimesheetEntries.Any())
        {
            context.TimesheetEntries.AddRange(
                new TimesheetEntry { Employee = 101, Today = new DateOnly(2025, 6, 1), Hours = 8, Job = 123 },
                new TimesheetEntry { Employee = 102, Today = new DateOnly(2025, 6, 1), Hours = 6, Job = 456 },
                new TimesheetEntry { Employee = 101, Today = new DateOnly(2025, 6, 2), Hours = 8, Job = 789 }
            );

            context.SaveChanges();
        }
    }
}