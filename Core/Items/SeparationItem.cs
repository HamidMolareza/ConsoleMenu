using System;

namespace Core.Items
{
    public class SeparationItem
    {
        private string _separator;

        public string Separator
        {
            get => _separator;
            set => _separator = value is null! || value == "" ? " " : value;
        }

        public ConsoleColor? BackgroundColor { get; set; }
        public ConsoleColor? TextColor { get; set; }

        public SeparationItem(string separator = " ", ConsoleColor? backgroundColor = null,
            ConsoleColor? textColor = null)
        {
            _separator = separator;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
        }
    }
}