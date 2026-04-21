using Microcharts;
using Microcharts.Maui;
using SkiaSharp;

namespace DieselTrackerApp;

public partial class ChartPage : ContentPage
{
    public ChartPage(double vF, double rF, double dF)
    {
        InitializeComponent();

        var entries = new List<ChartEntry>
        {
            new ChartEntry((float)vF)
            {
                Label = "Vehicle",
                ValueLabel = vF.ToString("F2"),
                Color = SKColors.Red
            },
            new ChartEntry((float)rF)
            {
                Label = "Road",
                ValueLabel = rF.ToString("F2"),
                Color = SKColors.Blue
            },
            new ChartEntry((float)dF)
            {
                Label = "Driver",
                ValueLabel = dF.ToString("F2"),
                Color = SKColors.Yellow
            }
        };

        chartView.Chart = new PieChart
        {
            Entries = entries,
            LabelTextSize = 30
        };
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}