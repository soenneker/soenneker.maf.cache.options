using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Dictionaries.Singletons;
using Soenneker.Maf.Cache.Options.Abstract;
using Soenneker.Maf.Dtos.Options;

namespace Soenneker.Maf.Cache.Options;

/// <inheritdoc cref="IMafOptionsCache"/>
public sealed class MafOptionsCache : IMafOptionsCache
{
    private readonly SingletonDictionary<MafOptions, Func<ValueTask<MafOptions>>> _options;

    public MafOptionsCache()
    {
        _options = new SingletonDictionary<MafOptions, Func<ValueTask<MafOptions>>>((key, factory, token) => factory());
    }

    public ValueTask<MafOptions> Get(string key, Func<ValueTask<MafOptions>> optionsFactory, CancellationToken cancellationToken = default)
    {
        return _options.Get(key, optionsFactory, cancellationToken);
    }

    public ValueTask<bool> Remove(string key)
    {
        return _options.Remove(key);
    }

    public ValueTask<Dictionary<string, MafOptions>> GetAll(CancellationToken cancellationToken = default)
    {
        return _options.GetAll(cancellationToken);
    }

    public ValueTask Clear(CancellationToken cancellationToken = default)
    {
        return _options.Clear(cancellationToken);
    }

    public ValueTask DisposeAsync()
    {
        return _options.DisposeAsync();
    }
}
