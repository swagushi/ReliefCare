using AidCare_The_Rise_Of_The_Aid.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AidCare_The_Rise_Of_The_Aid.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AidCare_The_Rise_Of_The_Aid.Areas.Identity.Data;

public class AidCareContext : IdentityDbContext<AidCareUser>
{
    public AidCareContext(DbContextOptions<AidCareContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

    public DbSet<AidCare_The_Rise_Of_The_Aid.Models.member>? member { get; set; }

    public DbSet<AidCare_The_Rise_Of_The_Aid.Models.donation>? donation { get; set; }

    public DbSet<AidCare_The_Rise_Of_The_Aid.Models.protest>? protest { get; set; }

}

internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<AidCareUser>
{
    public void Configure(EntityTypeBuilder<AidCareUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}