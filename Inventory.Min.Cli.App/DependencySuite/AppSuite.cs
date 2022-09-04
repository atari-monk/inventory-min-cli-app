using CLIHelper.Unity;
using DIHelper.Unity;
using Inventory.Min.Lib;
using Inventory.Min.Table;
using Serilog.Wrapper.Unity;
using Unity;

namespace Inventory.Min.Cli.App;

public class AppSuite 
    : UnityDependencySuite
{
    public AppSuite(
        IUnityContainer container) 
        : base(container) 
    {
    }

    protected override void RegisterAppData()
    {
        RegisterSet<SerilogSet>();
    }

    protected override void RegisterDatabase()=> 
        RegisterSet<DatabaseSet>();

    protected override void RegisterConsoleInput() => 
        RegisterSet<CliIOSet>();

    protected override void RegisterConsoleOutput()
    {
        RegisterSet<MyTableSet>();
    }

    protected override void RegisterDataMappings()
    {
        RegisterSet<MappingSet>();
        RegisterSet<FilterSet>();        
    }

    protected override void RegisterCommands() => 
        RegisterSet<CommandSet>();
}