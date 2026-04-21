using SQLite;

namespace DieselTrackerApp;

public class DatabaseHelper
{
    private readonly SQLiteConnection _db;

    public DatabaseHelper(string path)
    {
        _db = new SQLiteConnection(path);
        _db.CreateTable<User>();
        _db.CreateTable<History>();
    }

    public int AddUser(User user)
    {
        return _db.Insert(user);
    }

    public User GetUser(string username, string password)
    {
        return _db.Table<User>()
            .FirstOrDefault(x => x.Username == username && x.Password == password);
    }

    public int AddHistory(History h)
    {
        return _db.Insert(h);
    }

    public List<History> GetHistory(string username)
    {
        return _db.Table<History>()
            .Where(x => x.Username == username)
            .ToList();
    }

    public List<User> GetAllUsers()
    {
        return _db.Table<User>().ToList();
    }

    public List<History> GetAllHistory()
    {
        return _db.Table<History>()
                  .OrderByDescending(x => x.Id)
                  .ToList();
    }

    public void BlockUser(string username)
    {
        var user = _db.Table<User>().FirstOrDefault(x => x.Username == username);
        if (user != null)
        {
            user.IsBlocked = true;
            _db.Update(user);
        }
    }
}