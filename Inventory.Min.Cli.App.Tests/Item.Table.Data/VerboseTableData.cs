using System.Globalization;
using Inventory.Min.BetterTable;
using Inventory.Min.Data;
using ModelHelper;
using d = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class VerboseTableData
    : MyTableData
{
    private const int InitialCount = 10;
    private const int CurrentCount = 5;
    private const string PurchaseDate = "22.08.2022";
    private const decimal PurchasePrice = 45.56m;
    private const decimal SellPrice = 13.32m;
    private const double Length = 65.1;
    private const double Heigth = 34.6;
    private const double Depth = 12.3;
    private const double Diameter =5.6;
    private const double Volume = 33.4;
    private const double Mass = 2.7;
    
    public new static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , d.GetItem(
                    (item) => item.Description = d.Description
                    , (item) => item.InitialCount = InitialCount
                    , (item) => item.CurrentCount = CurrentCount
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 22)
                    , (item) => item.PurchasePrice = PurchasePrice
                    , (item) => item.SellPrice = SellPrice
                    , (item) => item.Length = Length
                    , (item) => item.Heigth = Heigth
                    , (item) => item.Depth = Depth
                    , (item) => item.Diameter = Diameter
                    , (item) => item.Volume = Volume
                    , (item) => item.Mass = Mass
                ) 
                , d.GetInsCmd(
                    "-d", d.Description
                    , "-q", InitialCount.ToString()
                    , "--currentCount", CurrentCount.ToString()
                    , "-p", PurchaseDate
                    , "-r", PurchasePrice.ToString(), "-s", SellPrice.ToString()
                    , "-l", Length.ToString(), "-e", Heigth.ToString()
                    , "-t", Depth.ToString(), "--diameter", Diameter.ToString()
                    , "-v", Volume.ToString(), "--mass", Mass.ToString())
            }
        };

    public new static IEnumerable<object[]> Read01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , d.GetReadCmd("-t", ItemTablesTest.VerboseTest.ToString())
                ,    "┌──────────────┬─────────────────────┬──────────────┬──────────────┬──────────────┬───────────────┬───────────┬────────┬────────┬───────┬──────────┬────────┬──────┐\r\n│"
                +   $" \u001b[38;2;255;255;255m    {nameof(Item.Name)}    \u001b[0m │"
                +   $" \u001b[38;2;255;255;255m    {nameof(Item.Description)}    [0m │"
                +   $" [38;2;255;255;255m{nameof(Item.InitialCount)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.CurrentCount)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.PurchaseDate)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.PurchasePrice)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.SellPrice)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.Length)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.Heigth)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.Depth)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.Diameter)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.Volume)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.Mass)}[0m │"
                +    "\r\n"
                +    "├──────────────┼─────────────────────┼──────────────┼──────────────┼──────────────┼───────────────┼───────────┼────────┼────────┼───────┼──────────┼────────┼──────┤\r\n│"
                +   $" \u001b[38;2;255;255;255m{d.Name}\u001b[0m │"
                +   $" \u001b[38;2;255;255;255m{d.Description}[0m │"
                +   $" [38;2;255;255;255m     {InitialCount}     [0m │"
                +   $" [38;2;255;255;255m      {CurrentCount}     [0m │"
                +   $" [38;2;255;255;255m {PurchaseDate} [0m │"
                +   $" [38;2;255;255;255m   {GetPrice(PurchasePrice)}  [0m │"
                +   $" [38;2;255;255;255m {GetPrice(SellPrice)}[0m │"
                +   $" [38;2;255;255;255m {Length} [0m │"
                +   $" [38;2;255;255;255m {Heigth} [0m │"
                +   $" [38;2;255;255;255m {Depth}[0m │"
                +   $" [38;2;255;255;255m   {Diameter}  [0m │"
                +   $" [38;2;255;255;255m {Volume} [0m │"
                +   $" [38;2;255;255;255m {Mass}[0m │"
                +    "\r\n"
                +    "└──────────────┴─────────────────────┴──────────────┴──────────────┴──────────────┴───────────────┴───────────┴────────┴────────┴───────┴──────────┴────────┴──────┘\r\n"
            }
        };

    private static object GetPrice(decimal purchasePrice)
    {
        return purchasePrice.ToString(Model.MoneyFormat, CultureInfo.GetCultureInfo(Model.PolishCulture));
    }
}