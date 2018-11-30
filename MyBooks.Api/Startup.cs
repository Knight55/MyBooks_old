using System;
using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyBooks.Bll.Context;
using MyBooks.Bll.Services;
using MyBooks.Api.Mapping;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace MyBooks.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyBookContext>(options =>
            {
                options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                    .UseLoggerFactory(new LoggerFactory().AddConsole());
            });

            services.AddSingleton(MapperConfig.Configure());
            services.AddTransient<IBookService, BookService>();

            services.AddMvc(o => o.MaxModelValidationErrors = 50)
                .AddJsonOptions(json => json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new Info
                {
                    Title = "MyBooks API",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Email = "toth.dani9204@gmail.com",
                        Name = "Daniel Toth"
                    }
                });
                o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "MyBooks.Api.xml"));
                o.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MyBookContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();

            app.UseStatusCodePages();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyBooks API v1"));
            
            //context.RemoveAll();
            context.Seed();
        }
    }
}
