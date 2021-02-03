# ConsoleMenu

## Minimum Requirements

- .NET Core 3.1
- C# 9

## Usage

### Quick Setup

![alt text](https://github.com/HamidMolareza/ConsoleMenu/blob/main/Images/basic-menu.png)

```csharp
var selectedItem = new RadioMenu()
    .AddText("Title: Basic Menu")
    .AddSeparation("=")
    .AddItem("Item-1")
    .AddItem("Item-2")
    .AddItem("Item-3")
    .AddSeparation()
    .AddItem("Cancel")
    .SetMarginAuto()
    .Run();

Console.WriteLine($"Selected ID: {selectedItem?.Id}");
```

## LICENSE

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT). :)