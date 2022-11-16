using Thread = System.Threading.Thread;
using WetherViewer.Service.CitiesData;
using Location = WetherViewer.Models.API.Location;
using WetherViewer.Service.WeatherData;
using WetherViewer.Models.API;

namespace WetherViewer;


public partial class MainPage : ContentPage
{
    private readonly Button _weatherButton;
    private readonly Picker _cityPicker;
    private readonly ActivityIndicator _weatherLoadingIndicator;
    private readonly ActivityIndicator _cityLoadingIndicator;
    private readonly Label _temperatureLabel;
    private readonly Entry _countryEntry;
    private readonly Border _borderCountryEntry;
    private readonly Brush DefaultColorBorder, ErrorColorBorder;
    private readonly string[] _defaultCitysList;
    private string _country;
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
        _weatherButton = WeatherButton;
        _cityPicker = CityPicker;
        _weatherLoadingIndicator = WeatherLoadingIndicator;
        _cityLoadingIndicator = CityLoadingIndecator;
        _temperatureLabel = TemperatureLabel;
        _countryEntry = CountryEntry;
        _borderCountryEntry = BorderCounryEntry;

        _defaultCitysList = new string[] { "Write country" };
        _cityPicker.ItemsSource = _defaultCitysList;
        _cityPicker.SelectedIndex = 0;
        DefaultColorBorder = _borderCountryEntry.Stroke;
        ErrorColorBorder = new Color(255, 0, 0);
        _countryEntry.Focus();
    }

    private async void OnClickWeatherButton(object sender, EventArgs e)
    {
        _temperatureLabel.IsVisible = false;
        _weatherButton.IsVisible = false;
        _weatherLoadingIndicator.IsRunning = true;
        _weatherLoadingIndicator.IsVisible = true;

        var Temperature = await GetWeather();
        _temperatureLabel.Text = Temperature.Temperature.ToString() + "°C";

        _weatherButton.IsVisible = true;
        _weatherLoadingIndicator.IsRunning = false;
        _weatherLoadingIndicator.IsVisible = false;
        _temperatureLabel.IsVisible = true;
    }

    private async void OnCompletedCountryEntry(object sender, EventArgs e)
    {
        if (_countryEntry.Text.Trim() == string.Empty)
        {
            await SetErrorBorderAndAnimate(_borderCountryEntry);
            return;
        }
        _countryEntry.Unfocus();
        _cityPicker.IsVisible = false;
        _cityLoadingIndicator.IsVisible = true;
        _cityLoadingIndicator.IsRunning = true;
        _country = _countryEntry.Text;
        var cityList = await GetCitys(_country);
        var isCityFounded = cityList.Count > 0;

        _cityLoadingIndicator.IsRunning = false;
        _cityLoadingIndicator.IsVisible = false;

        _cityPicker.ItemsSource = cityList;
        _cityPicker.ItemsSource = _cityPicker.GetItemsAsArray();

        _cityPicker.SelectedIndex = 0;
        _cityPicker.IsVisible = true;
        _cityPicker.IsEnabled = isCityFounded;
        _weatherButton.IsEnabled = isCityFounded;

        if (!isCityFounded) await SetErrorBorderAndAnimate(_borderCountryEntry);
    }

    private void OnTextChangedCountryEntry(object sender, TextChangedEventArgs e)
    {
        _borderCountryEntry.Stroke = DefaultColorBorder;
        if (_countryEntry.Text.Trim() != string.Empty) return;
        _cityPicker.IsEnabled = false;

        _cityPicker.SelectedIndex = -1;
        _cityPicker.ItemsSource = _defaultCitysList;
        _weatherButton.IsEnabled = false;
        _temperatureLabel.Text = "Temperature will be here!";
    }

    private async Task<List<string>> GetCitys(string country)
    {
        return await Task.Run(() =>
        {
            Thread.Sleep(3000);
            CitiesData CityData = new CitiesData();
            return CityData.getCitys(country);
        });
    }

    private async Task<Weather> GetWeather()
    {
        Location location = new Location(_country, (string)_cityPicker.SelectedItem);
        WeatherData weatherData = new WeatherData(location);
        Weather weather = await weatherData.GetWeather();
        return weather;
    }

    private async Task SetErrorBorderAndAnimate(Border view)
    {
        view.Stroke = ErrorColorBorder;
        await AnimateError(view);
    }

    private async Task<bool> AnimateError(VisualElement view)
    {
        try
        {
            for (int i = 4; i > 0; i--)
            {
                await view.TranslateTo(i, 0, 40);
                await view.TranslateTo(-i, 0, 80);
                await view.TranslateTo(0, 0, 40);
            }
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}