namespace WetherViewer;

public partial class MainPage : ContentPage
{
    private Picker _cityPicker;
    private ActivityIndicator _weatherLoadingIndicator;
    private Label _temperatureLabel;
    private Button _weatherButton;
    private Entry _countryEntry;
    public List<string> Citys {get; set;} = new List<string>()
    {
        "London",
        "Paris",
        "Kyiv",
    };

    public MainPage()
    {
        _cityPicker = CityPicker;
        _weatherLoadingIndicator = WeatherLoadingIndicator;
        _temperatureLabel = TemperatureLabel;
        _weatherButton = WeatherButton;
        _countryEntry = CountryEntry;
        InitializeComponent();
        BindingContext = this;
        _cityPicker.SelectedIndex = 0;
    }


    private async void OnClickWeatherButton(object sender, EventArgs e)
    {  
        _weatherLoadingIndicator.IsRunning = true;
        _weatherLoadingIndicator.IsVisible = false;
        var Temperature = await GetRandomValue();
        _temperatureLabel.Text = Temperature.ToString() + "°C";
        _weatherButton.IsVisible = true;
        _weatherLoadingIndicator.IsRunning = false;
    }

    private void OnCompletedCountryEntry(object sender, EventArgs e)
    {
        ((Entry)sender).Unfocus();
    }

    private void OnChangeTextCountryEntry(object sender , TextChangedEventArgs e) 
    {
        var isEnabled = _countryEntry.Text != string.Empty;

        _cityPicker.IsEnabled = isEnabled;
        if (isEnabled) 
        {
            //TODO:main logic get citys
        }
    }

        private async Task<int> GetRandomValue()
    {
        return await Task.Run(() =>
        {
            //TODO:call getWeather
            var rnd = new Random();
            Thread.Sleep(3000);
            return rnd.Next(0, 50);
        });
    }
}