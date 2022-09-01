using d = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class DeleteData
{
    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                d.GetInsCmd()
            }
        };

    public static IEnumerable<object[]> Delete01 =>
        new List<object[]>
        {
            new object[] 
            {
                d.GetDelCmd()
            }
        };
}