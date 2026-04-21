namespace DieselTrackerApp;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();
    }

    private async void OnDieselClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DieselEntryPage());
    }

    private async void OnHistoryClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistoryPage());
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        Preferences.Clear();
        await Navigation.PushAsync(new MainPage());
    }
}