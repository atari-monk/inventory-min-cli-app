using CommandDotNet;
using Config.Wrapper;
using DIHelper;
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
        var serviceSuite = new ServiceSuite(container);
        serviceSuite.Register();
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

    public void RunApp(params string[] args)
    {  
        ArgumentNullException.ThrowIfNull(booter);
        booter.RunApp(args);
    }
}