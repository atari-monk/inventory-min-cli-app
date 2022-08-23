namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class DeleteData
{
    private const string MainCmd = "item";
    private const string InsCmd = "ins";
    private const string Name = "Name";

    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                new string[] { MainCmd, InsCmd, Name }
            }
        };

    public static IEnumerable<object[]> Delete01 =>
        new List<object[]>
        {
            new object[] 
            {
                new string[] { MainCmd, "del", "itemid" }
            }
        };
}