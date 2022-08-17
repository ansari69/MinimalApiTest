using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services,
                    IConfiguration configuration)
        {
            //Fluent Validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
  
           //MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());     
        }

    }

}
