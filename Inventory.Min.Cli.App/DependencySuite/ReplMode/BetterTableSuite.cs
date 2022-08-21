using Inventory.Min.BetterTable;
using Inventory.Min.Lib;
using Unity;

namespace Inventory.Min.Cli.App.ReplMode;

public class BetterTableSuite 
    : ReplSuite
{
    public BetterTableSuite(
        IUnityContainer container) 
        : base(container) 
    {
    }

    protected override void RegisterConsoleOutput()
    {
        RegisterSet<BetterTableSet>();
        RegisterSet<BetterTableDictionarySet>();
    }

    protected override void RegisterCommands() => 
        RegisterSet<Command2Set>();
}