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
        PropertySetters = instance.PropertySetters;
    }

#pragma warning disable S2743 // that is the idea, for each type parameter reflected info will exist
    // ReSharper disable once StaticMemberInGenericType
    public static ImmutableHashSet<PropertyInfo> PublicProperties { get; set; }
    // ReSharper disable once StaticMemberInGenericType
    private static ImmutableDictionary<string, MethodInfo?> PropertyGetters { get; set; }
    // ReSharper disable once StaticMemberInGenericType
    public static Type Current { get; }
    // ReSharper disable once StaticMemberInGenericType
    private static ImmutableDictionary<string, MethodInfo?> PropertySetters { get; set; }
#pragma warning restore S2743

    public object? GetPropertyValue(string propertyName, object o)
    {
        if (PropertyGetters.TryGetValue(propertyName, out var getter) && getter != null)
        {
            return getter.Invoke(o, Array.Empty<object?>());
        }

        throw new KeyNotFoundException($"Public property '{propertyName}' is not present on type '{Current.FullName}'");
    }

    public static bool TrySetProperty(object o, string propertyName, object? value)
    {
        if (PropertySetters.TryGetValue(propertyName, out var setter) && setter != null)
        {
            setter.Invoke(o, new[] { value });
            return true;
        }

        return false;
    }
}

internal class Reflect
{
    private static readonly ConcurrentDictionary<Type, Reflect> instances = new();

    public static Reflect Type(Type type) =>
        instances.GetOrAdd(type, c =>
        {
            var propertyInfos = c.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).ToList();
            var publicProperties = propertyInfos.ToImmutableHashSet();
            var propertyGetters = propertyInfos.ToImmutableDictionary(x => x.Name, x => x.GetMethod);
            var propertySetters = propertyInfos.ToImmutableDictionary(x => x.Name, x => x.SetMethod);
            
            return new Reflect(current: c, publicProperties: publicProperties, propertyGetters: propertyGetters, propertySetters: propertySetters);
        });

    public ImmutableDictionary<string, MethodInfo?> PropertyGetters { get; }
    public ImmutableDictionary<string, MethodInfo?> PropertySetters { get; }
    public ImmutableHashSet<PropertyInfo> PublicProperties { get; }
    public Type Current { get; }

    private Reflect(Type current, ImmutableHashSet<PropertyInfo> publicProperties, ImmutableDictionary<string, MethodInfo?> propertyGetters, ImmutableDictionary<string, MethodInfo?> propertySetters)
    {
        Current = current;
        PublicProperties = publicProperties;
        PropertyGetters = propertyGetters;
        PropertySetters = propertySetters;
    }
}
