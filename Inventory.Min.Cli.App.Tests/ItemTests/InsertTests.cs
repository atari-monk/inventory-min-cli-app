using Inventory.Min.Cli.App.TestApi;
using Inventory.Min.Data;
using Xunit;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class InsertTests
    : InventoryTest
        , IClassFixture<InventoryFixture>
{
    private InventoryFixture fixture;

    public InsertTests(InventoryFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(InsertData.Insert01)
        , MemberType= typeof(InsertData))]
    public void Test01(int index, Item expected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, index);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var actual = fixture.GetItem(fixture.Uow, index);
        fixture.AssertItem(expected, actual);
    }

    [Fact]
    public void Test02()
    {
        var seeder = new TestSeeder();
        seeder.Seed();
    }

    [Theory]
    [MemberData(nameof(InsertData.Insert02)
        , MemberType= typeof(InsertData))]
    public void Test03(int index, Item expected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, index);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var actual = fixture.GetItem(fixture.Uow, index);
        fixture.AssertItem(expected, actual);
    }

    [Theory]
    [MemberData(nameof(InsertData.Insert03)
        , MemberType= typeof(InsertData))]
    public void Test04(Item expected, string[] cmd)
    {
        const int PrevTestInsertCount = 21;
        fixture.AssertItemCount(fixture.Uow, PrevTestInsertCount);
        var parent = fixture.GetItem(fixture.Uow, elementIndex: PrevTestInsertCount - 1);
        var command = new List<string>(cmd);
        SetValue(command, "parentId", parent.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertItemCount(fixture.Uow, PrevTestInsertCount + 1);
        var actual = fixture.GetItem(fixture.Uow, PrevTestInsertCount);
        expected.ParentId = parent.Id;
        fixture.AssertItem(expected, actual);
    }    
}