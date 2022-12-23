using WetherViewer.Models.API.Location.City;
using WetherViewer.Service.CitiesData;
using WetherViewer.Service.DiretionData;
using WetherViewer.Service.Exceptions;

using WetherViewer.Service.ServiceManager;
using WetherViewer.Service.WeatherData;

namespace WetherViewer;

public partial class MainPage : ContentPage
{
    private readonly ICitiesData _citiesData;
    private readonly IWeatherData _weatherData;
    private readonly IDirectionData _directionData;

    private readonly Border _borderCountryEntry;
    private readonly ActivityIndicator _cityLoadingIndicator;
    private readonly Picker _cityPicker;
    private readonly Entry _countryEntry;
    private readonly string[] _defaultCitysList;
    private readonly Brush _defaultColorBorder, _errorColorBorder;
    private readonly Image _imageWeather;
    private readonly Label _temperatureLabel, _pressureLabel, _humidityLabel, _windSpeedLabel, _windDirectionLabel;
    private readonly Button _weatherButton;
    private readonly ActivityIndicator _weatherLoadingIndicator;
    private string _country, _city;

    //TODO:Check spelling
    //TODO:Change location methods and functions

    public MainPage()
    {
        InitializeComponent();

        _citiesData = ServiceManager.GetService<ICitiesData>();
        _weatherData = ServiceManager.GetService<IWeatherData>();
        _directionData = ServiceManager.GetService<IDirectionData>();

        _weatherButton = WeatherButton;
        _cityPicker = CityPicker;
        _weatherLoadingIndicator = WeatherLoadingIndicator;
        _cityLoadingIndicator = CityLoadingIndecator;
        _temperatureLabel = TemperatureLabel;
        _humidityLabel = HumidityLabel;
        _pressureLabel = PressureLabel;
        _windSpeedLabel = WindSpeedLabel;
        _windDirectionLabel = WindDirectionLabel;
        _countryEntry = CountryEntry;
        _borderCountryEntry = BorderCounryEntry;
        _imageWeather = ImageWeather;

        _defaultCitysList = new string[] { "Write country" };
        _cityPicker.ItemsSource = _defaultCitysList;
        _cityPicker.SelectedIndex = 0;
        _defaultColorBorder = _borderCountryEntry.Stroke;
        _errorColorBorder = new Color(255, 0, 0);
        _countryEntry.Focus();
    }

    private static async Task AnimateError(VisualElement border)
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

    private void ClearWeather()
    {
        _temperatureLabel.Text = string.Empty;
        _temperatureLabel.IsVisible = false;

        _imageWeather.Source = string.Empty;
        _imageWeather.IsVisible = false;

        _pressureLabel.Text = string.Empty;
        _pressureLabel.IsVisible = false;

        _humidityLabel.Text = string.Empty;
        _humidityLabel.IsVisible = false;

        _windSpeedLabel.Text = string.Empty;
        _windSpeedLabel.IsVisible = false;

        _windDirectionLabel.Text = string.Empty;
        _windDirectionLabel.IsVisible = false;
    }

    private async void OnClickWeatherButton(object sender, EventArgs e)
    {
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;

        if (accessType == NetworkAccess.None || accessType == NetworkAccess.Unknown)
        {
            await DisplayAlert("Error", "You don't have internet. Pls check you connect.", "Close");
        }
        else
        {
            try
            {
                _temperatureLabel.IsVisible = false;
                _weatherButton.IsVisible = false;
                _weatherLoadingIndicator.IsRunning = true;
                _weatherLoadingIndicator.IsVisible = true;

                var weather = await _weatherData.GetWeather(_country.Trim(), _city.Trim());
                ShowWeather(weather);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Close");
            }
            finally
            {
                _weatherButton.IsVisible = true;
                _weatherLoadingIndicator.IsRunning = false;
                _weatherLoadingIndicator.IsVisible = false;
            }
        }
    }

    private async void OnCompletedCountryEntry(object sender, EventArgs e)
    {
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;

        if (accessType == NetworkAccess.None || accessType == NetworkAccess.Unknown)
        {
            await DisplayAlert("Error", "You don't have internet. Pls check you connect.", "Close");
        }
        else
        {
            var cityList = new List<string>();
            try
            {
                if (_countryEntry.Text.Trim() == string.Empty) throw new CountryNotFound("Country is Empty");

                SetEnebledControlElement(false);
                _countryEntry.Unfocus();
                _cityPicker.IsVisible = false;
                _cityLoadingIndicator.IsVisible = true;
                _cityLoadingIndicator.IsRunning = true;
                _country = _countryEntry.Text;

                var request = new CitiesBody(_country);
                cityList = await _citiesData.GetCities(request);

                _cityPicker.ItemsSource = cityList;
                _cityPicker.ItemsSource = _cityPicker.GetItemsAsArray();

                _cityPicker.SelectedIndex = 0;

                SetEnebledControlElement(true);
            }
            catch (CountryNotFound)
            {
                _borderCountryEntry.Stroke = _errorColorBorder;
                await AnimateError(_borderCountryEntry);

                _cityPicker.ItemsSource = _defaultCitysList;
                _cityPicker.ItemsSource = _cityPicker.GetItemsAsArray();
            }
            finally
            {
                _cityLoadingIndicator.IsRunning = false;
                _cityLoadingIndicator.IsVisible = false;

                _cityPicker.IsVisible = true;
            }
        }
    }

    private void OnSelectedItem(object sender, EventArgs e)
    {
        _city = (string)_cityPicker.SelectedItem;
        ClearWeather();
    }

    private void OnTextChangedCountryEntry(object sender, TextChangedEventArgs e)
    {
        ClearWeather();
        SetEnebledControlElement(false);
        _borderCountryEntry.Stroke = _defaultColorBorder;
        if (_countryEntry.Text.Trim() != string.Empty) return;

        _cityPicker.ItemsSource = _defaultCitysList;
        _cityPicker.ItemsSource = _cityPicker.GetItemsAsArray();
        _cityPicker.SelectedIndex = 0;

        SetEnebledControlElement(false);
    }

    private void SetEnebledControlElement(bool IsEnabled)
    {
        _weatherButton.IsEnabled = IsEnabled;
        _cityPicker.IsEnabled = IsEnabled;
    }

    private void ShowWeather(Models.API.Weather.Weather weather)
    {
        _temperatureLabel.Text = $"{weather.Main.Temperature}°C";
        _temperatureLabel.IsVisible = true;

        _imageWeather.Source = @$"http://openweathermap.org/img/wn/{weather.AboutWeather.Icon}@2x.png";
        _imageWeather.IsVisible = true;

        _pressureLabel.Text = $"{weather.Main.Pressure}hPa";
        _pressureLabel.IsVisible = true;

        _humidityLabel.Text = $"Humidity:{weather.Main.Humidity}%";
        _humidityLabel.IsVisible = true;

        _windSpeedLabel.Text = $"{weather.Wind.Speed}meter/sec";
        _windSpeedLabel.IsVisible = true;

        _windDirectionLabel.Text = $"Wind dir:{_directionData.GetDiretion(weather.Wind.Direction)}";
        _windDirectionLabel.IsVisible = true;
    }

}