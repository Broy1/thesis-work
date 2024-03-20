using DemoSalesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoSalesApp.Data
{
    public class SalesAppDbContext : DbContext
    {
        public SalesAppDbContext(DbContextOptions<SalesAppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
