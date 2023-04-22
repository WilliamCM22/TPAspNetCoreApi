using Microsoft.EntityFrameworkCore;
using System.Data;
using TPAspNetCoreApi.Models;

namespace TPAspNetCoreApi.Data
{
    public class Magasin : DbContext
    {
        public static readonly ILoggerFactory loggerFactory
            = LoggerFactory.Create(builder => builder.AddSimpleConsole());

        public DbSet<Article> Article { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(Magasin.loggerFactory)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer("Server=.;Database=TPAspNetCoreApi;Encrypt=False;Trusted_Connection=True;");
        }
    }
}
