using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace WeekTwo
{
    public class DatabaseManager
    {
        readonly SQLiteConnection Connection = DependencyService.Get<IDBInterface>().CreateConnection();
        public DatabaseManager()
        {
        }

        public List<Movie> GetAllMovies()
        {
            SQLiteCommand command = new SQLiteCommand(Connection)
            {
                CommandText = $"SELECT * FROM Movie"
            };
            return command.ExecuteQuery<Movie>();
        }

        public void AddOrUpdateMovie(string title, string description, string imagesource)
        {
            SQLiteCommand command = new SQLiteCommand(Connection)
            {
                CommandText = !DoesMovieExist(title) ?
                $"INSERT INTO Movie(Title, Description, ImageSource) VALUES(\"{title}\", \"{description}\", \"{imagesource}\")" :
                $"UPDATE Movie SET Description = \"{description}\", ImageSource = \"{imagesource}\" WHERE Title = \"{title}\""
            };
            command.ExecuteNonQuery();
        }

        public void DeleteMovie(string title)
        {
            SQLiteCommand command = new SQLiteCommand(Connection)
            {
                CommandText = $"DELETE FROM Movie WHERE Title = \"{title}\""
            };
            command.ExecuteNonQuery();
        }
        public bool DoesMovieExist(string title)
        {
            SQLiteCommand command = new SQLiteCommand(Connection)
            {
                CommandText = $"SELECT Title FROM Movie WHERE Title = \"{title}\""
            };
            return command.ExecuteQuery<Movie>().Count != 0;
        }

        public int GetMovieID(string title)
        {
            SQLiteCommand command = new SQLiteCommand(Connection)
            {
                CommandText = $"SELECT MovieID FROM Movie WHERE Title = \"{title}\""
            };
            return command.ExecuteNonQuery();
        }
    }
}
