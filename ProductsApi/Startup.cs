using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BandQ.Commons.DAL.Interfaces;
using BandQ.Commons.Services;
using BandQ.DAL;
using BandQ.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.Reflection;
using ProductsApi.Middleware;
using Microsoft.AspNetCore.Http;
using ProductsApi.Filters;

namespace ProductsApi
{
    public class Startup
    {

        private static void HandleSpelling(IApplicationBuilder app)
        {
            app.Run(async context => { await context.Response.WriteAsync("incorrect spelling"); });
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc("v2", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Products", Description ="Swagger for products api"});
                //c.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "SwaggerSample.xml"));
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
            services.AddDbContext<Context>(x => x.UseSqlServer(Configuration.GetConnectionString("BandQConnection")));
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddMvcOptions(x => 
                {
                    x.Filters.Add(new TLSDetection());
                    x.Filters.Add(new UserCheck());
                });
            services.AddTransient<IProductService, ProductsService>();
            services.AddTransient<IGenericRepository, GenericRepository<Context>>();
            services.AddSingleton<TLSDetection>();
            services.AddSingleton<UserCheck>();
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

            //app.Run(async context => { await context.Response.WriteAsync("<HTML> <body> <h1> EXAMS OVER!!!! </h1> </body> </html>"); });
            app.Map("/api/produts", HandleSpelling);
            app.Map("/api/proucts", HandleSpelling);
            app.Map("/api/prducts", HandleSpelling);
            app.Map("/api/poducts", HandleSpelling);
            app.Map("/api/roducts", HandleSpelling);
            //app.UseMiddlewareLanguage();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "BandQ product API");
            });
        }

    }
}
