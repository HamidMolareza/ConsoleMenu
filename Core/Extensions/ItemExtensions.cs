using System.Collections.Generic;
using System.Linq;
using Core.Items;

namespace Core.Extensions
{
    public static class ItemExtensions
    {
        public static int GetMaxWidth(this IEnumerable<Item> items) =>
            items.Select(item => item.MaxWidth).Max(); //TODO: ***
    }
}