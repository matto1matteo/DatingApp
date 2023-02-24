using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // Represets tables
        public DbSet<AppUser> Users { get; set; }
        // Do not need to add here the photo db set beacuse it is implicit from 
        // the AppUser class
    }
}