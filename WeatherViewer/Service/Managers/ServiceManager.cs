namespace WetherViewer.Service.ServiceManager
{
    public static class ServiceManager
    {
        public static T GetService<T>() => Current.GetService<T>();

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