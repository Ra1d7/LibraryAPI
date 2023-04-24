using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class ApiContext : DbContext
    {
        private readonly IConfiguration _config;

        public ApiContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Human> Humans { get; set; } = null;
        public DbSet<Customer> Customers { get; set; } = null;
        public DbSet<Item> Items { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Default"));
        }
    }
}
