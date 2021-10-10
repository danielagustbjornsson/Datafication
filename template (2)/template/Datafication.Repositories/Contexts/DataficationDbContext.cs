using Datafication.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
//using Microsoft.EntityFrameworkCore.Sqlite;

namespace Datafication.Repositories.Contexts
{
    public class DataficationDbContext : DbContext
    {
        public DataficationDbContext()
        {
        }

        public DataficationDbContext(DbContextOptions<DataficationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<IceCream> IceCreams { get; set; }

        private const string ConnectionString = "Data Source=./IceCreamDb.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This is using MSSQL database, but is different based on the database underneath.
            // Could be PostgreSQL, MySQL, CosmoDB, etc==.
            optionsBuilder.UseSqlite(ConnectionString);
        }




    }
}