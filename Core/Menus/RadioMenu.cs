using System;
using System.Collections.Generic;
using System.Linq;
using Core.Items;

namespace Core.Menus
{
    public class RadioMenu : Menu
    {
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

        public RadioMenu AddSeparation()
        {
            Items.Add(new SeparationItem());
            return this;
        }

        public RadioMenu AddSeparation(SeparationItem separationItem)
        {
            Items.Add(separationItem);
            return this;
        }

        public RadioMenu AddItem(RadioItem radioItem)
        {
            radioItem.Id = GetNextId();
            Items.Add(radioItem);
            return this;
        }

        private long GetNextId()
        {
            var items = Items.GetItems<RadioItem>().ToList();
            return items.Any() ? items.Last().Id + 1 : 0;
        }
        
        public RadioMenu AddItems(IEnumerable<RadioItem> radioItems)
        {
            var nextId = GetNextId();
            
            foreach (var radioItem in radioItems)
            {
                radioItem.Id = nextId;
                nextId++;
                Items.Add(radioItem);
            }
            
            return this;
        }

        public RadioItem? Run()
        {
            var radioItems = Items.GetItems<RadioItem>().ToList();
            var selectedId = radioItems.Any() ? radioItems.First().Id : 0;
            ResetColors();

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

                    var newSelectedId = SetSelectedKey(radioItems, selectedId, consoleKey);
                    if (newSelectedId != selectedId)
                    {
                        selectedId = newSelectedId;
                        break;
                    }

                    Console.Beep();
                } while (true);
            } while (true);
        }

        private void PrintItems(IEnumerable<object> items, long selectedId)
        {
            foreach (var item in items)
                PrintItem(item, selectedId);

            ResetColors();
        }

        private void PrintItem(object item, long selectedId)
        {
            var itemType = item.GetType();
            if (itemType == typeof(RadioItem))
            {
                var radioItem = (RadioItem) item;
                SetColor(radioItem, selectedId);
                var circleItem = radioItem.Id == selectedId ? "\u25CF" : "\u25CB";
                Console.Write($"{circleItem} ");
                Console.Write(radioItem.Text);

                Console.Write("        "); //TODO: ****

                SetDescriptionColor(radioItem, selectedId);
                Console.WriteLine(radioItem.Description);
            }
            else if (itemType == typeof(TextItem))
            {
                var textItem = (TextItem) item;
                SetColor(textItem);
                Console.WriteLine(textItem.Text);
            }
            else if (itemType == typeof(SeparationItem))
            {
                var separationItem = (SeparationItem) item;
                SetColor(separationItem);
                for (var i = 0; i < 20; i++) //TODO: ***
                    Console.Write(separationItem.Separator);
                Console.WriteLine();
            }
            else
            {
                throw new NotImplementedException($"Type {itemType} is not implemented.");
            }
        }

        private void SetColor(SeparationItem separationItem)
        {
            Console.BackgroundColor = separationItem.BackgroundColor ?? DefaultBackgroundColor;
            Console.ForegroundColor = separationItem.TextColor ?? DefaultTextColor;
        }

        private void SetColor(RadioItem radioItem, long selectedId)
        {
            Console.BackgroundColor =
                radioItem.Id == selectedId ? ActiveItemBackgroundColor : GetBackgroundColor(radioItem);
            Console.ForegroundColor = radioItem.Id == selectedId ? ActiveItemTextColor : GetTextColor(radioItem);
        }

        private void SetColor(TextItem textItem)
        {
            Console.BackgroundColor = textItem.BackgroundTextColor ?? DefaultBackgroundColor;
            Console.ForegroundColor = textItem.TextColor ?? DefaultTextColor;
        }

        private void SetDescriptionColor(RadioItem radioItem, long selectedId)
        {
            Console.BackgroundColor =
                radioItem.Id == selectedId ? ActiveItemBackgroundColor : GetDescriptionBackgroundColor(radioItem);
            Console.ForegroundColor =
                radioItem.Id == selectedId ? ActiveItemTextColor : GetDescriptionTextColor(radioItem);
        }

        private ConsoleColor GetBackgroundColor(RadioItem item) =>
            item.BackgroundTextColor ?? DefaultBackgroundColor;

        private ConsoleColor GetTextColor(RadioItem item) =>
            item.TextColor ?? DefaultTextColor;

        private ConsoleColor GetDescriptionBackgroundColor(RadioItem item) =>
            item.DescriptionBackgroundColor ?? DefaultDescriptionBackgroundColor;

        private ConsoleColor GetDescriptionTextColor(RadioItem item) =>
            item.DescriptionTextColor ?? DefaultDescriptionTextColor;

        private void ResetColors()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = DefaultBackgroundColor;
            Console.ForegroundColor = DefaultTextColor;
        }

        private static long SetSelectedKey(List<RadioItem> radioItems, long oldSelectedId, ConsoleKey consoleKey)
        {
            var index = radioItems.FindIndex(a => a.Id == oldSelectedId);
            switch (consoleKey)
            {
                case ConsoleKey.DownArrow:
                    index += 1;
                    break;
                case ConsoleKey.UpArrow:
                    index -= 1;
                    break;
                default:
                    return oldSelectedId;
            }

            if (index >= 0 && index < radioItems.Count)
                return radioItems[index].Id;

            return oldSelectedId;
        }
    }
}