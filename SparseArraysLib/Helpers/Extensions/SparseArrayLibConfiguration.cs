using Microsoft.Extensions.DependencyInjection;
using SparseArraysLib.Modules.Business;
using SparseArraysLib.Modules.Business.Interfaces;
using SparseArraysLib.Modules.CRUD;
using SparseArraysLib.Modules.CRUD.Interfaces;

namespace SparseArraysLib.Helpers.Extensions
{
    public static class SparseArrayLibConfiguration
    {
        public static IServiceCollection ConfigureSparseArraysLibServices(this IServiceCollection services)
        {
            services.AddScoped<IStringsCollector, StringsCollector>();
            services.AddScoped<IStringMatcher, StringMatcher>();
            services.AddScoped<IMainUserInterface, MainUserInterface>();

            return services;
        }
    }
}
