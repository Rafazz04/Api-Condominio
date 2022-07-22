using Microsoft.EntityFrameworkCore;
using ApiNext.Model;

namespace ApiNext.Data
{
    public class DataContext : DbContext
    {
        //public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Condominio> Condominio { get; set; }
        public DbSet<Morador> Morador { get; set; }
        public DbSet<Familia> Familia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataContext"));
            }
        }

    }
}
