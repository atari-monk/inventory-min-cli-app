using Inventory.Min.BetterTable;
using Inventory.Min.Data;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class ReadDefaultItemTableData
    : ReadMyItemTableData
{
    private const int CategoryId = 1;
    private const string CategoryName = "Food";

    public new static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetItem(
                    (item) => item.Description = Description
                    , (item) => item.CategoryId = CategoryId
                    ) 
                , GetInsCmd(
                    "-d", Description
                    , "-c", CategoryId.ToString())
            }
        };

    public new static IEnumerable<object[]> Read01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetReadCmd("-t", nameof(DefaultItemTableTest))
                ,    "┌──────────────────┬──────────────────────────┬──────────┐\r\n│"
                +   $" \u001b[38;2;255;255;255m      {nameof(Item.Name)}      \u001b[0m │"
                +   $" \u001b[38;2;255;255;255m       {nameof(Item.Description)}      [0m │"
                +   $" \u001b[38;2;255;255;255m{nameof(Item.Category)}[0m │"
                +    "\r\n"
                +    "├──────────────────┼──────────────────────────┼──────────┤\r\n│"
                +   $" \u001b[38;2;255;255;255m{Name}\u001b[0m │"
                +   $" \u001b[38;2;255;255;255m{Description}[0m │"
                +   $" \u001b[38;2;255;255;255m  {CategoryName}  [0m │"
                +    "\r\n"
                +    "└──────────────────┴──────────────────────────┴──────────┘\r\n"
            }
        };
}