using System.Collections.Generic;
using System.Linq;
using Core.Items;

namespace Core.Extensions
{
    public static class ItemExtensions
    {
        public static int GetMaxWidth(this IEnumerable<Item> items, int defaultLeftMargin, int defaultRightMargin) =>
            items.Select(item => item.GetWidth(defaultLeftMargin, defaultRightMargin)).Max();
    }
}