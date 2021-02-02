using System;
using System.Collections.Generic;
using System.Linq;
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
            ConsoleColor defaultDescriptionTextColor = ConsoleColor.Gray) : base(defaultBackgroundColor,
            defaultTextColor, activeItemBackgroundColor, activeItemTextColor, defaultDescriptionBackgroundColor,
            defaultDescriptionTextColor)
        {
        }

        public RadioMenu AddText(TextItem textItem)
        {
            Items.Add(textItem);
            return this;
        }

        public RadioMenu AddText(string text, ConsoleColor? backgroundTextColor = null,
            ConsoleColor? textColor = null) =>
            AddText(new TextItem(text, backgroundTextColor, textColor));

        public RadioMenu AddSeparation() =>
            AddSeparation(new SeparationItem());

        public RadioMenu AddSeparation(string separator) =>
            AddSeparation(new SeparationItem(separator));

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
            ConsoleColor? textColor = null, bool isDisable = false) =>
            AddItem(new RadioItem(text, backgroundTextColor, textColor, isDisable));

        public RadioMenu AddItems(IEnumerable<RadioItem> radioItems)
        {
            foreach (var radioItem in radioItems)
                Items.Add(radioItem);

            return this;
        }

        public RadioItem? Run()
        {
            var radioItems = Items.GetItems<RadioItem>().ToList();
            InitIds(radioItems);
            ResetColors();

            var selectedId = FindNextActiveItem(radioItems, -1);
            do
            {
                Console.Clear();
                PrintItems(Items, selectedId);

                if (!radioItems.Any())
                    return null;

                do
                {
                    var consoleKey = Console.ReadKey(false).Key;
                    if (consoleKey == ConsoleKey.Enter)
                        return radioItems.Single(item => item.Id == selectedId);

                    var newSelectedId = FindSelectedId(radioItems, selectedId, consoleKey);
                    if (newSelectedId != selectedId)
                    {
                        selectedId = newSelectedId;
                        break;
                    }

                    Console.Beep();
                } while (true);
            } while (true);
        }

        private static void InitIds(IReadOnlyList<RadioItem> radioItems)
        {
            for (var i = 0; i < radioItems.Count; i++)
                radioItems[i].Id = i;
        }

        private void PrintItems(IEnumerable<object> items, int selectedId)
        {
            foreach (var item in items)
                PrintItem(item, selectedId);

            ResetColors();
        }

        private void PrintItem(object item, int selectedId)
        {
            var itemType = item.GetType();
            if (itemType == typeof(RadioItem))
            {
                Print((RadioItem) item, selectedId);
            }
            else if (itemType == typeof(TextItem))
            {
                Print((TextItem) item, "\n");
            }
            else if (itemType == typeof(SeparationItem))
            {
                Print((SeparationItem) item);
            }
            else
            {
                throw new NotImplementedException($"Type {itemType} is not implemented.");
            }
        }

        private void Print(SeparationItem separationItem)
        {
            SetColor(separationItem);
            for (var i = 0; i < 20; i++) //TODO: ***
                Console.Write(separationItem.Separator);
            Console.WriteLine();
        }

        private void Print(RadioItem radioItem, int selectedId)
        {
            var isActive = radioItem.Id == selectedId;

            Action setColorAction = radioItem.IsDisable ? SetDisableItemColor :
                isActive ? SetActiveItemColor : () => SetColor(radioItem.TextItems.First());

            var circleType = radioItem.IsDisable || !isActive ? Circle : BlackCircle;

            const string separator = "        "; //TODO: ****
            Action printItems = radioItem.IsDisable || isActive
                ? () => PrintTextItems(radioItem.TextItems, separator, false)
                : () => PrintTextItems(radioItem.TextItems, separator);

            setColorAction();
            Console.Write($"{circleType} ");
            printItems();
            Console.WriteLine();
        }

        private void PrintTextItems(IEnumerable<TextItem> textItems, string separator, bool setColor = true)
        {
            foreach (var textItem in textItems)
                Print(textItem, separator, setColor);
        }

        private void Print(TextItem textItem, string separator, bool setColor = true)
        {
            if (setColor)
                SetColor(textItem);
            Console.Write(textItem.Text);
            Console.Write(separator);
        }

        private void SetColor(SeparationItem separationItem)
        {
            Console.BackgroundColor = separationItem.BackgroundColor ?? DefaultBackgroundColor;
            Console.ForegroundColor = separationItem.TextColor ?? DefaultTextColor;
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

        private void SetColor(TextItem textItem)
        {
            Console.BackgroundColor = textItem.BackgroundTextColor ?? DefaultBackgroundColor;
            Console.ForegroundColor = textItem.TextColor ?? DefaultTextColor;
        }

        private void ResetColors()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = DefaultBackgroundColor;
            Console.ForegroundColor = DefaultTextColor;
        }

        private static int FindSelectedId(IReadOnlyList<RadioItem> radioItems, int currentSelectedId,
            ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.DownArrow:
                    return FindNextActiveItem(radioItems, currentSelectedId);
                case ConsoleKey.UpArrow:
                    return FindPrevActiveItem(radioItems, currentSelectedId);
                default:
                    return currentSelectedId;
            }
        }

        private static int FindNextActiveItem(IReadOnlyList<RadioItem> radioItems, int currentId)
        {
            for (var i = currentId + 1; i < radioItems.Count; i++)
            {
                if (!radioItems[i].IsDisable)
                    return i;
            }

            return currentId;
        }

        private static int FindPrevActiveItem(IReadOnlyList<RadioItem> radioItems, int currentId)
        {
            for (var i = currentId - 1; i >= 0; i--)
            {
                if (!radioItems[i].IsDisable)
                    return i;
            }

            return currentId;
        }
    }
}