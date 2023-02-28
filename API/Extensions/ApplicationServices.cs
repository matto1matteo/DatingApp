using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration config,
            IWebHostEnvironment environment
        )
        {
            services.AddCors();

            // Adding the service fot db and swagger
            if (environment.IsDevelopment())
            {
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                services.AddEndpointsApiExplorer();
                services.AddSwaggerGen();

                services.AddDbContext<DataContext>(opt =>
                {
                    // Connection string for the db from the app settings
                    opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
                });
            }

            // The code below is equivalent, but for the sake of dependency inversion, and thus
            // Liskov substitution principle, it's better to pass the interface and the implementation
            // expecially for testing purpose
            // services.AddScoped<TokenService>();
            // Token service
            services.AddScoped<ITokenService, TokenService>();
            // User repository service
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // Section of settings we added appsettings.json
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<LogUserActivity>();
            services.AddScoped<ILikesRepository, LikesRepository>();

            return services;
        }
    }
}