using Inventory.Min.Data;
using u = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class UpdateParentData
{
    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] { 0, u.GetInsCmd() }
            , new object[] { 1, u.GetInsCmd() }
        };

    public static IEnumerable<object[]> Update01 =>
        new List<object[]>
        {
            new object[] { 0, nameof(Item.ParentId), u.GetUpdCmd("-f", "parentid") }
            , new object[] { 1, nameof(Item.ParentId), u.GetUpdCmd("--parentId", "parentid") }
        };
}