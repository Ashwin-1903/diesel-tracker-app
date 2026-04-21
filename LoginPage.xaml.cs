using Microsoft.Maui.Storage;

namespace DieselTrackerApp;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var user = App.Database.GetUser(usernameEntry.Text, passwordEntry.Text);

        if (user != null)
        {
            if (user.IsBlocked)
            {
                await DisplayAlert("Blocked", "You are blocked by admin", "OK");
                return;
            }

            Preferences.Set("IsLoggedIn", true);
            Preferences.Set("Username", user.Username);

            await Navigation.PushAsync(new DashboardPage());
        }
        else
        {
            await DisplayAlert("Error", "Invalid Login", "OK");
        }
    }
}