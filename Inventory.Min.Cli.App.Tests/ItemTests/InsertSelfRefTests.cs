using Inventory.Min.Cli.App.TestApi;
using Inventory.Min.Data;
using Xunit;
using XUnit.Helper;
using t = Inventory.Min.Cli.App.Tests.ItemTests.TestUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class InsertSelfRefTests
    : OrderTest
        , IClassFixture<InventoryFixture>
{
    private InventoryFixture fixture;

    public InsertSelfRefTests(InventoryFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(InsertSelfRefData.InsertParent)
        , MemberType = typeof(InsertSelfRefData))]
    public void Test01(int index, Item expected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, index);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var actual = fixture.GetItem(fixture.Uow, index);
        fixture.AssertItem(expected, actual);
    }

    [Theory]
    [MemberData(nameof(InsertSelfRefData.InsertSelfRef)
        , MemberType= typeof(InsertSelfRefData))]
    public void Test02(int index, Item expected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, index);
        var parent = fixture.GetItem(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        t.SetValue(command, "parentId", parent.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var actual = fixture.GetItem(fixture.Uow, index);
        expected.ParentId = parent.Id;
        fixture.AssertItem(expected, actual);
    }
}
