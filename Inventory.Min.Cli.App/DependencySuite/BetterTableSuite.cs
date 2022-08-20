using DIHelper.Unity;
using Inventory.Min.BetterTable;
using Unity;

namespace Inventory.Min.Cli.App;

public class BetterTableSuite 
    : UnityDependencySuite
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
}