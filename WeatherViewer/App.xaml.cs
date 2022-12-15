namespace WetherViewer;
public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Routing.RegisterRoute("HeadPage", typeof(MainPage));
        MainPage = new AppShell();
    }
}