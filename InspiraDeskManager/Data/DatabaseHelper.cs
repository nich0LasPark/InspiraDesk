// Create or update: InspiraDeskManager/Data/DatabaseHelper.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using InspiraQuotesManager.Models;

namespace InspiraQuotesManager.Data
{
    public class DatabaseHelper
    {
        private string dbPath = "InspiraQuotes.db";
        private string connectionString => $"Data Source={dbPath};Version=3;";

        public DatabaseHelper()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Create Quotes table
                    string createQuotesTable = @"
                    CREATE TABLE IF NOT EXISTS Quotes (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        QuoteText TEXT NOT NULL,
                        Author TEXT,
                        Category TEXT
                    )";

                    // Create Users table
                    string createUsersTable = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL
                    )";

                    using (var command = new SQLiteCommand(createQuotesTable, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(createUsersTable, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        #region Quote Methods
        public List<Quote> GetAllQuotes()
        {
            var quotes = new List<Quote>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, QuoteText, Author, Category FROM Quotes";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            quotes.Add(new Quote
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                QuoteText = reader["QuoteText"].ToString(),
                                Author = reader["Author"].ToString(),
                                Category = reader["Category"].ToString()
                            });
                        }
                    }
                }
            }

            return quotes;
        }

        public void AddQuote(Quote quote)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Quotes (QuoteText, Author, Category) VALUES (@QuoteText, @Author, @Category)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@QuoteText", quote.QuoteText);
                    command.Parameters.AddWithValue("@Author", quote.Author);
                    command.Parameters.AddWithValue("@Category", quote.Category);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateQuote(Quote quote)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Quotes SET QuoteText = @QuoteText, Author = @Author, Category = @Category WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", quote.Id);
                    command.Parameters.AddWithValue("@QuoteText", quote.QuoteText);
                    command.Parameters.AddWithValue("@Author", quote.Author);
                    command.Parameters.AddWithValue("@Category", quote.Category);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteQuote(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Quotes WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region User Methods
        public bool UserExists(string username)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public bool ValidateUser(string username, string password)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public void AddUser(User user)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Username, Password FROM Users";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString()
                            });
                        }
                    }
                }
            }

            return users;
        }
        #endregion
    }
}
