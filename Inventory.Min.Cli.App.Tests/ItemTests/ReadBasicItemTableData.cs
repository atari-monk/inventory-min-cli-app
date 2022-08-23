using System.Globalization;
using Inventory.Min.BetterTable;
using Inventory.Min.Data;
using ModelHelper;

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
                , GetItem(
                    (item) => item.Description = Description) 
                , GetInsCmd(
                    "-d", Description)
            }
        };

    public new static IEnumerable<object[]> Read01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetReadCmd("-t", nameof(BasicItemTable))
                ,    "┌{idcol}┬──────────────────┬──────────────────────────┐\r\n"
                +   $"│ \u001b[38;2;255;255;255m {nameof(Item.Id)} \u001b[0m │"
                +   $" \u001b[38;2;255;255;255m      {nameof(Item.Name)}      \u001b[0m │"
                +   $" \u001b[38;2;255;255;255m       {nameof(Item.Description)}      [0m │"
                +    "\r\n"
                +    "├{idcol}┼──────────────────┼──────────────────────────┤\r\n"
                +   $"│ \u001b[38;2;255;255;255m{{id}}\u001b[0m │"
                +   $" \u001b[38;2;255;255;255m{Name}\u001b[0m │"
                +   $" \u001b[38;2;255;255;255m{Description}[0m │"
                +    "\r\n"
                +    "└{idcol}┴──────────────────┴──────────────────────────┘\r\n"
            }
        };

    private static object GetPrice(decimal purchasePrice)
    {
        return purchasePrice.ToString(Model.MoneyFormat, CultureInfo.GetCultureInfo(Model.PolishCulture));
    }
}