using Inventory.Min.Data;

namespace Inventory.Min.Cli.App.Tests;

public class ItemReadBetterTablesData
    : ItemReadData
{
    public new static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetItem((item) => item.Description = Description) 
                , GetInsCmd("-d", Description)
            }
        };

    public new static IEnumerable<object[]> Read01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetReadCmd()
                ,    "┌{idcol}┬───────────┐\r\n"
                +   $"│ \u001b[38;2;250;250;210m {nameof(Item.Id)} \u001b[0m │ \u001b[38;2;0;128;0m   {nameof(Item.Name)}  \u001b[0m │\r\n"
                +    "├{idcol}┼───────────┤\r\n"
                +   $"│ \u001b[38;2;250;250;210m{{id}}\u001b[0m │ \u001b[38;2;0;128;0m{Name}\u001b[0m │\r\n"
                +    "└{idcol}┴───────────┘\r\n"
            }
        };
}