using CLIHelper;
using CommandDotNet;
using Config.Wrapper;
using DIHelper;
using Serilog.Sinks.InMemory;
using Unity;

namespace Inventory.Min.Cli.App;

public class Bootstraper
    : IBootstraper
{
    private IDependencySuite? suite;
    private IBootstraper? booter;
    private IUnityContainer? container;

    public IDependencySuite? Suite => suite;
    public Guid AppId { get; private set; }

    public void CreateApp()
    {
        container = new UnityContainer()
            .AddExtension(new Diagnostic());
        var configSuite = new ConfigSuite(container);
        configSuite.Register();
        suite = new SettingSuite(
            container.Resolve<IConfigReader>())
                .GetSuite(container);
        booter = new DIHelper.Bootstraper(suite);
        booter.CreateApp();
        AppId = Guid.NewGuid();
    }

    public AppRunner GetAppRunner()
    {
        var prog = container.Resolve<IAppProgram>();
        var cmdCli = (CmdProgram)prog;
        return cmdCli.AppRunner; 
    }

    public InMemorySink GetLogger()
    {
        return container.Resolve<InMemorySink>("InMemorySink");
    }

    public IOutput GetOut()
    {
        return container.Resolve<IOutput>();
    }

    public void RunApp(params string[] args)
    {  
        ArgumentNullException.ThrowIfNull(booter);
        booter.RunApp(args);
    }
}