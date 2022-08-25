using Inventory.Min.BetterTable;
using Inventory.Min.Data;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class ReadDefaultItemTableData
    : ReadMyItemTableData
{
    private const int CategoryId = 1;
    private const string CategoryName = "Food";
    private const int InitialCount = 9;
    private const int CurrentCount = 6;
    private const int Mass = 500;
    private const int StateId = 1;
    private const string StateName = "In storage";
    private const string ParentName = Name;

    public new static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetItem() 
                , GetInsCmd()
            }
        };

    public static IEnumerable<object[]> Insert02 =>
        new List<object[]>
        {
            new object[] 
            {
                1
                , GetItem(
                    (item) => item.Description = Description
                    , (item) => item.CategoryId = CategoryId
                    , (item) => item.InitialCount = InitialCount
                    , (item) => item.CurrentCount = CurrentCount
                    , (item) => item.Mass = Mass
                    , (item) => item.StateId = StateId
                    ) 
                , GetInsCmd(
                    "-d", Description
                    , "-c", CategoryId.ToString()
                    , "-q", InitialCount.ToString()
                    , "--currentCount", CurrentCount.ToString()
                    , "--mass", Mass.ToString()
                    , "-a", StateId.ToString()
                    , "-r", "parentId"
                    )
            }
        };

    public new static IEnumerable<object[]> Read01 =>
        new List<object[]>
        {
            new object[] 
            {
                1
                , GetReadCmd("-t", nameof(DefaultItemTableTest))
                ,    "┌──────────────────┬──────────────────────────┬──────────┬──────────────┬──────────────┬──────┬────────────┬──────────────────┐\r\n│"
                +   GetHeader()
                +    "├──────────────────┼──────────────────────────┼──────────┼──────────────┼──────────────┼──────┼────────────┼──────────────────┤\r\n│"
                +   GetRow1()
                +   GetRow2()
                +    "└──────────────────┴──────────────────────────┴──────────┴──────────────┴──────────────┴──────┴────────────┴──────────────────┘\r\n"
            }
        };

        private static string GetHeader()
        {
            return 
                $" \u001b[38;2;255;255;255m      {nameof(Item.Name)}      \u001b[0m │"
            +   $" \u001b[38;2;255;255;255m       {nameof(Item.Description)}      [0m │"
            +   $" \u001b[38;2;255;255;255m{nameof(Item.Category)}[0m │"
            +   $" \u001b[38;2;255;255;255m{nameof(Item.InitialCount)}[0m │"
            +   $" \u001b[38;2;255;255;255m{nameof(Item.CurrentCount)}[0m │"
            +   $" \u001b[38;2;255;255;255m{nameof(Item.Mass)}[0m │"
            +   $" \u001b[38;2;255;255;255m   {nameof(Item.State)}  [0m │"
            +   $" \u001b[38;2;255;255;255m     {nameof(Item.Parent)}     [0m │"
            +    "\r\n";
        }

        private static string GetRow1()
        {
            return 
                $" \u001b[38;2;255;255;255m{Name}\u001b[0m │"
            +   $" \u001b[38;2;255;255;255m                        [0m │"
            +   $" \u001b[38;2;255;255;255m        [0m │"
            +   $" \u001b[38;2;255;255;255m            [0m │"
            +   $" \u001b[38;2;255;255;255m            [0m │"
            +   $" \u001b[38;2;255;255;255m    [0m │"
            +   $" \u001b[38;2;255;255;255m          [0m │"
            +   $" \u001b[38;2;255;255;255m                [0m │"
            +    "\r\n";
        }

        private static string GetRow2()
        {
            return 
            $"│ \u001b[38;2;255;255;255m{Name}\u001b[0m │"
            +   $" \u001b[38;2;255;255;255m{Description}[0m │"
            +   $" \u001b[38;2;255;255;255m  {CategoryName}  [0m │"
            +   $" \u001b[38;2;255;255;255m      {InitialCount}     [0m │"
            +   $" \u001b[38;2;255;255;255m      {CurrentCount}     [0m │"
            +   $" \u001b[38;2;255;255;255m {Mass}[0m │"
            +   $" \u001b[38;2;255;255;255m{StateName}[0m │"
            +   $" \u001b[38;2;255;255;255m{ParentName}[0m │"
            +    "\r\n";
        }
}