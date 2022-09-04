using CLIHelper;
using Inventory.Min.Cli.App.TestApi;
using Inventory.Min.Data;
using Serilog.Sinks.InMemory.Assertions;
using Xunit;
using XUnit.Helper;
using t = Inventory.Min.Cli.App.Tests.ItemTests.TestUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class BasicTableTests
    : OrderTest
        , IClassFixture<InventoryBetterTablesFixture>
{
    private InventoryBetterTablesFixture fixture;

    public BasicTableTests(InventoryBetterTablesFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(BasicTableData.Insert01)
        , MemberType= typeof(BasicTableData))]
    public void Test01(int index, Item expected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, index);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var actual = fixture.GetItem(fixture.Uow, index);
        fixture.AssertItem(expected, actual);
    }

    [Theory]
    [MemberData(nameof(BasicTableData.Read01)
        , MemberType= typeof(BasicTableData))]
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
        var output = (IOutMock)fixture.Booter.GetOut();
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var outputText = output.OutText;
        var linesOut = outputText!.Split(t.EOL).ToList();
        var length = linesOut[0].IndexOf("┐") + 1;
        linesOut[0] = linesOut[0].Substring(0, length);
        linesOut[2] = linesOut[2].Substring(0, length);
        linesOut[4] = linesOut[4].Substring(0, length);
        t.PrintToFile(expected, linesOut, true);
        outputText = string.Join(t.EOL, linesOut);
        Assert.Equal(expected, outputText);
    }
}