using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Data.Sqlite;

namespace Datafication.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var connectionStringBuilder = new SqliteConnectionStringBuilder();
            //connectionStringBuilder.DataSource = "../IceCreamDb.db";
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

            
    }
}
