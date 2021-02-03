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

        public SeparationItem(string separator = " ", ConsoleColor? backgroundColor = null,
            ConsoleColor? textColor = null, int? leftMargin = null, int? rightMargin = null)
        {
            _separator = separator;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
            LeftMargin = leftMargin;
            RightMargin = rightMargin;
        }
        
        public override int GetWidth(int defaultLeftMargin, int defaultRightMargin) =>
            Separator.Length + LeftMargin ?? defaultLeftMargin + RightMargin ?? defaultRightMargin;
    }
}