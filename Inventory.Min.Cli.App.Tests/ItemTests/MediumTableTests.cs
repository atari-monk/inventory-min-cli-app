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
public class MediumTableTests
    : OrderTest
        , IClassFixture<InventoryBetterTablesFixture>
{
    private InventoryBetterTablesFixture fixture;

    public MediumTableTests(InventoryBetterTablesFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(MediumTableData.Insert01)
        , MemberType= typeof(MediumTableData))]
    public void Test01(int index, Item expected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, index);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var actual = fixture.GetItem(fixture.Uow, index);
        fixture.AssertItem(expected, actual);
    }

    [Theory]
    [MemberData(nameof(MediumTableData.Insert02)
        , MemberType= typeof(MediumTableData))]
    public void Test02(int index, Item expected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, index);
        var parent = fixture.GetItem(fixture.Uow, 0);
        var command = new List<string>(cmd);
        t.SetValue(command, "parentId", parent.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var actual = fixture.GetItem(fixture.Uow, index);
        expected.ParentId = parent.Id;
        fixture.AssertItem(expected, actual);
    }

    [Theory]
    [MemberData(nameof(MediumTableData.Read01)
        , MemberType= typeof(MediumTableData))]
    public void Test03(int index, string[] cmd, string expected)
    {
        fixture.AssertItemCount(fixture.Uow, index + 1);
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
        var outputText = output.OutText;
        var linesOut = outputText!.Split(t.EOL).ToList();
        var length = linesOut[0].IndexOf("┐") + 1;
        linesOut[0] = linesOut[0].Substring(0, length);
        linesOut[2] = linesOut[2].Substring(0, length);
        linesOut[5] = linesOut[5].Substring(0, length);
        t.PrintToFile(expected, linesOut, true);
        outputText = string.Join(t.EOL, linesOut);
        Assert.Equal(expected, outputText);
    }
}