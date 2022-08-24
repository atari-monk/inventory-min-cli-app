using Inventory.Min.BetterTable;
using Inventory.Min.Data;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class ReadDefaultItemTableData
    : ReadMyItemTableData
{
    private const int CategoryId = 1;
    private const string CategoryName = "Food";
    private const int Quantity = 9;
    private const int Mass = 500;
    private const double Length = 34.5;
    private const double Heigth = 14.2;
    private const double Depth = 11.4;
    private const int StateId = 1;
    private const string StateName = "In storage";

    public new static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetItem(
                    (item) => item.Description = Description
                    , (item) => item.CategoryId = CategoryId
                    , (item) => item.Quantity = Quantity
                    , (item) => item.Mass = Mass
                    , (item) => item.Length = Length
                    , (item) => item.Heigth = Heigth
                    , (item) => item.Depth = Depth
                    , (item) => item.StateId = StateId
                    ) 
                , GetInsCmd(
                    "-d", Description
                    , "-c", CategoryId.ToString()
                    , "-q", Quantity.ToString()
                    , "--mass", Mass.ToString()
                    , "-l", Length.ToString()
                    , "-e", Heigth.ToString()
                    , "--depth", Depth.ToString()
                    , "-a", StateId.ToString()
                    )
            }
        };

    public new static IEnumerable<object[]> Read01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetReadCmd("-t", nameof(DefaultItemTableTest))
                ,    "┌──────────────────┬──────────────────────────┬──────────┬──────────┬──────┬────────┬────────┬───────┬────────────┐\r\n│"
                +   $" \u001b[38;2;255;255;255m      {nameof(Item.Name)}      \u001b[0m │"
                +   $" \u001b[38;2;255;255;255m       {nameof(Item.Description)}      [0m │"
                +   $" \u001b[38;2;255;255;255m{nameof(Item.Category)}[0m │"
                +   $" \u001b[38;2;255;255;255m{nameof(Item.Quantity)}[0m │"
                +   $" \u001b[38;2;255;255;255m{nameof(Item.Mass)}[0m │"
                +   $" \u001b[38;2;255;255;255m{nameof(Item.Length)}[0m │"
                +   $" \u001b[38;2;255;255;255m{nameof(Item.Heigth)}[0m │"
                +   $" \u001b[38;2;255;255;255m{nameof(Item.Depth)}[0m │"
                +   $" \u001b[38;2;255;255;255m   {nameof(Item.State)}  [0m │"
                +    "\r\n"
                +    "├──────────────────┼──────────────────────────┼──────────┼──────────┼──────┼────────┼────────┼───────┼────────────┤\r\n│"
                +   $" \u001b[38;2;255;255;255m{Name}\u001b[0m │"
                +   $" \u001b[38;2;255;255;255m{Description}[0m │"
                +   $" \u001b[38;2;255;255;255m  {CategoryName}  [0m │"
                +   $" \u001b[38;2;255;255;255m    {Quantity}   [0m │"
                +   $" \u001b[38;2;255;255;255m {Mass}[0m │"
                +   $" \u001b[38;2;255;255;255m {Length} [0m │"
                +   $" \u001b[38;2;255;255;255m {Heigth} [0m │"
                +   $" \u001b[38;2;255;255;255m {Depth}[0m │"
                +   $" \u001b[38;2;255;255;255m{StateName}[0m │"
                +    "\r\n"
                +    "└──────────────────┴──────────────────────────┴──────────┴──────────┴──────┴────────┴────────┴───────┴────────────┘\r\n"
            }
        };
}