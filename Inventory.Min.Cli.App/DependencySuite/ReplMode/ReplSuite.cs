using CommandDotNet.Unity.Helper;
using Unity;

namespace Inventory.Min.Cli.App.ReplMode;

public class ReplSuite 
    : AppSuite
{
    public ReplSuite(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override void RegisterProgram() =>
        RegisterSet<AppProgSet<ReplProgram>>();
}