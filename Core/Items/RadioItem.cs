using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Items
{
    public class RadioItem
    {
        private List<TextItem> _textItems = null!;
        public int Id { get; set; }

        public List<TextItem> TextItems
        {
            get => _textItems;
            set => _textItems = value ?? new List<TextItem>();
        }

        public bool IsDisable { get; set; } = false;

        public RadioItem(string text, ConsoleColor? backgroundTextColor = null,
            ConsoleColor? textColor = null, bool isDisable = false)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(text));

            TextItems = new List<TextItem>();
            IsDisable = isDisable;
            AddText(new TextItem(text, backgroundTextColor, textColor));
        }

        public RadioItem(List<TextItem> textItems, bool isDisable = false)
        {
            if (textItems is null || !textItems.Any())
                throw new ArgumentException("Value can not be null or empty.", nameof(textItems));
            TextItems = textItems;
            IsDisable = isDisable;
        }

        public RadioItem AddText(TextItem textItem)
        {
            TextItems.Add(textItem);
            return this;
        }
    }
}