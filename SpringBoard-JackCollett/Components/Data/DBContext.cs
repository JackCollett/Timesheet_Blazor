using Microsoft.EntityFrameworkCore;
using TimesheetNameSpace;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<TimesheetEntry> TimesheetEntries { get; set; }
}
