using System.IO;
using SQLite;
using Environment = System.Environment;

using Foundation;
using Week4.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseService))]
namespace Week4.iOS
{
    public class DatabaseService : IDBInterface
    { 
        public SQLiteConnection CreateConnection()
        {
            var sqliteFilename = "MovieDatabase.db";

            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
                Directory.CreateDirectory(libFolder);

            string path = Path.Combine(libFolder, sqliteFilename);

            if (!File.Exists(path))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("MovieDatabase", "db");
                File.Copy(existingDb, path);
            }
            return new SQLiteConnection(path, false);
        }
    }
}