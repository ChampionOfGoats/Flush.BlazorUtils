using Microsoft.Extensions.DependencyInjection;

namespace Flush.BlazorUtils
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds an ILocalStorage implementation to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The service collection with local storage added.</returns>
        public static IServiceCollection UseLocalStorage(this IServiceCollection services)
        {
            return services.AddScoped<ILocalStorage, LocalStorage>();
        }

        /// <summary>
        /// Adds an ISessionStorage implementation to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The service collection with session storage added.</returns>
        public static IServiceCollection UseSessionStorage(this IServiceCollection services)
        {
            return services.AddScoped<ISessionStorage, SessionStorage>();
        }
    }
}
