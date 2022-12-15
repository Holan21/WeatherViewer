namespace WetherViewer.Service
{
    public static class ServiceManager
    {
        public static TService GetSerive<TService>() => Current.GetService<TService>();

        private static IServiceProvider Current =>
#if WINDOWS
            MauiWinUIApplication.Current.Services;
#elif ANDROID
           MauiApplication.Current.Services;
#else 
           null;
#endif
    }
}

