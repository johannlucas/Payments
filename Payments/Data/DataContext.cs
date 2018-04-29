using Microsoft.EntityFrameworkCore;
using Payments.Models;

namespace Payments.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Payment> Payment { get; set; }
    }
}
