using Xunit;
using XUnit.Helper;

namespace Inventory.Min.Cli.App.TestApi;

[Collection("Collection1")]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class FixtureTests
    : OrderTest
    , IClassFixture<InventoryFixture>
{
    private InventoryFixture fixture;

    public FixtureTests(InventoryFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void Test01()
    {
        Test();
    }

    private void Test()
    {
        fixture.AssertItemCount(fixture.Uow, 0);
    }

    [Fact]
    public void Test02()
    {
        Test();
    }
}