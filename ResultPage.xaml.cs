namespace DieselTrackerApp;

public partial class ResultPage : ContentPage
{
    double vehicleFactor;
    double roadFactor;
    double driverFactor;

    public ResultPage(double diesel, string suggestion,
                      double vF, double rF, double dF)
    {
        InitializeComponent();

        dieselLabel.Text = $"Diesel: {diesel:F2} L";
        suggestionLabel.Text = suggestion;

        vehicleFactor = vF;
        roadFactor = rF;
        driverFactor = dF;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnChartClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(
            new ChartPage(vehicleFactor, roadFactor, driverFactor)
        );
    }
}