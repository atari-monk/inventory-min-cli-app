using CommandDotNet;
using CommandDotNet.Repl;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Serilog;

namespace Inventory.Min.Cli.App;

public class ReplProgram 
    : AppProgUnity<ReplProgram>
{
	private static bool inSession;

    [Subcommand]
    public ItemCommands? LogCommands { get; set; }

    public ReplProgram(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }

    [DefaultCommand()]
    public void StartSession(
        CommandContext context,
        ReplSession replSession)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (replSession is null)
        {
            throw new ArgumentNullException(nameof(replSession));
        }

        if (inSession == false)
        {
            context.Console.WriteLine("start session");
            inSession = true;
            replSession.Start();
        }
        else
        {
            context.Console.WriteLine($"no session {inSession}");
            context.ShowHelpOnExit = true;
        }
    }
}