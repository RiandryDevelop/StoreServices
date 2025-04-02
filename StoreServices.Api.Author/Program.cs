using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreServices.Api.Author.Application;
using StoreServices.Api.Author.Persistence;
using System.Net.NetworkInformation;
using System.Reflection;

namespace StoreServices.Api.Author
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuración de la carga de settings (orden importa)
            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets<Program>() // <-- Habilita los secretos en desarrollo
                .AddEnvironmentVariables();

            // Configurar DbContext con cadena de conexión desde secrets
            builder.Services.AddDbContext<AuthorContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseNpgsql(connectionString);
            });

            // Servicios
            builder.Services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });
            builder.Services.AddControllers();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(New.Handler).Assembly));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Middlewares
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
