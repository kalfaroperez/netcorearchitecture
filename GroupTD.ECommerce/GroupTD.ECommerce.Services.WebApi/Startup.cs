using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupTD.ECommerce.Application.Interface;
using GroupTD.ECommerce.Application.Main;
using GroupTD.ECommerce.Transversal.Mapper;
using GroupTD.ECommerce.Transversal.Common;
using GroupTD.ECommerce.Domain.Interface;
using GroupTD.ECommerce.Domain.Core;
using GroupTD.ECommerce.Insfraestructure.Data;
using GroupTD.ECommerce.Infraestructure.Interface;
using GroupTD.ECommerce.Infraestructure.Repository;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;

namespace GroupTD.ECommerce.Services.WebApi
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
            services.AddControllers();
            services.AddAutoMapper(x=> x.AddProfile(new MappingProfile()));
            
            
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConnectionFactory,ConnectionFactory>();

            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
                    Title = "Grupo TD Api Market",
                    Version = "v1",
                    Description = "A simple example ASP.Net Core Web API",
                    TermsOfService = new Uri("https://example.com"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Kennys Alfaro",
                        Email = "kalfaro@yopmail.com",
                        Url = new Uri("https://www.//google.com"),
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense { 
                        Name = "MIT",
                        Url = new Uri("https://example.com/license")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddMvc();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My e-Commerce Api v1");
            });
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
