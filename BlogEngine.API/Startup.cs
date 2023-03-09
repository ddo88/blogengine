using BlogEngine.API.DbContexts;
using BlogEngine.API.Entities;
using BlogEngine.API.Services;
using BlogEngine.Core;
using BlogEngine.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Text;

namespace BlogEngine.API
{
    public class Startup
    {
        private ConfigurationManager configuration;

        public Startup(ConfigurationManager configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo() { Title = "BlogEngine API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                // Define the BearerAuth scheme that's in use
                options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });

            services.AddDbContext<BlogEngineContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("Default"))
            );
            services.AddIdentity<User, Role>()
                            .AddEntityFrameworkStores<BlogEngineContext>()
                            .AddDefaultTokenProviders();

            services.AddScoped<UserManager<User>>();
            services.AddScoped<RoleManager<Role>>();

            var t = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name.StartsWith("BlogEngine")).ToList();
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name.StartsWith("BlogEngine")).ToList());
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IPublishService, PublishService>();


            services.AddAuthentication( options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme             = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(options =>
            {
                options.SaveToken                   = true;
                options.RequireHttpsMetadata        = false;
                options.TokenValidationParameters   = new TokenValidationParameters
                {
                    ValidateIssuer      = true,
                    ValidateAudience    = true,
                    ValidAudience       = configuration["Jwt:Audience"],
                    ValidIssuer         = configuration["Jwt:Issuer"],
                    IssuerSigningKey    = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"]))
                };
            });
            services.AddAuthorization();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserSession, UserSession>();
            
        }


        public void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

    }
}
