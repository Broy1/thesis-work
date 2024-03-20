using DemoSalesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FilterManagerPortal.Data
{
    public class TagsDbContext : DbContext
    {
        public TagsDbContext(DbContextOptions<TagsDbContext> options) : base(options)
        {

        }

        public DbSet<CategoryTag> CategoryTags { get; set; }

        public DbSet<SubCategoryTag> SubCategoryTags { get; set; }

        public DbSet<SpecTag> SpecTags { get; set; }
    }
}
