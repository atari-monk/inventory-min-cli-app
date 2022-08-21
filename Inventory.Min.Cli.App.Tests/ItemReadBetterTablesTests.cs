using CLIHelper;
using Inventory.Min.Cli.App.TestApi;
using Inventory.Min.Data;
using Serilog.Sinks.InMemory.Assertions;
using Xunit;
using XUnit.Helper;

namespace Inventory.Min.Cli.App.Tests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class ItemReadBetterTablesTests
    : OrderTest
        , IClassFixture<InventoryBetterTablesFixture>
{
    private InventoryBetterTablesFixture fixture;

    public ItemReadBetterTablesTests(InventoryBetterTablesFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(ItemReadBetterTablesData.Insert01)
        , MemberType= typeof(ItemReadBetterTablesData))]
    public void Test01(int index, Item expected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, index);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var actual = fixture.GetItem(fixture.Uow, index);
        fixture.AssertItem(expected, actual);
    }

    [Theory]
    [MemberData(nameof(ItemReadBetterTablesData.Read01)
        , MemberType= typeof(ItemReadBetterTablesData))]
    public void Test02(int index, string[] cmd, string expected)
    {
        fixture.RunCmd(fixture.Booter, cmd);
        var logger = fixture.Booter.GetLogger();
        logger
            .Should()
            .HaveMessage("{0} {1}")
            .Appearing().Once()
            .WithProperty("0")
            .WithValue("Read")
            .And
            .WithProperty("1")
            .WithValue("Item");
        var output = fixture.Booter.GetOut() as IOutMock;
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var item = fixture.GetItem(fixture.Uow, index);
        var idStr = item.Id.ToString();
        expected = expected.Replace("{id}", idStr);
        Assert.Equal(expected, output?.OutText);
    }
}