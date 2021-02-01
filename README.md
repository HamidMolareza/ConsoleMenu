# ConsoleMenu

## Minimum Requirements

- .NET Core 3.1
- C# 9

## Usage

### Quick Setup

```csharp
var selectedItem = new RadioMenu()
    .AddText(new TextItem("Title"))
    .AddSeparation(new SeparationItem("-"))
    .AddItem(new RadioItem("Item-1"))
    .AddItem(new RadioItem("Item-2"))
    .AddSeparation()
    .AddItem(new RadioItem("Cancel"))
    .Run();

Console.WriteLine($"Selected item: {selectedItem.Text}");
```

## LICENSE

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT). :)