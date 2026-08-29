[![](https://img.shields.io/nuget/v/soenneker.maf.cache.options.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.maf.cache.options/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.maf.cache.options/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.maf.cache.options/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.maf.cache.options.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.maf.cache.options/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.maf.cache.options/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.maf.cache.options/actions/workflows/codeql.yml)

# Soenneker.Maf.Cache.Options

A cache for `MafOptions` using a SingletonDictionary with support for keyed asynchronous creation.

## Install

```bash
dotnet add package Soenneker.Maf.Cache.Options
```

## Quick start

```csharp
using Soenneker.Maf.Cache.Options.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddMafOptionsCacheAsSingleton();
```

Adds `IMafOptionsCache` as a singleton service.

## What you get

- `IMafOptionsCache` — A cache for `MafOptions` using a SingletonDictionary with support for keyed asynchronous creation.
- `MafOptionsCacheRegistrar` — Providing async thread-safe singleton Microsoft Agent Framework Options instances.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IMafOptionsCache.Get(key, optionsFactory, cancellationToken)` | Gets an existing `MafOptions` from the cache, or creates and caches one using the provided factory. | The cached or newly created `MafOptions`. |
| `IMafOptionsCache.Remove(key)` | Removes an entry from the cache. | A task representing the asynchronous remove operation. |
| `IMafOptionsCache.GetAll(cancellationToken)` | Retrieves all cached `MafOptions` entries, keyed by their cache keys. | A dictionary of all keys and their corresponding `MafOptions` values. |
| `IMafOptionsCache.Clear(cancellationToken)` | Clears all entries from the cache. | A task representing the asynchronous clear operation. |
| `MafOptionsCacheRegistrar.AddMafOptionsCacheAsSingleton(services)` | Adds `IMafOptionsCache` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `MafOptionsCacheRegistrar.AddMafOptionsCacheAsScoped(services)` | Adds `IMafOptionsCache` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
