using System;

namespace Core.Items
{
    public class TextItem
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

        public TextItem(string text, ConsoleColor? backgroundTextColor = null, ConsoleColor? textColor = null)
        {
            Text = text;
            BackgroundTextColor = backgroundTextColor;
            TextColor = textColor;
        }
    }
}