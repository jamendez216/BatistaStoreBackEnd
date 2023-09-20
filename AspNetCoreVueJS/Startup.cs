using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCoreVueJSBusiness.Access;
using NetCoreVueJSBusiness.Interfaces;
using NetCoreVueJSBusiness.Warehouse;
using NetCoreVueJSData.DataAccess;
using NetCoreVueJSData.DBContext;
using NetCoreVueJSData.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreVueJS
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<DBContextSys>(op => op.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductData, ProductData>();
            services.AddScoped<ICategoryData, CategoryData>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUsersData, UsersData>();
            services.AddCors(Options =>
                Options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("CorsPolicy");
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHttpsRedirection();
        }
    }
}
