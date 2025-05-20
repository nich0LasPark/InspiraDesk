using System;
using System.Drawing;
using System.Windows.Forms;

namespace InspiraQuotesManager.Forms
{
    public partial class LoginForm : Form
    {
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

            System.IO.File.AppendAllText("logins.txt", username + Environment.NewLine);

            MainForm main = new MainForm(username);
            main.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Registration is not required. You can log in with any username and password.");
        }
    }
}
