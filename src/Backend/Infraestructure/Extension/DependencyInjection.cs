using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infraestructure.Extension
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Este es un "Método de Extensión", (this) extiende el IServiceCollection.
        /// Le "enseña" al IServiceCollection (el 'builder.Services' del Program.cs)
        /// un nuevo método llamado 'AddInfrastructure'.
        /// </summary>
        /// <param name="services">El 'builder.Services' que nos pasa el Program.cs</param>
        /// <param name="configuration">La configuración de la app (para leer el appsettings.json)</param>
        /// <param name="environment">Es el entorno en el que se está ejecutando la aplicación</param>
        /// <returns>El mismo IServiceCollection, para poder encadenar llamadas.</returns>
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration
            , IHostEnvironment environment)
        {
            // 1. LEEMOS LA CONFIGURACIÓN:
            // Le pedimos al 'configuration' (que nos pasó Program.cs)
            // la cadena de conexión.
            var connectionString = configuration
                .GetConnectionString("DefaultConnection");

            // 2. CONFIGURAMOS EL DbContext:
            // registramos el servicio ApplicationDbContext en el contenedor

            if (environment.IsDevelopment())
            {
                services.AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlite(connectionString)
                        .LogTo(Console.WriteLine, LogLevel.Information));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(connectionString));
            }

            // Devolvemos 'services' para que Program.cs pueda seguir
            // registrando otras cosas (ej: .AddApplication())
            return services;
        }
    }
}