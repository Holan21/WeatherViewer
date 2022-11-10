
using System.Collections;

namespace WetherViewer;

public partial class MainPage : ContentPage
{
  
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
        getCityP.SelectedIndex = 0;
    }

    public List<string> Citys { get; set; } = new List<string>()
    {
        "London",
        "Paris",
        "Kyiv",
    };

    private async void OnClickGetWeather(object sender, EventArgs e)
    {  
        var runningState = weatherLoadingIndicator.IsRunning;
        weatherLoadingIndicator.IsRunning = !runningState;
        getWeatherBtn.IsVisible = false;
        var testTemperatureValue = await GetRandomValue();
        temperatureValue.Text = testTemperatureValue.ToString() + "°C";
        getWeatherBtn.IsVisible = true;
        weatherLoadingIndicator.IsRunning = false;
        
    }
    //unfocus if you press enter
    private void OnCompletedCountryE(object sender, EventArgs e)
    {
        Country.Unfocus();
        getCityP.IsEnabled = Country.Text != "";
    }

        private async Task<int> GetRandomValue()
    {
        return await Task.Run(() =>
        {
            //call getWeather
            var rnd = new Random();
            Thread.Sleep(3000);
            return rnd.Next(0, 50);
        });
    }
}