using System;
using System.Drawing;
using System.Windows.Forms;
using InspiraQuotesManager.Data;
using InspiraQuotesManager.Models;

namespace InspiraQuotesManager.Forms
{
    public partial class LoginForm : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public LoginForm()
        {
            InitializeComponent();
            this.BackColor = Color.LightBlue; // Ensure background is always set
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Check if user exists
            if (!dbHelper.UserExists(username))
            {
                // Add new user if not exists
                var newUser = new User
                {
                    Username = username,
                    Password = password
                };

                dbHelper.AddUser(newUser);
                MessageBox.Show($"New user '{username}' has been created!");
            }
            else if (!dbHelper.ValidateUser(username, password))
            {
                MessageBox.Show("Invalid password. Please try again.");
                return;
            }

            MainForm main = new MainForm(username);
            main.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            if (dbHelper.UserExists(username))
            {
                MessageBox.Show("Username already exists. Please choose another username.");
                return;
            }

            var newUser = new User
            {
                Username = username,
                Password = password
            };

            dbHelper.AddUser(newUser);
            MessageBox.Show($"User '{username}' registered successfully! You can now log in.");
        }
    }
}
