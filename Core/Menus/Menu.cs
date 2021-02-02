using System;
using System.Collections.Generic;
using Core.Items;

namespace Core.Menus
{
    public abstract class Menu : Obj
    {
        private List<Item> _items = new();
        private int _defaultLeftMarginOfItems;
        private int _defaultRightMarginOfItems;

        public ConsoleColor DefaultBackgroundColor { get; set; }
        public ConsoleColor DefaultTextColor { get; set; }

        public ConsoleColor ActiveItemBackgroundColor { get; set; }
        public ConsoleColor ActiveItemTextColor { get; set; }

        public ConsoleColor DisableItemBackgroundColor { get; set; }
        public ConsoleColor DisableItemTextColor { get; set; }

        public int DefaultLeftMarginOfItems
        {
            get => _defaultLeftMarginOfItems;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(DefaultLeftMarginOfItems));
                _defaultLeftMarginOfItems = value;
            }
        }

        public int DefaultRightMarginOfItems
        {
            get => _defaultRightMarginOfItems;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(DefaultRightMarginOfItems));
                _defaultRightMarginOfItems = value;
            }
        }

        public List<Item> Items
        {
            get => _items;
            protected set => _items = value ?? new List<Item>();
        }

        protected Menu(ConsoleColor? defaultBackgroundColor = null, ConsoleColor? defaultTextColor = null,
            ConsoleColor? activeItemBackgroundColor = null, ConsoleColor activeItemTextColor = ConsoleColor.Blue,
            ConsoleColor? disableItemBackgroundColor = null, ConsoleColor disableItemTextColor = ConsoleColor.DarkGray,
            int leftMarginOfMenu = 0, int rightMarginOfMenu = 0, int defaultLeftMarginOfItems = 0, int defaultRightMarginOfItems = 4)
        {
            DefaultBackgroundColor = defaultBackgroundColor ?? Console.BackgroundColor;
            DefaultTextColor = defaultTextColor ?? Console.ForegroundColor;

            ActiveItemBackgroundColor = activeItemBackgroundColor ?? DefaultBackgroundColor;
            ActiveItemTextColor = activeItemTextColor;

            DisableItemBackgroundColor = disableItemBackgroundColor ?? DefaultBackgroundColor;
            DisableItemTextColor = disableItemTextColor;

            LeftMargin = leftMarginOfMenu;
            RightMargin = rightMarginOfMenu;

            DefaultLeftMarginOfItems = defaultLeftMarginOfItems;
            DefaultRightMarginOfItems = defaultRightMarginOfItems;
        }
    }
}