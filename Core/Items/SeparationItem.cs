using System;

namespace Core.Items
{
    public sealed class SeparationItem : Item
    {
        private string _separator;

        public string Separator
        {
            get => _separator;
            set => _separator = value is null! || value == "" ? " " : value;
        }

        public ConsoleColor? BackgroundColor { get; set; }
        public ConsoleColor? TextColor { get; set; }

        public override int MaxWidth
        {
            get => Separator.Length;
            protected set { }
        }

        public SeparationItem(string separator = " ", ConsoleColor? backgroundColor = null,
            ConsoleColor? textColor = null, int? leftMargin = null, int? rightMargin = null)
        {
            _separator = separator;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
            LeftMargin = leftMargin;
            RightMargin = rightMargin;
        }
    }
}