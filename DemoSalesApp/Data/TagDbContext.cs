using DemoSalesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoSalesApp.Data
{
    public class TagDbContext : DbContext
    {
        public TagDbContext(DbContextOptions<TagDbContext> options) : base(options)
        {

        }

        public DbSet<CategoryTag> CategoryTags { get; set; }
        public DbSet<SubCategoryTag> SubCategoryTags { get; set; }
        public DbSet<SpecTag> SpecTags { get; set; }
    }
}
