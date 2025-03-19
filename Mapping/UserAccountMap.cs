using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Models;

namespace TaskManager.Data.Mapping;

public class UserAccountMap : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        // Table
        builder.ToTable("UserAccounts");

        // Column 'Id'
        builder.Property(x => x.Id)
        .HasColumnName("Id")
        .HasColumnType("INT")
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();

        // Column 'Name'
        builder.Property(x => x.Name)
        .HasColumnName("Name")
        .HasColumnType("NVARCHAR(100)")
        .IsRequired();

        // Column 'Login'
        builder.Property(x => x.Login)
        .HasColumnName("Login")
        .HasColumnType("NVARCHAR(50)")
        .IsRequired();

        // Column 'Login' as Unique
        builder.HasIndex(x => x.Login, "Unique_UserAccount_Login")
        .IsUnique();

        // Column 'Password'
        builder.Property(x => x.Password)
        .HasColumnName("Password")
        .HasColumnType("NVARCHAR(50)")
        .IsRequired();

        // Column 'Email'
        builder.Property(x => x.Email)
        .HasColumnName("Email")
        .HasColumnType("NVARCHAR(100)")
        .IsRequired();

        // Column 'Email' as Unique
        builder.HasIndex(x => x.Email, "Unique_UserAccount_Email")
        .IsUnique();

        // Column 'PhoneNumber'
        builder.Property(x => x.PhoneNumber)
        .HasColumnName("PhoneNumber")
        .HasColumnType("NVARCHAR(20)")
        .IsRequired();

        // Column 'PhoneNumber' as Unique
        builder.HasIndex(x => x.PhoneNumber, "Unique_UserAccount_PhoneNumber")
        .IsUnique();

        // Column 'CreatedOn'
        builder.Property(x => x.CreatedOn)
        .HasColumnName("CreatedOn")
        .HasColumnType("SMALLDATETIME")
        .IsRequired();

        // Column 'CreatedOn'
        builder.Property(x => x.CreatedOn)
        .HasColumnName("CreatedOn")
        .HasColumnType("SMALLDATETIME")
        .IsRequired();

        // Column 'BirthDate'   
        builder.Property(x => x.BirthDate)
        .HasColumnName("BirthDate")
        .HasColumnType("SMALLDATETIME")
        .IsRequired();

        // Column 'AcessLevel'
        builder.Property(x => x.AcessLevel)
        .HasColumnName("AcessLevel")
        .HasColumnType("INT")
        .HasDefaultValue(1)
        .IsRequired();

        // Column 'Active'
        builder.Property(x => x.Active)
        .HasColumnName("Active")
        .HasColumnType("BIT")
        .HasDefaultValue(true)
        .IsRequired();

    }
}