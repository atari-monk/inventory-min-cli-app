using CLIHelper;
using CommandDotNet;
using Config.Wrapper;
using DIHelper;
using Microsoft.Extensions.Logging;
using Serilog.Sinks.InMemory;
using Unity;

namespace Inventory.Min.Cli.App;

public class InventoryBootstraper
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
        suite = new SuiteConfig(
            container.Resolve<IConfigReader>())
                .GetSuite(container);
        booter = new Bootstraper(suite);
        booter.CreateApp();
        AppId = Guid.NewGuid();
    }

    public AppRunner GetAppRunner()
    {
        var prog = container.Resolve<IAppProgram>();
        var cmdCli = (CommandCli)prog;
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