using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Mapping;
using TaskManager.Models;

namespace TaskManager.Context;

public class TaskManagerContext : DbContext
{
    public DbSet<UserAccount> UserAccounts { get; set; } // Add Context.'UserAccount' to Entity FrameWork
    public DbSet<TaskItem> TaskItems { get; set; } // Add Context.'TaskItems' to Entity FrameWork

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("server=localhost, 1433; database=TaskManager; User Id=sa; Password=Lucas1971!;TrustServerCertificate=True;"); // Connection String

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserAccountMap()); // Add Mapping 'UserAccountMap' to Migrations
        modelBuilder.ApplyConfiguration(new TaskItemMap()); // Add Mapping 'TaskItemMap' to Migrations
    }
}