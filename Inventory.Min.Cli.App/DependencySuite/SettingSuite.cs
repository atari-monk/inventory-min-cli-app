using CLIHelper;
using CommandDotNet.Helper;
using Config.Wrapper;
using DIHelper;
using Unity;

namespace Inventory.Min.Cli.App;

public class SettingSuite
{
    private readonly IConfigReader configReader;
    private CommandDotNetSettings commandDotNetSettings;
    private RunMode runModeSettings;
    private TableSettings tableSettings;
    
    public SettingSuite(
        IConfigReader configReader)
    {
        this.configReader = configReader;
        commandDotNetSettings = GetConfig<CommandDotNetSettings>();
        runModeSettings = GetConfig<RunMode>();
        tableSettings = GetConfig<TableSettings>();
    }

    private TConfig GetConfig<TConfig>()
    {
        var typeName = typeof(TConfig).Name;
        return configReader.GetConfigSection<TConfig>(typeName)
            ?? throw new ArgumentNullException(typeName);
    }

    public IDependencySuite GetSuite(IUnityContainer unity)
    {
        if (runModeSettings.Test){
            if(tableSettings.UseBetterTables)
                return new TestMode.BetterTableSuite(unity);
            return new TestMode.TestSuite(unity);
        }
        if (commandDotNetSettings.UseRepl)
        {
            if(tableSettings.UseBetterTables)
                return new ReplMode.BetterTableSuite(unity);
            return new ReplMode.ReplSuite(unity);
        }
        else
        {
             if(tableSettings.UseBetterTables)
                return new CmdMode.BetterTableSuite(unity);
            return new CmdMode.CmdSuite(unity);
        }
    }
}