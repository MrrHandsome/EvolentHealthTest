using EvolentHealthTest.DbContexts;
using EvolentHealthTest.Extensions.Api;
using EvolentHealthTest.Interface;
using EvolentHealthTest.Models;
using EvolentHealthTest.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace EvolentHealthTest
{
    public class Startup
    {
        public IWebHostEnvironment HostingEnvironment { get; }
        private AppSettings AppSetting;
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.Configure<AppSettings>(Configuration);
            AppSetting = GetAppSettings(services);
            services.AddControllers();

            services
               .AddUserSwagger(AppSetting)
               .AddControllers();

            var sqlConnectionString = AppSetting.DatabaseConfiguration.DatabaseConnectionString(HostingEnvironment.IsProduction());
            services.AddDbContext<EvolentHealthDatabaseContext>(options => options.UseSqlServer(sqlConnectionString));
            services.AddTransient<IContactRepository, ContactRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EvolentHealthTest", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EvolentHealthTest v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private AppSettings GetAppSettings(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider.GetService<IOptions<AppSettings>>().Value;
        }
    }
}
