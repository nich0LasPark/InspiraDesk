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

            // Modern font
            var modernFont = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Font = modernFont;

            // Light blue theme with improved aesthetics
            this.BackColor = System.Drawing.Color.LightBlue;

            // Text inputs with border styling
            txtUsername.BackColor = System.Drawing.Color.AliceBlue;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);

            txtPassword.BackColor = System.Drawing.Color.AliceBlue;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Button styling with flat appearance
            foreach (var btn in new[] { btnLogin, btnRegister })
            {
                btn.BackColor = System.Drawing.Color.LightSkyBlue;
                btn.ForeColor = System.Drawing.Color.MidnightBlue;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
                btn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
                btn.Cursor = Cursors.Hand;
                btn.Padding = new Padding(3);
                btn.Width = 100;
                btn.Height = 30;
            }

            // Special styling for login button
            btnLogin.BackColor = System.Drawing.Color.CornflowerBlue;
            btnLogin.ForeColor = System.Drawing.Color.White;

            // Label styling
            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = System.Drawing.Color.MidnightBlue;
                    label.Font = new System.Drawing.Font("Segoe UI", 10F);
                }
            }

            // Add app title label
            Label lblTitle = new Label();
            lblTitle.Text = "InspiraDesk";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            lblTitle.Location = new System.Drawing.Point(70, 20);
            this.Controls.Add(lblTitle);

            // Adjust positions for other controls after adding title
            lblUsername.Location = new System.Drawing.Point(30, 70);
            txtUsername.Location = new System.Drawing.Point(110, 67);
            lblPassword.Location = new System.Drawing.Point(30, 110);
            txtPassword.Location = new System.Drawing.Point(110, 107);
            btnLogin.Location = new System.Drawing.Point(80, 150);
            btnRegister.Location = new System.Drawing.Point(190, 150);

            // Adjust form size
            this.ClientSize = new System.Drawing.Size(350, 200);

            // Center on screen and disable resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ShowWelcomeMessage(string username)
        {
            // Open main form and hide login form
            MainForm main = new MainForm(username);
            main.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // More professional validation with specific messages
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.", "Login Required",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a password.", "Password Required",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }

            // Check if user exists
            if (!dbHelper.UserExists(username))
            {
                // Ask if user wants to register
                DialogResult result = MessageBox.Show($"User '{username}' does not exist. Would you like to register?",
                                                    "New User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var newUser = new User
                    {
                        Username = username,
                        Password = password
                    };

                    dbHelper.AddUser(newUser);
                    MessageBox.Show($"Welcome {username}! Your account has been created successfully.",
                                  "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowWelcomeMessage(username);
                }
                return;
            }
            else if (!dbHelper.ValidateUser(username, password))
            {
                MessageBox.Show("Invalid password. Please try again.", "Login Failed",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            ShowWelcomeMessage(username);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // More professional validation with specific messages
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.", "Username Required",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a password.", "Password Required",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }

            if (dbHelper.UserExists(username))
            {
                MessageBox.Show("Username already exists. Please choose another username.",
                              "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            var newUser = new User
            {
                Username = username,
                Password = password
            };

            dbHelper.AddUser(newUser);
            MessageBox.Show($"User '{username}' registered successfully! You can now log in.",
                          "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Login when user presses Enter in the password field
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Prevent the beep sound
                btnLogin_Click(sender, e);
            }
        }
    }
}
