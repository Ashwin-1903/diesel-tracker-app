using Microsoft.Maui.Storage;

namespace DieselTrackerApp;

public partial class HistoryPage : ContentPage
{
    public HistoryPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        string user = Preferences.Get("Username", "");
        historyList.ItemsSource = App.Database.GetHistory(user);
    }
}