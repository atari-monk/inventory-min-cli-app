using Inventory.Min.Data;
using d = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class ReadMyItemTableData
{
    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , d.GetItem((item) => item.Description = d.Description) 
                , d.GetInsCmd("-d", d.Description)
            }
        };

    public static IEnumerable<object[]> Read01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , d.GetReadCmd()
                , $"{{idcolleft}}{nameof(Item.Id)}{{idcolright}}|       {nameof(Item.Name)}       |       Description        | Category | CategoryId |\r\n"
                + $" {{id}} | {d.Name} | {d.Description} |          |            |\r\n"
            }
        };
}