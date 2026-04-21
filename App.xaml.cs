using Microsoft.Maui.Storage;
using System.IO;

namespace DieselTrackerApp;

public partial class App : Application
{
    public static DatabaseHelper Database;

    public App()
    {
        InitializeComponent();

        string path = Path.Combine(FileSystem.AppDataDirectory, "app.db");
        Database = new DatabaseHelper(path);

        bool isLogged = Preferences.Get("IsLoggedIn", false);

        if (isLogged)
            MainPage = new NavigationPage(new DashboardPage());
        else
            MainPage = new NavigationPage(new MainPage());
    }
}