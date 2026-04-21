namespace DieselTrackerApp;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
    }

    private async void OnCreateClicked(object sender, EventArgs e)
    {
        var user = new User
        {
            Username = usernameEntry.Text,
            Password = passwordEntry.Text
        };

        App.Database.AddUser(user);

        await DisplayAlert("Success", "Account Created", "OK");
        await Navigation.PopAsync();
    }
}