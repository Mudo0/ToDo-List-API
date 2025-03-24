using Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Extension
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    c => c.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });
            return services;
        }
    }
}