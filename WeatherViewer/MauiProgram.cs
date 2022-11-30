using WetherViewer.Data.APIProviders.City;
using WetherViewer.Data.APIProviders.Location;
using WetherViewer.Data.APIProviders.Weather;
using WetherViewer.Service.CitiesData;
using WetherViewer.Service.LocationData;
using WetherViewer.Service.WeatherData;

namespace WetherViewer;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.Services.AddScoped<IWeatherData, WeatherJSONAPI>();
        builder.Services.AddScoped<ICitiesData, CityJSONAPI>();
        builder.Services.AddScoped<ILocationData, LocationJSONAPI>();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        return builder.Build();
    }
}