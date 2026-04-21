using SQLite;

namespace DieselTrackerApp;

public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }

    public bool IsBlocked { get; set; } = false;
}