using System;

namespace Core.Items
{
    public class RadioItem
    {
        private string _text = null!;
        private string? _description;

        public long Id { get; set; }

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

        public string? Description
        {
            get => _description;
            set
            {
                if (value is not null && value.IsWhiteSpace())
                    throw new ArgumentException("Value can not be white space.", nameof(Description));
                _description = value;
            }
        }

        public ConsoleColor? BackgroundTextColor { get; set; }
        public ConsoleColor? TextColor { get; set; }

        public ConsoleColor? DescriptionBackgroundColor { get; set; }
        public ConsoleColor? DescriptionTextColor { get; set; }
        public bool IsDisable { get; set; } = false;

        public RadioItem(string text, string? description = null, ConsoleColor? backgroundTextColor = null,
            ConsoleColor? textColor = null, ConsoleColor? descriptionBackgroundColor = null,
            ConsoleColor? descriptionTextColor = null,
            bool isDisable = false)
        {
            Text = text;
            Description = description;
            BackgroundTextColor = backgroundTextColor;
            TextColor = textColor;
            DescriptionBackgroundColor = descriptionBackgroundColor;
            DescriptionTextColor = descriptionTextColor;
            IsDisable = isDisable;
        }
    }
}