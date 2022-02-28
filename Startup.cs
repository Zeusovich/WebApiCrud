using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using TestTaskWebApi.Context;
using TestTaskWebApi.Services;

namespace TestTaskWebApi
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // устанавливаем контекст данных
            services.AddDbContext<ContactContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost:8080")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            /*services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin",options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod()); 
            });*/

            services.AddControllersWithViews().AddNewtonsoftJson(options =>            
                options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver 
                = new DefaultContractResolver());
            

            services.AddControllers(); // используем контроллеры без представлений

            services.AddTransient<ContactService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options => options.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod().AllowCredentials());

            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
