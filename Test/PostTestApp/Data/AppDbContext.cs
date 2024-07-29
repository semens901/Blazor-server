using Microsoft.EntityFrameworkCore;
using PostTestApp.Model;

namespace PostTestApp.Data
{
    public class AppDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlite(Configuration.GetConnectionString("DatabaseConnectionString"));
        }

        public DbSet<Car> Cars { get; set; }
    }
}