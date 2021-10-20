using app.Models;
using app.Models.Contexts;
using app.Repositories;
using app.Repositories.Implementations;
using app.Requests;
using app.Responses;
using app.Services;
using app.Services.Implementations;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace app
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
            
            // Inject config DB
            var connection = Configuration.GetConnectionString(nameof(ApplicationDbContext));
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connection));
            services.AddScoped<DbContext, ApplicationDbContext>();
            
            // Inject service and repository
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();
            
            // Mapper
            AutoMapperConfig(services);
            
            // Version Controller
            services.AddApiVersioning();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AutoMapperConfig(IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<PersonRequest, Person>();
                config.CreateMap<Person, PersonResponse>();
            });
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
