using Inventory.Min.Cli.App.TestApi;
using Inventory.Min.Data;
using Xunit;
using XUnit.Helper;

namespace Inventory.Min.Cli.App.Tests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class ItemInsertTests
    : OrderTest
        , IClassFixture<InventoryFixture>
{
    private InventoryFixture fixture;

    public ItemInsertTests(InventoryFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(ItemInsertData.Insert01)
        , MemberType= typeof(ItemInsertData))]
    public void Test01(int index, Item expected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, index);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var actual = fixture.GetItem(fixture.Uow, index);
        fixture.AssertItem(expected, actual);
    }

    [Theory]
    [MemberData(nameof(ItemInsertData.Insert02)
        , MemberType= typeof(ItemInsertData))]
    public void Test02(int index, Item expected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, 18);
        var parent = fixture.GetItem(fixture.Uow, elementIndex: 17);
        var command = new List<string>(cmd);
        SetValue(command, "parentId", parent.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertItemCount(fixture.Uow, 19);
        var actual = fixture.GetItem(fixture.Uow, 18);
        expected.ParentId = parent.Id;
        fixture.AssertItem(expected, actual);
    }

    private void SetValue(
        List<string> cmd
        , string key
        , string value)
    {
        cmd[GetIndex(cmd, key)] = value;
    }

    private int GetIndex(List<string> cmd, string value)
    {
        return cmd.IndexOf(value);
    }
}