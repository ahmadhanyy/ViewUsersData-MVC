using Microsoft.EntityFrameworkCore;
using myCompany.Models;

namespace myCompany.Data
{
    public class databaseContext : DbContext
    {
        public databaseContext(DbContextOptions<databaseContext> options) :base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }

    }
}
