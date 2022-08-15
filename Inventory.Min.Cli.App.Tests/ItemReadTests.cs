using CommandDotNet.TestTools.Scenarios;
using Inventory.Min.Cli.App.TestApi;
using Inventory.Min.Data;
using Xunit;
using XUnit.Helper;

namespace Inventory.Min.Cli.App.Tests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class ItemReadTests
    : OrderTest
        , IClassFixture<InventoryFixture>
{
    private InventoryFixture fixture;

    public ItemReadTests(InventoryFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(ItemReadData.Insert01)
        , MemberType= typeof(ItemReadData))]
    public void Test01(int index, Item expected, string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, index);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertItemCount(fixture.Uow, index + 1);
        var actual = fixture.GetItem(fixture.Uow, index);
        fixture.AssertItem(expected, actual);
    }

    [Theory]
    [MemberData(nameof(ItemReadData.Read01)
        , MemberType= typeof(ItemReadData))]
    public void Test02(int index, Item expected, string[] cmd)
    {
        //fixture.RunCmd(fixture.Booter, cmd);
        // fixture.Booter.GetAppRunner().Verify(new Scenario
        //     {
        //         When = { Args = string.Join(' ', cmd) },
        //         Then = { 
        //             Output = "[18:36:18 INF] Read Item"
        //                 + "Id | Name | Description | Category | CategoryId |"
        //                 + "10 | Name | Description |          |            |" 
        //         }
        //     });
        fixture.Booter.GetAppRunner().Verify(new Scenario
            {
                When = { Args = string.Join(' ', cmd) },
                Then = { 
                    Output = ""
                }
            });
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