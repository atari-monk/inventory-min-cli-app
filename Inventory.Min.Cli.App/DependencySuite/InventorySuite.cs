using CLIHelper.Unity;
using Config.Wrapper.Unity;
using DIHelper.Unity;
using Inventory.Min.Lib;
using Inventory.Min.Table;
using Serilog.Wrapper.Unity;
using Unity;

namespace Inventory.Min.Cli.App;

public class InventorySuite 
    : UnityDependencySuite
{
    public InventorySuite(
        IUnityContainer container) 
        : base(container) 
    {
    }

    protected override void RegisterAppData()
    {
        RegisterSet<SerilogSet>();
    }

    protected override void RegisterDatabase()=> 
        RegisterSet<AppDatabase>();

    protected override void RegisterConsoleInput() => 
        RegisterSet<CliIOSet>();

    protected override void RegisterConsoleOutput() => 
        RegisterSet<InventoryTableSet>();

    protected override void RegisterDataMappings()
    {
        RegisterSet<AppMappings>();
        RegisterSet<DataFilter>();        
    }

    protected override void RegisterCommands() => 
        RegisterSet<AppCommands>();
}