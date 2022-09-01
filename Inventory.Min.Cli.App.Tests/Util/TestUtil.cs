namespace Inventory.Min.Cli.App.Tests.ItemTests;

public static class TestUtil
{
    private const string RootPath = @"C:\kmazanek.gmail.com\Build\inventory-min-cli-app\";
    private const string ExpectedPath = @$"{RootPath}\Expected.txt";
    private const string ActualPath = @$"{RootPath}\Actual.txt";
    public const string EOL = "\r\n";

    public static void SetValue(
        List<string> cmd
        , string key
        , string value)
    {
        cmd[GetIndex(cmd, key)] = value;
    }

    public static int GetIndex(List<string> cmd, string value)
    {
        return cmd.IndexOf(value);
    }

    public static void PrintToFile(
        string expected
        , List<string> linesOut
        , bool isActive = false)
    {
        if(isActive == false) return;
        File.WriteAllLines(ExpectedPath, expected.Split(EOL).ToList());
        File.WriteAllLines(ActualPath, linesOut);
    }

    public static void PrintToFile(
        string expected
        , string actual
        , bool isActive = false)
    {
        if(isActive == false) return;
        File.WriteAllText(ExpectedPath, expected);
        File.WriteAllText(ActualPath, actual);
    }
}