using Inventory.Min.BetterTable;
using Inventory.Min.Data;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class ReadSizeItemTableData
    : ReadMyItemTableData
{
    private const double Length = 34.5;
    private const double Heigth = 14.2;
    private const double Depth = 11.4;

    public new static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetItem(
                    (item) => item.Length = Length
                    , (item) => item.Heigth = Heigth
                    , (item) => item.Depth = Depth
                    ) 
                , GetInsCmd(
                    "-l", Length.ToString()
                    , "-e", Heigth.ToString()
                    , "--depth", Depth.ToString()
                    )
            }
        };

    public new static IEnumerable<object[]> Read01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetReadCmd("-t", nameof(SizeItemTableTest))
                ,    "┌──────────────────┬────────┬────────┬───────┐\r\n│"
                +   GetHeader()
                +    "├──────────────────┼────────┼────────┼───────┤\r\n│"
                +   GetRow1()
                +    "└──────────────────┴────────┴────────┴───────┘\r\n"
            }
        };

        private static string GetHeader()
        {
            return 
                $" \u001b[38;2;255;255;255m      {nameof(Item.Name)}      \u001b[0m │"
            +   $" \u001b[38;2;255;255;255m{nameof(Item.Length)}[0m │"
            +   $" \u001b[38;2;255;255;255m{nameof(Item.Heigth)}[0m │"
            +   $" \u001b[38;2;255;255;255m{nameof(Item.Depth)}[0m │"
            +    "\r\n";
        }

        private static string GetRow1()
        {
            return 
                $" \u001b[38;2;255;255;255m{Name}\u001b[0m │"
            +   $" \u001b[38;2;255;255;255m {Length} [0m │"
            +   $" \u001b[38;2;255;255;255m {Heigth} [0m │"
            +   $" \u001b[38;2;255;255;255m {Depth}[0m │"
            +    "\r\n";
        }
}