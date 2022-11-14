using Thread = System.Threading.Thread;

namespace WetherViewer;

public partial class MainPage : ContentPage
{
    private readonly Button _weatherButton;
    private readonly Picker _cityPicker;
    private readonly ActivityIndicator _weatherLoadingIndicator;
    private readonly ActivityIndicator _cityLoadingIndicator;
    private readonly Label _temperatureLabel;
    private readonly Entry _countryEntry;
    private readonly Border _border;
    private readonly Brush DefaultColorBorder, ErrorColorBorder;
    private string[] citys;
     
    public MainPage()
    {
        InitializeComponent();
        _weatherButton = WeatherButton;
        _cityPicker = CityPicker;
        _weatherLoadingIndicator = WeatherLoadingIndicator;
        _cityLoadingIndicator = CityLoadingIndecator;
        _temperatureLabel = TemperatureLabel;
        _countryEntry = CountryEntry;
        _border = Border;
        
        DefaultColorBorder = _border.Stroke;
        _countryEntry.Text = "";
        ErrorColorBorder = new Color(255, 0, 0);
        _countryEntry.Focus();
    }

    private async void OnClickWeatherButton(object sender, EventArgs e)
    {
        _weatherButton.IsVisible = false;
        _weatherLoadingIndicator.IsRunning = true;
        _weatherLoadingIndicator.IsVisible = true;
        var Temperature = await GetWeather();
        _temperatureLabel.Text = Temperature.ToString() + "°C";
        _weatherButton.IsVisible = true;
        _weatherLoadingIndicator.IsRunning = false;
        _weatherLoadingIndicator.IsVisible = false;
    }

    private async void OnCompletedCountryEntry(object sender, EventArgs e)
    {
        Entry textField = (Entry)sender;
        if (textField.Text.Trim() == string.Empty)
        {
            await ErrorBorder(_border);
            return;
        }
        textField.Unfocus();
        _cityPicker.IsVisible = false;
        _cityLoadingIndicator.IsVisible = true;
        _cityLoadingIndicator.IsRunning = true;
        var isDone = await GetCitys(_countryEntry.Text);
        _cityLoadingIndicator.IsRunning = false;
        _cityLoadingIndicator.IsVisible = false;
        _cityPicker.ItemsSource = citys;
        _cityPicker.SelectedIndex = 0;
        _cityPicker.IsVisible = true;
        _cityPicker.IsEnabled = isDone;
        _weatherButton.IsEnabled = isDone;
        if (!isDone) await ErrorBorder(_border);
    }

    private void OnTextChangedCountryEntry(object sender, TextChangedEventArgs e)
    {
        Entry textField = (Entry)sender;
        _border.Stroke = DefaultColorBorder;
        if (textField.Text.Trim() != string.Empty) return;
        _cityPicker.IsEnabled = false;
        citys = Array.Empty<string>();
        _cityPicker.SelectedIndex = -1;
        _cityPicker.ItemsSource = citys;
        _weatherButton.IsEnabled = false;
        _temperatureLabel.Text = "Temperature will be here!";
    }

    //TODO:SearchCity
    private async Task<bool> GetCitys(string Country)
    {
        return await Task<bool>.Run(() =>
        {
            Thread.Sleep(3000);
            switch (Country.Trim().ToLower())
            {
                case "ukraine":
                    citys = new string[] { "Kyiv", "Nikolaev", "Herson" };
                    break;
                case "usa":
                    citys = new string[] { "Washington", "New-York" };
                    break;
                case "hallownest":
                    citys = new string[] { "City Tear" };
                    break;
                default:
                    return false;
            }
            return true;
        });

    }

    //TODO:call getWeather
    private async Task<int> GetWeather()
    {
        return await Task.Run(() =>
        {
            Thread.Sleep(3000);
            return new Random().Next(0, 50);
        });
    }

    private async Task ErrorBorder(Border view)
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