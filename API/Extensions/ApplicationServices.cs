using API.Data;
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
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}