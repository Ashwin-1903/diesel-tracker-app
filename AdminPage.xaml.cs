namespace DieselTrackerApp;

public partial class AdminPage : ContentPage
{
    public AdminPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        userList.ItemsSource = App.Database.GetAllUsers();
        historyList.ItemsSource = App.Database.GetAllHistory();
    }

    private void OnBlockClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var user = button.BindingContext as User;

        if (user != null)
        {
            App.Database.BlockUser(user.Username);
            DisplayAlert("Blocked", $"{user.Username} blocked", "OK");
            OnAppearing(); // refresh
        }
    }
}