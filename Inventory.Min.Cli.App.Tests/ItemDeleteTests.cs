using Inventory.Min.Cli.App.TestApi;
using Xunit;
using XUnit.Helper;
using Moq;

namespace Inventory.Min.Cli.App.Tests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class ItemDeleteTests
    : OrderTest
        , IClassFixture<InventoryFixture>
{
    private InventoryFixture fixture;
    private Mock<TextReader> cliInput;

    public ItemDeleteTests(InventoryFixture fixture)
    {
        this.fixture = fixture;
        cliInput = new Mock<TextReader>();
        Console.SetIn(cliInput.Object);
    }

    [Theory]
    [MemberData(nameof(ItemDeleteData.Insert01)
        , MemberType= typeof(ItemDeleteData))]
    public void Test01(string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
    }

    [Theory]
    [MemberData(nameof(ItemDeleteData.Delete01)
        , MemberType= typeof(ItemDeleteData))]
    public void Test02(string[] cmd)
    {
        SetupUserResponses("n");
        fixture.AssertItemCount(fixture.Uow, 1);
        var itemDb = fixture.GetItem(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "itemid", itemDb.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertItemCount(fixture.Uow, 1);
        var actual = fixture.GetItem(fixture.Uow, 0);
        Assert.NotNull(actual);
        Assert.Equal(itemDb.Id, actual.Id);
    }

    [Theory]
    [MemberData(nameof(ItemDeleteData.Delete01)
        , MemberType= typeof(ItemDeleteData))]
    public void Test03(string[] cmd)
    {
        SetupUserResponses("y");
        fixture.AssertItemCount(fixture.Uow, 1);
        var itemDb = fixture.GetItem(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "itemid", itemDb.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertItemCount(fixture.Uow, 0);
        Assert.Throws<ArgumentOutOfRangeException>(()=>fixture.GetItem(fixture.Uow, 0));
    }

    private MockSequence SetupUserResponses(params string[] responses)
    {
        var sequence = new MockSequence();
        foreach (var response in responses)
        {
            cliInput.InSequence(sequence).Setup(x => x.ReadLine()).Returns(response);
        }
        return sequence;
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