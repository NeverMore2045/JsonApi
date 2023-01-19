using static System.Formats.Asn1.AsnWriter;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace JsonApi.Entity
{
    public class JsonApiDbContext : DbContext
    {
        public DbSet<KnownHost> KnownHosts { get; set; }
        public DbSet<Request> Requests { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключания
            option.UseNpgsql(configuration.GetConnectionString("JsonApiDb"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KnownHost>().ToTable("KnownHostee");
            modelBuilder.Entity<Request>().ToTable("Requestee");
        }
    }
}
