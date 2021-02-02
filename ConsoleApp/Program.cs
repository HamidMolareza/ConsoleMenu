using System;
using Core.Items;
using Core.Menus;

namespace ConsoleApp
{
    public static class Program
    {
        public static void Main()
        {
            Console.CursorVisible = false;
            var selectedItem = new RadioMenu()
                .AddText("Title")
                .AddSeparation("-")
                .AddItem("Item-1", isDisable: true)
                .AddItem("Item-2")
                .AddItem(new RadioItem("text")
                    .AddText("text")
                    .AddText("text", textColor: ConsoleColor.Gray))
                .AddSeparation()
                .AddItem("Cancel")
                .Run();

            Console.WriteLine($"Selected ID: {selectedItem?.Id}");
        }
    }
}