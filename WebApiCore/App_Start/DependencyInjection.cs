using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Repositroy;

namespace WebApiCore.App_Start
{
    public static class DependencyInjection
    {
        public static IServiceCollection SetupDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }

    }
}
