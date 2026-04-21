namespace DieselTrackerApp;

public partial class AdminLoginPage : ContentPage
{
    public AdminLoginPage()
    {
        InitializeComponent();
    }

    private async void OnAdminLoginClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;

        // 🔐 YOUR ADMIN LOGIN
        if (username == "Admin" && password == "NOVA")
        {
            await Navigation.PushAsync(new AdminPage());
        }
        else
        {
            await DisplayAlert("Error", "Invalid Admin Login", "OK");
        }
    }
}