using FilterManagerPortal.Areas.Identity.Data;
using FilterManagerPortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterManagerPortal.Areas.Identity.Data;

public class FimaDbContext : IdentityDbContext<FimaUser>
{
    public FimaDbContext(DbContextOptions<FimaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Filter> Filters { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserConfiguration());
    }
}

internal class ApplicationUserConfiguration : IEntityTypeConfiguration<FimaUser>
{
    public void Configure(EntityTypeBuilder<FimaUser> builder)
    {
        builder.Property(u => u.UserName).IsRequired();
    }
}