using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ASP.NET.Data;
using ASP.NET.Repositories;
using XamarinFormsWithWebApi2.Controllers;

namespace XamarinFormsWithWebApi2
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
            
            var connection = @"Server=(localdb)\mssqllocaldb;Database=MyRecipesDatabase;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<RecipeContext>
                (options => options.UseSqlServer(connection));


            services.AddScoped<IRecipesRepository, RecipesRepository>();
            

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
                {
                    routes.MapRoute("default", "{controller=RecipeCore}/{action=Index}/{id?}");
                });

      


        }
    }
}
