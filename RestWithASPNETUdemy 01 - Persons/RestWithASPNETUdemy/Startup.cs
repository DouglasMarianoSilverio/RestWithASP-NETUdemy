using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Business.Implementation;
using RestWithASPNETUdemy.Context;
using RestWithASPNETUdemy.HyperMedia;
using RestWithASPNETUdemy.Repository.Generic;
using System;
using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace RestWithASPNETUdemy
{
    public class Startup
    {
        public ILogger<Startup> _logger;
        public IConfiguration _configuration { get; }
        public IHostEnvironment _enviroment { get; }


        public Startup(IConfiguration configuration, IHostEnvironment enviroment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _enviroment = enviroment;
            _logger = logger;
            
            
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services )
        {
            var connectionString = _configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));
            
            if( _enviroment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    var evolver = new Evolve.Evolve(evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations", "db/datasets" },
                        IsEraseDisabled = true,
                    };
                    evolver.Migrate();

                }
                catch (Exception ex)
                {

                    _logger.LogCritical("Data migration failed");
                    throw;
                }

            }
            
            
            services.AddControllers();

            services.AddApiVersioning();

            services.AddMvc(options =>
           {
               options.RespectBrowserAcceptHeader = true;
               options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
               options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
           }).AddXmlSerializerFormatters();

            services.AddSwaggerGen( c => 
            {
                // c.SwaggerDoc("v1", new Info { });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RESTFul API with Asp.Net Core 3.1", Version = "v1" });
            });

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new PersonEnricher());
            services.AddSingleton(filterOptions);


            //depency injection
            services.AddScoped<IPersonBusiness, PersonBusiness>();
            services.AddScoped<IBookBusiness, BookBusiness>();
            
            //services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","My API V1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(name: "DefaultApi",
                  pattern: "{controller=Values}/{id?}");

            });

            
        }
    }
}
