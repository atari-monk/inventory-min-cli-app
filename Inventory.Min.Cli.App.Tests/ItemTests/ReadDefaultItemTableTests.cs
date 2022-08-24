using CLIHelper;
using Inventory.Min.Cli.App.TestApi;
using Inventory.Min.Data;
using Serilog.Sinks.InMemory.Assertions;
using Xunit;
using XUnit.Helper;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class ReadDefaultItemTableTests
    : OrderTest
        , IClassFixture<InventoryBetterTablesFixture>
{
    private const string RootPath = @"C:\kmazanek.gmail.com\Build\inventory-min-cli-app\";
    private const string ExpectedPath = @$"{RootPath}\Expected.txt";
    private const string ActualPath = @$"{RootPath}\Actual.txt";
    private const string EOL = "\r\n";

    private InventoryBetterTablesFixture fixture;

    public ReadDefaultItemTableTests(InventoryBetterTablesFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(ReadDefaultItemTableData.Insert01)
        , MemberType= typeof(ReadDefaultItemTableData))]
    public void Test01(int index, Item expected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, index);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var actual = fixture.GetItem(fixture.Uow, index);
        fixture.AssertItem(expected, actual);
    }

    [Theory]
    [MemberData(nameof(ReadDefaultItemTableData.Insert02)
        , MemberType= typeof(ReadDefaultItemTableData))]
    public void Test02(int index, Item expected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, index);
        var parent = fixture.GetItem(fixture.Uow, 0);
        var command = new List<string>(cmd);
        SetValue(command, "parentId", parent.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var actual = fixture.GetItem(fixture.Uow, index);
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

    [Theory]
    [MemberData(nameof(ReadDefaultItemTableData.Read01)
        , MemberType= typeof(ReadDefaultItemTableData))]
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
        var linesOut = outputText!.Split(EOL).ToList();
        var length = linesOut[0].IndexOf("┐") + 1;
        linesOut[0] = linesOut[0].Substring(0, length);
        linesOut[2] = linesOut[2].Substring(0, length);
        linesOut[5] = linesOut[5].Substring(0, length);
        PrintToFile(expected, linesOut, true);
        outputText = string.Join(EOL, linesOut);
        Assert.Equal(expected, outputText);
    }

    private static void PrintToFile(
        string expected
        , List<string> linesOut
        , bool isActive = false)
    {
        if(isActive == false) return;
        File.WriteAllLines(ExpectedPath, expected.Split(EOL).ToList());
        File.WriteAllLines(ActualPath, linesOut);
    }
}