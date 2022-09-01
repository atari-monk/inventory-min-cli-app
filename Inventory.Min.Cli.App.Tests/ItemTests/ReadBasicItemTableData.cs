using System.Globalization;
using Inventory.Min.BetterTable;
using Inventory.Min.Data;
using ModelHelper;
using d = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class ReadBasicItemTableData
    : ReadMyItemTableData
{
    public new static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , d.GetItem(
                    (item) => item.Description = d.Description) 
                , d.GetInsCmd("-d", d.Description)
            }
        };

    public new static IEnumerable<object[]> Read01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , d.GetReadCmd("-t", nameof(BasicItemTableTest))
                ,    "┌──────────────┬─────────────────────┐\r\n│"
                +   $" \u001b[38;2;255;255;255m    {nameof(Item.Name)}    \u001b[0m │"
                +   $" \u001b[38;2;255;255;255m    {nameof(Item.Description)}    [0m │"
                +    "\r\n"
                +    "├──────────────┼─────────────────────┤\r\n│"
                +   $" \u001b[38;2;255;255;255m{d.Name}\u001b[0m │"
                +   $" \u001b[38;2;255;255;255m{d.Description}[0m │"
                +    "\r\n"
                +    "└──────────────┴─────────────────────┘\r\n"
            }
        };

    private static object GetPrice(decimal purchasePrice)
    {
        return purchasePrice.ToString(Model.MoneyFormat, CultureInfo.GetCultureInfo(Model.PolishCulture));
    }
}