using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Extensions
{
    internal static class GeneralExtensions
    {
        public static bool IsWhiteSpace(this string @this) =>
            @this.All(char.IsWhiteSpace);

        public static IEnumerable<T> GetItems<T>(this IEnumerable<object> items) =>
            items.Where(item => item.GetType() == typeof(T))
                .Select(item => (T) item);

        public static void Print(this string str, int count)
        {
            for (var i = 0; i < count; i++)
                Console.Write(str);
        }
        
        public static void PrintWidthMargin(this string text, int leftMargin, int rightMargin)
        {
            " ".Print(leftMargin);
            Console.Write(text);
            " ".Print(rightMargin);
        }
    }
}