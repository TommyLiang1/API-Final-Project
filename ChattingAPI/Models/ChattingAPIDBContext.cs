using Microsoft.EntityFrameworkCore;
using ChattingAPI.Models;

namespace ChattingAPI.Models
{
    public class ChattingAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ChattingAPIDBContext(DbContextOptions<ChattingAPIDBContext> options, IConfiguration configuration) : base (options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("UserDataService");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<User> User { get; set; } = null!;
        public DbSet<Post> Post { get; set; } = null!;
    }
}
