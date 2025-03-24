using Infraestructure.Data.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure

{
    public static class DependencyInjection
    {
        //cada método creado configura/agrega los servicios o dependencias que necesite
        public static IServiceCollection ConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        => services.AddInfraestructure(configuration);

        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDbContext(configuration);

            return services;
        }
    }
}