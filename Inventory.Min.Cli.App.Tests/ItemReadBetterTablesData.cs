using Inventory.Min.Data;

namespace Inventory.Min.Cli.App.Tests;

public class ItemReadBetterTablesData
    : ItemReadData
{
    private const int Quantity = 1;

    public new static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetItem(
                    (item) => item.Description = Description
                    , (item) => item.Quantity = Quantity
                ) 
                , GetInsCmd("-d", Description, "-q", Quantity.ToString())
            }
        };

    public new static IEnumerable<object[]> Read01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetReadCmd()
                ,    "┌{idcol}┬──────────────────┬──────────────────────────┬──────────┐\r\n"
                +   $"│ \u001b[38;2;250;250;210m {nameof(Item.Id)} \u001b[0m │ \u001b[38;2;0;128;0m      {nameof(Item.Name)}      \u001b[0m │ \u001b[38;2;220;20;60m       {nameof(Item.Description)}      [0m │ [38;2;255;0;0mQuantity[0m │\r\n"
                +    "├{idcol}┼──────────────────┼──────────────────────────┼──────────┤\r\n"
                +   $"│ \u001b[38;2;250;250;210m{{id}}\u001b[0m │ \u001b[38;2;0;128;0m{Name}\u001b[0m │ \u001b[38;2;220;20;60m{Description}[0m │ [38;2;255;0;0m    1   [0m │\r\n"
                +    "└{idcol}┴──────────────────┴──────────────────────────┴──────────┘\r\n"
            }
        };
}