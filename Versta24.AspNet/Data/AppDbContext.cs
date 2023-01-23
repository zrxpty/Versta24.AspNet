using Microsoft.EntityFrameworkCore;
using Versta24.AspNet.Models;

namespace Versta24.AspNet.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
