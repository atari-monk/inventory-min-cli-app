using Inventory.Min.Cli.App.TestApi;
using Inventory.Min.Data;
using Xunit;
using XUnit.Helper;
using t = Inventory.Min.Cli.App.Tests.ItemTests.TestUtil;

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
    public void Test01(int index, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, index);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertItemCount(fixture.Uow, index + 1);
    }

    [Theory]
    [MemberData(nameof(UpdateData.Update01), MemberType= typeof(UpdateData))]
    public void Test02(int index, string propName, Item expected, string[] cmd)
    {
        Assert.True(index >= 0 && index < 42);
        var itemDb = fixture.GetItem(fixture.Uow, 0);
        var command = new List<string>(cmd);
        t.SetValue(command, "itemid", itemDb.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        itemDb = fixture.GetItem(fixture.Uow, 0);
        fixture.AssertItem(expected, itemDb, propName);
    }
}