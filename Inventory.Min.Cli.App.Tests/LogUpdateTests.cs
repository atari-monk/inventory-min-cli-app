using Inventory.Min.Cli.App.TestApi;
using Inventory.Min.Data;
using Xunit;
using XUnit.Helper;

namespace Inventory.Min.Cli.App.Tests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class ItemUpdateTests
    : OrderTest
    , IClassFixture<InventoryFixture>
{
    private InventoryFixture fixture;

    public ItemUpdateTests(InventoryFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(ItemUpdateData.Insert01), MemberType= typeof(ItemUpdateData))]
    public void Test01(string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
    }

    [Theory]
    [MemberData(nameof(ItemUpdateData.Update01), MemberType= typeof(ItemUpdateData))]
    public void Test04(Item insExpected, Item updExpected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, 1);
        var itemDb = fixture.GetItem(fixture.Uow, elementIndex: 0);
        fixture.AssertItem(
            insExpected
            , itemDb);
        var command = new List<string>(cmd);
        SetValue(command, "itemid", itemDb.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertItemCount(fixture.Uow, 1);
        var itemUpdDb = fixture.GetItem(fixture.Uow, elementIndex: 0);
        fixture.AssertItem(
            updExpected
            , itemUpdDb);
    }

    private Item GetItem()
    {
        return new Item()
        {
            CurrencyId = 1
            , 
        };
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