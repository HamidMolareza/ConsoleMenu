# ConsoleMenu

## Minimum Requirements

- .NET Core 3.1
- C# 9

## Usage

### Quick Setup

```csharp
var selectedItem = new RadioMenu()
    .AddText("Title")
    .AddSeparation("-")
    .AddItem("Item-1", isDisable: true)
    .AddItem("Item-2")
    .AddSeparation()
    .AddItem("Cancel")
    .Run();

Console.WriteLine($"Selected ID: {selectedItem?.Id}");
```

## LICENSE

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT). :)