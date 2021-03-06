using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Items
{
    public sealed class RadioItem : Item
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
            ConsoleColor? textColor = null, bool isDisable = false,
            int? leftMargin = 0, int? rightMargin = 0)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(text));

            TextItems = new List<TextItem>();
            IsDisable = isDisable;
            AddText(new TextItem(text, backgroundTextColor, textColor));
            LeftMargin = leftMargin;
            RightMargin = rightMargin;
        }

        public RadioItem(List<TextItem> textItems, bool isDisable = false,
            int? leftMargin = 0, int? rightMargin = 0)
        {
            if (textItems is null || !textItems.Any())
                throw new ArgumentException("Value can not be null or empty.", nameof(textItems));
            TextItems = textItems;
            IsDisable = isDisable;
            LeftMargin = leftMargin;
            RightMargin = rightMargin;
        }

        public RadioItem AddText(TextItem textItem)
        {
            TextItems.Add(textItem);
            return this;
        }

        public RadioItem AddText(string text, ConsoleColor? backgroundTextColor = null,
            ConsoleColor? textColor = null,int? leftMargin = null, int? rightMargin = null) =>
            AddText(new TextItem(text, backgroundTextColor, textColor,leftMargin, rightMargin));

        public override int GetWidth(int defaultLeftMargin, int defaultRightMargin)
        {
            var margin = (LeftMargin ?? defaultLeftMargin) + (RightMargin ?? defaultRightMargin);
            var itemsWidth = TextItems.Sum(textItem => textItem.GetWidth(defaultLeftMargin, defaultRightMargin));
            return margin + itemsWidth;
        }
    }
}