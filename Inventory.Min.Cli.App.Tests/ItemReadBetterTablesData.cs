using Inventory.Min.Data;

namespace Inventory.Min.Cli.App.Tests;

public class ItemReadBetterTablesData
    : ItemReadData
{
    private const int Quantity = 1;
    private const int CategoryId = 1;
    private const string PurchaseDate = "22.08.2022";

    public new static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetItem(
                    (item) => item.Description = Description
                    , (item) => item.Quantity = Quantity
                    , (item) => item.CategoryId = CategoryId
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 22)
                ) 
                , GetInsCmd("-d", Description, "-q", Quantity.ToString(), "-c", CategoryId.ToString(), "-p", PurchaseDate)
            }
        };

    public new static IEnumerable<object[]> Read01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetReadCmd()
                ,    "┌{idcol}┬──────────────────┬──────────────────────────┬──────────┬────────────┬──────────────┐\r\n"
                +   $"│ \u001b[38;2;255;255;255m {nameof(Item.Id)} \u001b[0m │"
                +   $" \u001b[38;2;255;255;255m      {nameof(Item.Name)}      \u001b[0m │"
                +   $" \u001b[38;2;255;255;255m       {nameof(Item.Description)}      [0m │"
                +   $" [38;2;255;255;255m{nameof(Item.Quantity)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.CategoryId)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.PurchaseDate)}[0m │"
                +    "\r\n"
                +    "├{idcol}┼──────────────────┼──────────────────────────┼──────────┼────────────┼──────────────┤\r\n"
                +   $"│ \u001b[38;2;255;255;255m{{id}}\u001b[0m │"
                +   $" \u001b[38;2;255;255;255m{Name}\u001b[0m │"
                +   $" \u001b[38;2;255;255;255m{Description}[0m │"
                +   $" [38;2;255;255;255m    {Quantity}   [0m │"
                +   $" [38;2;255;255;255m     {CategoryId}    [0m │"
                +   $" [38;2;255;255;255m {PurchaseDate} [0m │"
                +    "\r\n"
                +    "└{idcol}┴──────────────────┴──────────────────────────┴──────────┴────────────┴──────────────┘\r\n"
            }
        };
}