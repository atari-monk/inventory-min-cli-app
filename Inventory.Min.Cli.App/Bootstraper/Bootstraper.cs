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
    private IDependencySuite configSuite;
    private IDependencySuite mainSuite;
    private IBootstraper booter;
    protected IUnityContainer Container;

    public IDependencySuite MainSuite => mainSuite;
    public Guid AppId { get; private set; }

    public Bootstraper()
    {
        Container = new UnityContainer()
            .AddExtension(new Diagnostic());
        configSuite = new ConfigSuite(Container);
        configSuite.Register();
        mainSuite = GetMainAppSuite();
        booter = new DIHelper.Bootstraper(mainSuite);
    }

    protected virtual IDependencySuite GetMainAppSuite()
    {
        return new SettingSuite(
            Container.Resolve<IConfigReader>())
                .GetSuite(Container);
    }

    public void CreateApp()
    {
        booter.CreateApp();
        AppId = Guid.NewGuid();
    }

    public void RunApp(params string[] args)
    {  
        booter.RunApp(args);
    }

    public AppRunner GetAppRunner()
    {
        var prog = Container.Resolve<IAppProgram>();
        var cmdCli = (CmdProgram)prog;
        return cmdCli.AppRunner; 
    }

    public InMemorySink GetLogger()
    {
        return Container.Resolve<InMemorySink>("InMemorySink");
    }

    public IOutput GetOut()
    {
        return Container.Resolve<IOutput>();
    }
}