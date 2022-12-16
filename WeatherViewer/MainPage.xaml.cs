using WetherViewer.Service;
using WetherViewer.Service.CitiesData;
using WetherViewer.Service.Exceptions;
using WetherViewer.Service.WeatherData;

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
    private readonly Brush _defaultColorBorder, _errorColorBorder;
    private readonly string[] _defaultCitysList;
    private string _country, _city;

    private readonly ICitiesData _citiesData;
    private readonly IWeatherData _weatherData;

    public MainPage()
    {
        InitializeComponent();

        _citiesData = ServiceManager.GetSerive<ICitiesData>();
        _weatherData = ServiceManager.GetSerive<IWeatherData>();

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
        _defaultColorBorder = _borderCountryEntry.Stroke;
        _errorColorBorder = new Color(255, 0, 0);
        _countryEntry.Focus();
    }

    private async void OnClickWeatherButton(object sender, EventArgs e)
    {
        _temperatureLabel.IsVisible = false;
        _weatherButton.IsVisible = false;
        _weatherLoadingIndicator.IsRunning = true;
        _weatherLoadingIndicator.IsVisible = true;

        var weather = await _weatherData.GetWeather(_country, _city);
        _temperatureLabel.Text = $"{weather.Main.Temperature}°C";

        _weatherButton.IsVisible = true;
        _weatherLoadingIndicator.IsRunning = false;
        _weatherLoadingIndicator.IsVisible = false;
        _temperatureLabel.IsVisible = true;
    }

    private async void OnCompletedCountryEntry(object sender, EventArgs e)
    {
        try
        {
            if (_countryEntry.Text.Trim() == string.Empty) throw new CountryNotFound("Country is Empty");
            _countryEntry.Unfocus();
            _cityPicker.IsVisible = false;
            _cityLoadingIndicator.IsVisible = true;
            _cityLoadingIndicator.IsRunning = true;
            _country = _countryEntry.Text;
            var cityList = await _citiesData.GetCities(_country);

            _cityLoadingIndicator.IsRunning = false;
            _cityLoadingIndicator.IsVisible = false;

            _cityPicker.ItemsSource = cityList;
            _cityPicker.ItemsSource = _cityPicker.GetItemsAsArray();

            _cityPicker.SelectedIndex = 0;
            _cityPicker.IsVisible = true;
            _cityPicker.IsEnabled = true;
            _weatherButton.IsEnabled = true;
        }
        catch (CountryNotFound)
        {
            _cityLoadingIndicator.IsRunning = false;
            _cityLoadingIndicator.IsVisible = false;
            _cityPicker.IsVisible = true;

            _borderCountryEntry.Stroke = _errorColorBorder;
            await AnimateError(_borderCountryEntry);
        }
    }
    private void OnSelectedItem(object sender, EventArgs e)
    {
        _city = (string)_cityPicker.SelectedItem;
    }

    private void OnTextChangedCountryEntry(object sender, TextChangedEventArgs e)
    {
        _borderCountryEntry.Stroke = _defaultColorBorder;
        if (_countryEntry.Text.Trim() != string.Empty) return;
        _cityPicker.IsEnabled = false;

        _cityPicker.SelectedIndex = -1;
        _cityPicker.ItemsSource = _defaultCitysList;
        _weatherButton.IsEnabled = false;
        _temperatureLabel.Text = "weather will be here!";
    }

    private async Task AnimateError(VisualElement border)
    {
        try
        {
            for (int i = 4; i > 0; i--)
            {
                await border.TranslateTo(i, 0, 40);
                await border.TranslateTo(-i, 0, 80);
                await border.TranslateTo(0, 0, 40);
            }
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
}