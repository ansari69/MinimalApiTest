using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalApiExample.Application.Common.Interfaces;
using MinimalApiExample.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //DbContext
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                   configuration.GetConnectionString("AppConnectionString"),
                   m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });








        }

    }

}
