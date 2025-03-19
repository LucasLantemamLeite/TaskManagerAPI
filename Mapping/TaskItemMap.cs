using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Models;

namespace TaskManager.Data.Mapping;

public class TaskItemMap : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {

        // Table
        builder.ToTable("TaskItems");

        // Column 'TaskId'
        builder.Property(x => x.TaskId)
        .HasColumnName("TaskId")
        .HasColumnType("INT")
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();

        // Column 'Title'
        builder.Property(x => x.Title)
        .HasColumnName("Title")
        .HasColumnType("NVARCHAR(50)")
        .IsRequired();

        // Column 'Description'
        builder.Property(x => x.Description)
        .HasColumnName("Description")
        .HasColumnType("NVARCHAR(500)");

        // Column 'Done'
        builder.Property(x => x.Done)
        .HasColumnName("Done")
        .HasColumnType("BIT")
        .HasDefaultValue(false)
        .IsRequired();

        // Column 'CreatedOn'
        builder.Property(x => x.CreatedOn)
        .HasColumnName("CreatedOn")
        .HasColumnType("SMALLDATETIME")
        .IsRequired();

        // Column 'DeadLine'
        builder.Property(x => x.DeadLine)
        .HasColumnName("DeadLine")
        .HasColumnType("SMALLDATETIME");


        // Column 'CompletionDate'
        builder.Property(x => x.CompletionDate)
        .HasColumnName("CompletionDate")
        .HasColumnType("SMALLDATETIME");

        // Column 'UserId'
        builder.Property(x => x.UserId)
        .HasColumnName("UserId")
        .HasColumnType("INT")
        .IsRequired();

        // Inner Join 'UserId' and 'UserAccount'
        builder.HasOne(x => x.UserAccount)
        .WithMany(x => x.UserTasks)
        .HasForeignKey(x => x.UserId)
        .OnDelete(DeleteBehavior.Cascade);

    }
}