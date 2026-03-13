using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;

namespace Match_picture
{
    public class DatabaseManager
    {
        private string connectionString = "Data Source=leaderboard.db;Version=3;FailIfMissing=False;";

        public DatabaseManager()
        {
            InitializeDatabase();
        }

        // Δημιουργεί την βάση Δεδομένων σε περίπτωση που δεν έχει δημιουργηθεί
        private void InitializeDatabase()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"CREATE TABLE IF NOT EXISTS Leaderboard(
                                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                 PlayerName TEXT,
                                 Attempts INTEGER,
                                 FullTime INTEGER)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Μέθοδος αποθήκευσης σκορ του εκάστοτε παίχτη
        public void SaveScore(string name, int attempts, int time)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Leaderboard (PlayerName, Attempts, FullTime) VALUES (@name, @attempts, @time)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@attempts", attempts);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // Εμφανίζει τους πρώτους 10 παίχτες σύμφωνα με το χρόνο που έκαναν και τις προσπάθειες που επιχείρησαν
        public DataTable GetLeaderboard()
        {
            DataTable dt = new DataTable();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT PlayerName, Attempts, FullTime FROM Leaderboard ORDER BY Attempts ASC, FullTime ASC LIMIT 10";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }
    }
}