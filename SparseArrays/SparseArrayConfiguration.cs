using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SparseArrays
{
    public static class SparseArrayConfiguration
    {
        public static IServiceCollection ConfigureSparseArraysServices(this IServiceCollection services)
        {
            services.AddScoped<ISparseArrayLuncher, SparseArrayLuncher>();
            services.AddLogging(configure => configure.AddConsole()).AddTransient<SparseArraysProgram>();

            return services;
        }
    }
}
