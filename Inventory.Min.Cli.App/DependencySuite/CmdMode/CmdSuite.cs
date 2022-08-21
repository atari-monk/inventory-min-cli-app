using CommandDotNet.Unity.Helper;
using Unity;

namespace Inventory.Min.Cli.App.CmdMode;

public class CmdSuite 
    : AppSuite
{
    public CmdSuite(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override void RegisterProgram() =>
        RegisterSet<AppProgSet<CmdProgram>>();
}