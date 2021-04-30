using CompanyName.MyAppName.DataAccess;
using CompanyName.MyAppName.DataAccess.Repositories;
using CompanyName.MyAppName.Domain.Services;
using CompanyName.MyAppName.WebApi.Common;
using CompanyName.MyAppName.WebApi.Common.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace CompanyName.MyAppName.WebApi
{
    /// <summary>
    /// Provides various members to handle startup activities of the application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => options.EnableEndpointRouting = false);

            // Get project settings from appsettings.
            var sectionProjectSettings = Configuration.GetSection("ProjectSettings");
            var projectSettings = sectionProjectSettings.Get<ProjectSettings>();
            services.Configure<ProjectSettings>(options => sectionProjectSettings.Bind(options));

            // Jwt authentication settings.
            services.AddAuthentication
                    (options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = projectSettings.JwtIssuer,
                            ValidAudience = projectSettings.JwtIssuer,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(projectSettings.JwtSecretKey))
                        };
                    });



            // Set formatter json/xml.
            services.AddMvc()
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Add global filters.
            services.AddMvc(config => config.Filters.Add(typeof(CustomExceptionFilter)));

            // pass connection string to db context.
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Configure Automapper
            services.AddAutoMapper(typeof(Domain.MappingProfiles.MappingProfile));

            // Mapping application db context.
            services.AddScoped<DbContext, AppDbContext>();

            // Mapping unit of work.
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Mapping repositories.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Mapping Services.
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute("Default", "api/{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
