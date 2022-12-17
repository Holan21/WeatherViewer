using WetherViewer.Data.APIProviders.City;
using WetherViewer.Data.APIProviders.Location;
using WetherViewer.Data.APIProviders.Weather;
using WetherViewer.Service.CitiesData;
using WetherViewer.Service.DiretionData;
using WetherViewer.Service.LocationData;
using WetherViewer.Service.WeatherData;

namespace WetherViewer;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .RegisterAppServices();
        return builder.Build();
    }
    private static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ILocationData, LocationJSONAPI>();
        mauiAppBuilder.Services.AddSingleton<ICitiesData, CitiesJSONAPI>();
        mauiAppBuilder.Services.AddSingleton<IWeatherData, WeatherJSONAPI>();
        mauiAppBuilder.Services.AddSingleton<IDirectionData, DirectionData>();

        return mauiAppBuilder;
    }
}