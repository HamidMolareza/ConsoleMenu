using System;
using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
using Core.Items;

namespace Core.Menus
{
    public class RadioMenu : Menu
    {
        private const string Circle = "\u25CB";
        private const string BlackCircle = "\u25CF";

        public RadioMenu(ConsoleColor? defaultBackgroundColor = null, ConsoleColor? defaultTextColor = null,
            ConsoleColor? activeItemBackgroundColor = null, ConsoleColor activeItemTextColor = ConsoleColor.Blue,
            ConsoleColor? defaultDescriptionBackgroundColor = null,
            ConsoleColor defaultDescriptionTextColor = ConsoleColor.Gray,
            int leftMarginOfMenu = 0, int rightMarginOfMenu = 0,
            int defaultLeftMarginOfItems = 0, int defaultRightMarginOfItems = 4) : base(defaultBackgroundColor,
            defaultTextColor, activeItemBackgroundColor, activeItemTextColor, defaultDescriptionBackgroundColor,
            defaultDescriptionTextColor, leftMarginOfMenu, rightMarginOfMenu, defaultLeftMarginOfItems,
            defaultRightMarginOfItems)
        {
        }

        public RadioMenu AddText(TextItem textItem)
        {
            Items.Add(textItem);
            return this;
        }

        public RadioMenu AddText(string text, ConsoleColor? backgroundTextColor = null,
            ConsoleColor? textColor = null, int? leftMargin = 0, int? rightMargin = 0) =>
            AddText(new TextItem(text, backgroundTextColor, textColor, leftMargin, rightMargin));

        public RadioMenu AddSeparation(string separator = " ", ConsoleColor? backgroundColor = null,
            ConsoleColor? textColor = null, int? leftMargin = 0, int? rightMargin = 0) =>
            AddSeparation(new SeparationItem(separator, backgroundColor, textColor, leftMargin, rightMargin));

        public RadioMenu AddSeparation(SeparationItem separationItem)
        {
            Items.Add(separationItem);
            return this;
        }

        public RadioMenu AddItem(RadioItem radioItem)
        {
            Items.Add(radioItem);
            return this;
        }

        public RadioMenu AddItem(string text, ConsoleColor? backgroundTextColor = null,
            ConsoleColor? textColor = null, bool isDisable = false,
            int? leftMargin = 0, int? rightMargin = 0) =>
            AddItem(new RadioItem(text, backgroundTextColor, textColor, isDisable, leftMargin, rightMargin));

        public RadioMenu AddItems(IEnumerable<RadioItem> radioItems)
        {
            foreach (var radioItem in radioItems)
                Items.Add(radioItem);

            return this;
        }

        public RadioItem? Run()
        {
            var radioItems = Items.GetItems<RadioItem>().ToList();
            radioItems.InitIds();
            ResetColors();

            var selectedId = radioItems.FindNextActiveItem(-1);
            var maxWidth = Items.GetMaxWidth(DefaultLeftMarginOfItems, DefaultRightMarginOfItems);
            do
            {
                Console.Clear(); //○ text    text    text
                PrintItems(Items, selectedId, maxWidth);

                if (!radioItems.Any())
                    return null;

                do
                {
                    var consoleKey = Console.ReadKey(false).Key;
                    if (consoleKey == ConsoleKey.Enter)
                        return radioItems.Single(item => item.Id == selectedId);

                    var newSelectedId = radioItems.FindSelectedId(selectedId, consoleKey);
                    if (newSelectedId != selectedId)
                    {
                        selectedId = newSelectedId;
                        break;
                    }

                    Console.Beep();
                } while (true);
            } while (true);
        }

        private void PrintItems(IEnumerable<Item> items, int selectedId, int maxWidth)
        {
            foreach (var item in items)
                PrintWidthMargin(this, () => PrintItem(item, selectedId, maxWidth));

            ResetColors();
        }

        private void PrintItem(Item obj, int selectedId, int maxWidth)
        {
            switch (obj)
            {
                case RadioItem radioItem:
                    PrintWidthMargin(radioItem, () => Print(radioItem, radioItem.Id == selectedId));
                    break;
                case TextItem textItem:
                    PrintWidthMargin(textItem, () => Print(textItem));
                    break;
                case SeparationItem separatorItem:
                    PrintWidthMargin(separatorItem, () => Print(separatorItem, maxWidth));
                    break;
                default:
                    throw new NotImplementedException($"Type {obj.GetType()} is not implemented.");
            }

            Console.WriteLine();
        }

        private void Print(SeparationItem separationItem, int width)
        {
            SetColor(separationItem);

            var quotient = width / separationItem.Separator.Length;

            var remainder = width % separationItem.Separator.Length;
            remainder = remainder > width ? width : remainder;

            separationItem.Separator.Print(quotient);
            for (var i = 0; i < remainder; i++)
                Console.Write(separationItem.Separator[i]);
        }

        private void Print(RadioItem radioItem, bool isActive)
        {
            Action setColorAction = radioItem.IsDisable ? SetDisableItemColor :
                isActive ? SetActiveItemColor : () => SetColor(radioItem.TextItems.First());

            var circleType = radioItem.IsDisable || !isActive ? Circle : BlackCircle;

            Action printItems = radioItem.IsDisable || isActive
                ? () => PrintWidthMargin(radioItem.TextItems, false)
                : () => PrintWidthMargin(radioItem.TextItems);

            setColorAction();
            Console.Write($"{circleType} ");
            printItems();
        }

        private void Print(TextItem textItem, bool setColor = true)
        {
            if (setColor)
                SetColor(textItem);

            Console.Write(textItem.Text);
        }

        private void PrintWidthMargin(IEnumerable<TextItem> textItems, bool setColor = true)
        {
            foreach (var textItem in textItems)
                PrintWidthMargin(textItem, () => Print(textItem, setColor));
        }

        private void PrintWidthMargin(Obj obj, Action action)
        {
            var defaultLeftMargin = obj is Menu ? 0 : DefaultLeftMarginOfItems;
            var defaultRightMargin = obj is Menu ? 0 : DefaultRightMarginOfItems;

            " ".Print(obj.LeftMargin ?? defaultLeftMargin);
            action();
            " ".Print(obj.RightMargin ?? defaultRightMargin);
        }

        private void SetColor(SeparationItem separationItem)
        {
            Console.BackgroundColor = separationItem.BackgroundColor ?? DefaultBackgroundColor;
            Console.ForegroundColor = separationItem.TextColor ?? DefaultTextColor;
        }

        private void SetColor(TextItem textItem)
        {
            Console.BackgroundColor = textItem.BackgroundTextColor ?? DefaultBackgroundColor;
            Console.ForegroundColor = textItem.TextColor ?? DefaultTextColor;
        }

        private void SetDisableItemColor()
        {
            Console.BackgroundColor = DisableItemBackgroundColor;
            Console.ForegroundColor = DisableItemTextColor;
        }

        private void SetActiveItemColor()
        {
            Console.BackgroundColor = ActiveItemBackgroundColor;
            Console.ForegroundColor = ActiveItemTextColor;
        }

        private void ResetColors()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = DefaultBackgroundColor;
            Console.ForegroundColor = DefaultTextColor;
        }
    }
}