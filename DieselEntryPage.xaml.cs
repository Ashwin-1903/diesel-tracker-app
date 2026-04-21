using Microsoft.Maui.Storage;

namespace DieselTrackerApp;

public partial class DieselEntryPage : ContentPage
{
    public DieselEntryPage()
    {
        InitializeComponent();
    }

    private async void OnCalculateDiesel(object sender, EventArgs e)
    {
        // 🔹 Input values
        double distance = double.TryParse(distanceEntry.Text, out var d) ? d : 0;
        double rpm = double.TryParse(rpmEntry.Text, out var r) ? r : 1500;
        double weight = double.TryParse(weightEntry.Text, out var w) ? w : 5;
        double speed1 = double.TryParse(speedFrom.Text, out var s1) ? s1 : 40;
        double speed2 = double.TryParse(speedTo.Text, out var s2) ? s2 : 60;
        double tyre = double.TryParse(tyreEntry.Text, out var t) ? t : 32;
        double engine = double.TryParse(engineEntry.Text, out var eVal) ? eVal : 7;

        double baseMileage = 5.0;

        // 🔹 Vehicle factor
        double vehicleFactor = 1.0;
        string vehicle = vehiclePicker.SelectedItem?.ToString() ?? "Lorry";

        if (vehicle == "Tipper") vehicleFactor = 0.8;
        else if (vehicle == "Trailer") vehicleFactor = 0.7;

        // 🔹 Road factor
        double roadFactor = 1.0;
        string road = roadPicker.SelectedItem?.ToString() ?? "Highway";

        if (road == "Highway") roadFactor = 1.2;
        else if (road == "City") roadFactor = 0.9;
        else if (road == "Village") roadFactor = 0.8;
        else if (road == "Hilly") roadFactor = 0.7;

        // 🔹 Driver factor
        double driverFactor = 1.0;
        string driver = driverPicker.SelectedItem?.ToString() ?? "Normal";

        if (driver == "Smooth") driverFactor = 1.2;
        else if (driver == "Aggressive") driverFactor = 0.7;

        // 🔹 Other effects
        double rpmFactor = rpm > 2500 ? 0.8 : rpm < 1500 ? 1.1 : 1.0;
        double weightFactor = weight > 15 ? 0.7 : weight < 5 ? 1.2 : 1.0;

        double avgSpeed = (speed1 + speed2) / 2;
        double speedFactor = avgSpeed > 80 ? 0.8 : avgSpeed < 40 ? 0.9 : 1.1;

        double tyreFactor = tyre < 30 ? 0.8 : 1.0;
        double engineFactor = engine < 5 ? 0.7 : engine > 8 ? 1.2 : 1.0;

        // 🔥 Final mileage
        double finalMileage = baseMileage * vehicleFactor * roadFactor * driverFactor *
                              rpmFactor * weightFactor * speedFactor * tyreFactor * engineFactor;

        if (finalMileage <= 0) finalMileage = 1;

        double diesel = distance / finalMileage;

        // 🔥 Suggestions
        string suggestion = "";

        if (driver == "Aggressive")
            suggestion += "Drive smoothly to save fuel.\n";

        if (road == "City")
            suggestion += "Avoid heavy traffic routes.\n";

        if (tyre < 30)
            suggestion += "Maintain proper tyre pressure.\n";

        if (rpm > 2500)
            suggestion += "Reduce RPM for better mileage.\n";

        if (engine < 5)
            suggestion += "Engine servicing required.\n";

        if (string.IsNullOrEmpty(suggestion))
            suggestion = "Everything looks good. Optimal performance!";

        // 🔥 Save history
        App.Database.AddHistory(new History
        {
            Username = Preferences.Get("Username", ""),
            Vehicle = vehicle,
            Distance = distance,
            Road = road,
            Driver = driver,
            Diesel = diesel,
            Date = DateTime.Now.ToString("dd-MM-yyyy HH:mm")
        });

        // 🔥 Navigate to result page
        await Navigation.PushAsync(
            new ResultPage(diesel, suggestion, vehicleFactor, roadFactor, driverFactor)
        );
    }

    // 🔴 Logout
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        Preferences.Clear();
        await Navigation.PushAsync(new MainPage());
    }
}