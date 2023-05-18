using Microsoft.EntityFrameworkCore;
using Packages;

namespace API.Context
{
    public class DataDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings

            options.UseSqlServer(Configuration.GetConnectionString("Packages"));
        }
        public DbSet<Items> items { get; set; }
    }
}
