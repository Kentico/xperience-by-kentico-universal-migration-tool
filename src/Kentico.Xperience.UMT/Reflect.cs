using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Reflection;

namespace Kentico.Xperience.UMT;

internal class Reflect<T>
{
    static Reflect()
    {
        var instance = Reflect.Type(typeof(T));
        Current = instance.Current;
        PublicProperties = instance.PublicProperties;
        PropertyGetters = instance.PropertyGetters;
    }

#pragma warning disable S2743 // that is the idea, for each type parameter reflected info will exist
    // ReSharper disable once StaticMemberInGenericType
    public static ImmutableHashSet<PropertyInfo> PublicProperties { get; set; }
    // ReSharper disable once StaticMemberInGenericType
    private static ImmutableDictionary<string, MethodInfo?> PropertyGetters { get; set; }
    // ReSharper disable once StaticMemberInGenericType
    private static Type Current { get; }
#pragma warning restore S2743

    public object? GetPropertyValue(string propertyName, object o)
    {
        if (PropertyGetters.TryGetValue(propertyName, out var getter) && getter != null)
        {
            return getter.Invoke(o, Array.Empty<object?>());
        }

        throw new KeyNotFoundException($"Public property '{propertyName}' is not present on type '{Current.FullName}'");
    }
}

internal class Reflect
{
    private static readonly ConcurrentDictionary<Type, Reflect> instances = new();

    public static Reflect Type(Type type) =>
        instances.GetOrAdd(type, c =>
        {
            var publicProperties = c.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToImmutableHashSet();
            var propertyGetters = c.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToImmutableDictionary(x => x.Name, x => x.GetMethod);

            return new Reflect(current: c, publicProperties: publicProperties, propertyGetters: propertyGetters);
        });

    public ImmutableDictionary<string, MethodInfo?> PropertyGetters { get; }
    public ImmutableHashSet<PropertyInfo> PublicProperties { get; }
    public Type Current { get; }

    private Reflect(Type current, ImmutableHashSet<PropertyInfo> publicProperties, ImmutableDictionary<string, MethodInfo?> propertyGetters)
    {
        Current = current;
        PublicProperties = publicProperties;
        PropertyGetters = propertyGetters;
    }
}
