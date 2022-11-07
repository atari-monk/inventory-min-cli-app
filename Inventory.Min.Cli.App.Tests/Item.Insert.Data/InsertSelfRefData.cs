using d = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public static class InsertSelfRefData
{
    public static IEnumerable<object[]> InsertParent =>
        new List<object[]>
        {
            new object[]
            {
                0
                , d.GetItem()
                , d.GetInsCmd()
            }
        };

    public static IEnumerable<object[]> InsertSelfRef =>
        new List<object[]>
        {
            new object[]
            {
                1
                , d.GetItem((item) => item.Description = "test self ref")
                , d.GetInsCmd("-d", "test self ref", "-f", "parentId")
            }
        };
}
