using FirstAid.Database;
using System.Diagnostics;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Xamarin.Forms.Dependency(typeof(FirstAid.Droid.AndroidDatabase))]
namespace FirstAid.Droid
{
    class AndroidDatabase : IDatabaseConnection
    {
        public AndroidDatabase() { }

        public SQLiteConnection GetConnection()
        {
            Debug.WriteLine("Getting the database from Android");
            // Determine the path of the database file and return the SQLite connection.
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "FirstAid.db3");

            Debug.WriteLine("Returning database file: " + dbPath);
            return new SQLiteConnection(new SQLitePlatformAndroid(), dbPath);
        }
    }
}