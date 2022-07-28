using CommandDotNet;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Serilog;

namespace Inventory.Min.Cli.App;

public class CommandCli 
    : AppProgUnity<CommandCli>
{
    [Subcommand]
    public InventoryCommands? InventoryCommands { get; set; }

    public CommandCli(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }
}