using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Maf.Cache.Options;
using Soenneker.Maf.Cache.Options.Abstract;

namespace Soenneker.Maf.Cache.Options.Registrars;

/// <summary>
/// Providing async thread-safe singleton Microsoft Agent Framework Options instances.
/// </summary>
public static class MafOptionsCacheRegistrar
{
    /// <summary>
    /// Adds <see cref="IMafOptionsCache"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddMafOptionsCacheAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IMafOptionsCache, MafOptionsCache>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IMafOptionsCache"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddMafOptionsCacheAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IMafOptionsCache, MafOptionsCache>();

        return services;
    }
}
