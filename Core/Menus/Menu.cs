using System;
using System.Collections.Generic;

namespace Core.Menus
{
    public abstract class Menu
    {
        private List<object> _items = new();

        public ConsoleColor DefaultBackgroundColor { get; set; }
        public ConsoleColor DefaultTextColor { get; set; }

        public ConsoleColor ActiveItemBackgroundColor { get; set; }
        public ConsoleColor ActiveItemTextColor { get; set; }

        public ConsoleColor DisableItemBackgroundColor { get; set; }
        public ConsoleColor DisableItemTextColor { get; set; }

        public List<object> Items
        {
            get => _items;
            protected set => _items = value ?? new List<object>();
        }

        protected Menu(ConsoleColor? defaultBackgroundColor = null, ConsoleColor? defaultTextColor = null,
            ConsoleColor? activeItemBackgroundColor = null, ConsoleColor activeItemTextColor = ConsoleColor.Blue,
            ConsoleColor? disableItemBackgroundColor = null, ConsoleColor disableItemTextColor = ConsoleColor.DarkGray)
        {
            DefaultBackgroundColor = defaultBackgroundColor ?? Console.BackgroundColor;
            DefaultTextColor = defaultTextColor ?? Console.ForegroundColor;

            ActiveItemBackgroundColor = activeItemBackgroundColor ?? DefaultBackgroundColor;
            ActiveItemTextColor = activeItemTextColor;

            DisableItemBackgroundColor = disableItemBackgroundColor ?? DefaultBackgroundColor;
            DisableItemTextColor = disableItemTextColor;
        }
    }
}