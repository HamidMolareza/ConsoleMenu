using System;
using System.Collections.Generic;
using Core.Items;
using Core.Menus;

namespace ConsoleApp
{
    public static class Program
    {
        public static void Main()
        {
           var result = new RadioMenu()
                .AddText(new TextItem("Title"))
                .AddSeparation()
                .AddText(new TextItem("Section-0"))
                .AddItems(new List<RadioItem>
                {
                    new ("item-0", "this is description"),
                    new ("item-1", "this is description"),
                    new ("item-2", "this is description")
                })
                .AddText(new TextItem("Section 1"))
                .AddItem(new RadioItem("text-1", "des-1"))
                .AddItem(new RadioItem("text-2", "des-2"))
                .AddSeparation(new SeparationItem(@"\/"))
                .AddText(new TextItem("Section 2"))
                .AddItem(new RadioItem("text-3", "des-3"))
                .AddItem(new RadioItem("text-4", "des-4"))
                .AddSeparation()
                .AddItem(new RadioItem("Cancel", "Exit from menu."))
                .Run();

           Console.WriteLine();
           Console.WriteLine($"Selected item: {result?.Text}");
        }
    }
}