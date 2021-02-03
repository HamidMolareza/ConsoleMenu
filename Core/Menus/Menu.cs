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
        private int _topMargin;
        private int _bottomMargin;

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

        public int TopMargin
        {
            get => _topMargin;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(TopMargin));
                _topMargin = value;
            }
        }

        public int BottomMargin
        {
            get => _bottomMargin;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(BottomMargin));
                _bottomMargin = value;
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
            int leftMarginOfMenu = 0, int rightMarginOfMenu = 0, int defaultLeftMarginOfItems = 0,
            int defaultRightMarginOfItems = 4, 
             int topMargin = 0, int bottomMargin = 0)
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
            
            TopMargin = topMargin;
            BottomMargin = bottomMargin;
        }
    }
}