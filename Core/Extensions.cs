using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public static class Extensions
    {
        public static bool IsWhiteSpace(this string @this) =>
            @this.All(char.IsWhiteSpace);

        public static IEnumerable<T> GetItems<T>(this IEnumerable<object> items) =>
            items.Where(item => item.GetType() == typeof(T))
                .Select(item => (T) item);
    }
}