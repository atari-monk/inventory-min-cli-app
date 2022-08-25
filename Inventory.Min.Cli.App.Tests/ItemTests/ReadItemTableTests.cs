using CLIHelper;
using Inventory.Min.Cli.App.TestApi;
using Inventory.Min.Data;
using Serilog.Sinks.InMemory.Assertions;
using Xunit;
using XUnit.Helper;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class ReadItemTableTests
    : OrderTest
        , IClassFixture<InventoryBetterTablesFixture>
{
    private const string RootPath = @"C:\kmazanek.gmail.com\Build\inventory-min-cli-app\";
    private const string ExpectedPath = @$"{RootPath}\Expected.txt";
    private const string ActualPath = @$"{RootPath}\Actual.txt";
    private const string EOL = "\r\n";

    private InventoryBetterTablesFixture fixture;

    public ReadItemTableTests(InventoryBetterTablesFixture fixture)
    {
        this.fixture = fixture;
    }

    // [Theory]
    // [MemberData(nameof(ItemReadBetterTablesData.Insert01)
    //     , MemberType= typeof(ItemReadBetterTablesData))]
    // public void Test01(int index, Item expected, string[] cmd)
    // {
    //     fixture.AssertItemCount(fixture.Uow, index);
    //     fixture.RunCmd(fixture.Booter, cmd);
    //     fixture.AssertItemCount(fixture.Uow, index + 1);
    //     var actual = fixture.GetItem(fixture.Uow, index);
    //     fixture.AssertItem(expected, actual);
    // }

    [Theory]
    [MemberData(nameof(ReadItemTableData.Insert01)
        , MemberType= typeof(ReadItemTableData))]
    public void Test01(int index, Item expected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, index);
        //var childItem = fixture.GetItem(fixture.Uow, 0);
        //var command = new List<string>(cmd);
        //SetValue(command, "parentid", childItem.Id.ToString());
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var actual = fixture.GetItem(fixture.Uow, index);
        //expected.ParentId = childItem.Id;
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
    [MemberData(nameof(ReadItemTableData.Read01)
        , MemberType= typeof(ReadItemTableData))]
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
        //var childItem = fixture.GetItem(fixture.Uow, 0);
        //var item = fixture.GetItem(fixture.Uow, index);
        //var idStr = item.Id.ToString();
        //expected = expected.Replace("{id}", idStr);
        //expected = expected.Replace("{idcol}", new string('─', idStr.Length + 2));
        //expected = expected.Replace("{idcolleft}", new string(' ', (idStr.Length + 2) - 4));
        //expected = expected.Replace("{idcolright}", new string(' ', (idStr.Length + 2) - 4 - ((idStr.Length + 2) - 4)));
        //expected = expected.Replace("{parentid}", childItem.Id.ToString());
        var outputText = output.OutText;
        //outputText = outputText.Replace("{parentid}", childItem.Id.ToString());
        var linesOut = outputText!.Split(EOL).ToList();
        var length = linesOut[0].IndexOf("┐") + 1;
        linesOut[0] = linesOut[0].Substring(0, length);
        linesOut[2] = linesOut[2].Substring(0, length);
        linesOut[4] = linesOut[4].Substring(0, length);
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