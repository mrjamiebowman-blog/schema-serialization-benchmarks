using System.Linq.Expressions;
using System.Reflection;
using Attribute = System.Attribute;

namespace MrJB.SchemaSerialization.Benchmarks.Helpers;

public static class AttributeHelper
{
    public static TOut GetPropertyAttributeValue<T, TOut, TAttribute>(
        T obj,
        Expression<Func<TAttribute, TOut>> propertyExpression
        )
        where T : class
        where TAttribute : Attribute
    {
        var attr = obj.GetType().GetCustomAttributes(typeof(TAttribute)).SingleOrDefault(x => x is TAttribute) as TAttribute;
        var propertyInfo = ((MemberExpression)propertyExpression.Body).Member as PropertyInfo;
        var value = propertyInfo.GetValue(attr, null);
        return value != null ? (TOut)value :  default(TOut);
    }
}
