using SQLite.Net;

namespace FirstAid.Database
{
    public interface IDatabaseConnection
    {
        // This interface is used to get the platform specific SQLite connection.
        SQLiteConnection GetConnection();
    }
}
