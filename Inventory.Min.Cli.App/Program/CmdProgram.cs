using CommandDotNet;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Serilog;

namespace Inventory.Min.Cli.App;

public class CmdProgram 
    : AppProgUnity<CmdProgram>
{
    [Subcommand]
    public ItemCommands? InventoryCommands { get; set; }

    public CmdProgram(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }
}