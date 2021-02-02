using System;

namespace Core.Items
{
    public sealed class TextItem : Item
    {
        private string _text = null!;

        public string Text
        {
            get => _text;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"Value can not be null ro white-space.", nameof(Text));
                _text = value;
            }
        }

        public ConsoleColor? BackgroundTextColor { get; set; }
        public ConsoleColor? TextColor { get; set; }

        public override int MaxWidth
        {
            get => Text.Length;
            protected set { }
        }

        public TextItem(string text, ConsoleColor? backgroundTextColor = null, ConsoleColor? textColor = null,
            int? leftMargin = null, int? rightMargin = null)
        {
            Text = text;
            BackgroundTextColor = backgroundTextColor;
            TextColor = textColor;
            LeftMargin = leftMargin;
            RightMargin = rightMargin;
        }
    }
}