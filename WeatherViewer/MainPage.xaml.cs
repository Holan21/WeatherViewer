namespace WetherViewer;

public partial class MainPage : ContentPage
{
    private readonly Button _weatherButton;
    private readonly Picker _cityPicker;
    private readonly ActivityIndicator _weatherLoadingIndicator;
    private readonly ActivityIndicator _cityLoadingIndicator;

    public List<string> Citys {get; set;} = new List<string>()
    {
        "London",
        "Paris",
        "Kyiv",
    };

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
        _weatherButton = WeatherButton;
        _cityPicker = CityPicker;
        _weatherLoadingIndicator = WeatherLoadingIndicator;
        _cityLoadingIndicator = CityLoadingIndecator;
        _cityPicker.SelectedIndex = 0;
    }

    private async void OnClickWeatherButton(object sender, EventArgs e)
    {  
        _weatherButton.IsVisible = false;
        _weatherLoadingIndicator.IsRunning = true;
        _weatherLoadingIndicator.IsVisible = true;   
        var Temperature = await GetRandomValue();
        TemperatureLabel.Text = Temperature.ToString() + "°C";
        _weatherButton.IsVisible = true;
        _weatherLoadingIndicator.IsRunning = false;
        _weatherLoadingIndicator.IsVisible = false;
    }

    private async void OnCompletedCountryEntry(object sender, EventArgs e)
    {
        ((Entry)sender).Unfocus();
        _cityPicker.IsVisible = false;
        _cityLoadingIndicator.IsVisible = true;
        _cityLoadingIndicator.IsRunning = true;
        await Task.Run(() => {
            Thread.Sleep(3000);
        });
        _cityLoadingIndicator.IsRunning = false;
        _cityLoadingIndicator.IsVisible = false;
        _cityPicker.IsVisible = true;
        _cityPicker.IsEnabled = true;
    }

    private void OnTextChangedCountryEntry(object sender, TextChangedEventArgs e)
    {
        if (((Entry)sender).Text == string.Empty) _cityPicker.IsEnabled = false;
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