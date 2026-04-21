using SQLite;

namespace DieselTrackerApp;

public class History
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Username { get; set; }

    public string Vehicle { get; set; }
    public double Distance { get; set; }
    public string Road { get; set; }
    public string Driver { get; set; }

    public double Diesel { get; set; }
    public string Date { get; set; }
}