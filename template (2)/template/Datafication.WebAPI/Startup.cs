using Datafication.Repositories.Contexts;
using Datafication.Repositories.Implementations;
using Datafication.Repositories.Interfaces;
using Datafication.Services.Implementations;
using Datafication.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Datafication.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<DataficationDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly("Datafication.WebAPI"));
            });

            services.AddTransient<IManufacturerService, ManufacturerService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IIceCreamService, IceCreamService>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IIceCreamRepository, IceCreamRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Datafication.WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Datafication.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
