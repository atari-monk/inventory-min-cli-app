using Inventory.Min.Cli.App.TestApi;
using Inventory.Min.Data;
using Xunit;
using XUnit.Helper;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class UpdateTests
    : OrderTest
    , IClassFixture<InventoryFixture>
{
    private InventoryFixture fixture;

    public UpdateTests(InventoryFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(UpdateData.Insert01), MemberType= typeof(UpdateData))]
    public void Test01(string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
    }

    [Theory]
    [MemberData(nameof(UpdateData.Update01), MemberType= typeof(UpdateData))]
    public void Test02(int index, Item expected, string[] cmd)
    {
        Assert.True(index >= 0 && index < 100);
        fixture.AssertItemCount(fixture.Uow, 1);
        var itemDb = fixture.GetItem(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "itemid", itemDb.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertItemCount(fixture.Uow, 1);
        var itemUpdDb = fixture.GetItem(fixture.Uow, elementIndex: 0);
        fixture.AssertItem(
            expected
            , itemUpdDb);
    }

    [Theory]
    [MemberData(nameof(UpdateData.Insert02), MemberType= typeof(UpdateData))]
    public void Test03(string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
    }

    [Theory]
    [MemberData(nameof(UpdateData.Update02), MemberType= typeof(UpdateData))]
    public void Test04(int index, Item expected, string[] cmd)
    {
        Assert.True(index >= 0 && index < 2);
        fixture.AssertItemCount(fixture.Uow, 2);
        var itemDb = fixture.GetItem(fixture.Uow, elementIndex: 0);
        var itemDb2 = fixture.GetItem(fixture.Uow, elementIndex: 1);
        var command = new List<string>(cmd);
        SetValue(command, "itemid", itemDb.Id.ToString());
        SetValue(command, "parentid", itemDb2.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertItemCount(fixture.Uow, 2);
        var itemUpdDb = fixture.GetItem(fixture.Uow, elementIndex: 0);
        expected.ParentId = itemDb2.Id;
        fixture.AssertItem(
            expected
            , itemUpdDb);
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