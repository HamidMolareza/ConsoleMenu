using System;
using System.Collections.Generic;
using Core.Items;

namespace Core.Extensions
{
    public static class RadioItemExtensions
    {
        public static int FindSelectedId(this IReadOnlyList<RadioItem> radioItems, int currentSelectedId,
            ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.DownArrow:
                    return FindNextActiveItem(radioItems, currentSelectedId);
                case ConsoleKey.UpArrow:
                    return FindPrevActiveItem(radioItems, currentSelectedId);
                default:
                    return currentSelectedId;
            }
        }

        public static int FindNextActiveItem(this IReadOnlyList<RadioItem> radioItems, int currentId)
        {
            for (var i = currentId + 1; i < radioItems.Count; i++)
            {
                if (!radioItems[i].IsDisable)
                    return i;
            }

            return currentId;
        }

        public static int FindPrevActiveItem(this IReadOnlyList<RadioItem> radioItems, int currentId)
        {
            for (var i = currentId - 1; i >= 0; i--)
            {
                if (!radioItems[i].IsDisable)
                    return i;
            }

            return currentId;
        }

        public static void InitIds(this IReadOnlyList<RadioItem> radioItems)
        {
            for (var i = 0; i < radioItems.Count; i++)
                radioItems[i].Id = i;
        }
    }
}