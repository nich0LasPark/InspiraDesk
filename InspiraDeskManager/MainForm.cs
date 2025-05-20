using System;
using System.Linq;
using System.Windows.Forms;
using InspiraQuotesManager.Data;
using InspiraQuotesManager.Models;

namespace InspiraQuotesManager.Forms
{
    public partial class MainForm : Form
    {
        private readonly DatabaseHelper dbHelper = new DatabaseHelper();
        private int selectedQuoteId = -1;
        private readonly string _username;
        private LoginForm _loginForm;
        private DataGridViewCellFormattingEventHandler _cellFormattingHandler;

        public MainForm(string username)
        {
            InitializeComponent();
            _username = username;
            this.Text = $"InspiraDesk Manager - Logged in as: {_username}";

            // Modern font
            var modernFont = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Font = modernFont;

            // Light blue theme with improved aesthetics
            this.BackColor = System.Drawing.Color.LightBlue;

            // Text inputs with border styling
            txtQuoteText.BackColor = System.Drawing.Color.AliceBlue;
            txtQuoteText.BorderStyle = BorderStyle.FixedSingle;
            txtQuoteText.Font = new System.Drawing.Font("Segoe UI", 10F);

            txtAuthor.BackColor = System.Drawing.Color.AliceBlue;
            txtAuthor.BorderStyle = BorderStyle.FixedSingle;
            txtAuthor.Font = new System.Drawing.Font("Segoe UI", 10F);

            cmbCategory.BackColor = System.Drawing.Color.AliceBlue;
            cmbCategory.FlatStyle = FlatStyle.Flat;
            cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Button styling with flat appearance - matching LoginForm styles
            foreach (var btn in new[] { btnAdd, btnUpdate, btnDelete, btnClear, btnLogout })
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

            // Special styling for logout button - to match the login button in LoginForm
            btnLogout.BackColor = System.Drawing.Color.CornflowerBlue;
            btnLogout.ForeColor = System.Drawing.Color.White;

            // Ensure buttons are evenly spaced with proper padding
            btnAdd.Location = new System.Drawing.Point(22, 299);
            btnUpdate.Location = new System.Drawing.Point(132, 299);
            btnDelete.Location = new System.Drawing.Point(242, 299);
            btnClear.Location = new System.Drawing.Point(352, 299);
            btnLogout.Location = new System.Drawing.Point(462, 299);

            // Label styling
            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = System.Drawing.Color.MidnightBlue;
                    label.Font = new System.Drawing.Font("Segoe UI", 10F);
                }
            }

            // Specific label styling
            lblQuote.ForeColor = System.Drawing.Color.MidnightBlue;
            lblAuthor.ForeColor = System.Drawing.Color.MidnightBlue;
            lblCategory.ForeColor = System.Drawing.Color.MidnightBlue;
            lblQuote.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblAuthor.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblCategory.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Add title label at the top
            Label lblTitle = new Label();
            lblTitle.Text = "Feel Inspired";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            lblTitle.Location = new System.Drawing.Point(12, 12);
            this.Controls.Add(lblTitle);

            // DataGridView enhanced styling - matching the clean look
            dgvQuotes.BackgroundColor = System.Drawing.Color.Azure;
            dgvQuotes.DefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
            dgvQuotes.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvQuotes.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dgvQuotes.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.MidnightBlue;

            dgvQuotes.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue;
            dgvQuotes.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvQuotes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            dgvQuotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvQuotes.ColumnHeadersHeight = 35;
            dgvQuotes.RowTemplate.Height = 28;

            dgvQuotes.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvQuotes.GridColor = System.Drawing.Color.LightSteelBlue;
            dgvQuotes.BorderStyle = BorderStyle.None;
            dgvQuotes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvQuotes.RowHeadersVisible = false;
            dgvQuotes.EnableHeadersVisualStyles = false;

            // Adjust position of DataGridView to make room for the title
            dgvQuotes.Location = new System.Drawing.Point(12, 45);
            dgvQuotes.Size = new System.Drawing.Size(560, 167);

            // Form settings
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            LoadQuotes();
        }

        private void LoadQuotes()
        {
            try
            {
                var quotes = dbHelper.GetAllQuotes();
                quotes.Reverse(); // Newest first

                // Remove existing handler if exists
                if (_cellFormattingHandler != null)
                    dgvQuotes.CellFormatting -= _cellFormattingHandler;

                dgvQuotes.DataSource = null;
                dgvQuotes.DataSource = quotes;

                if (dgvQuotes.Columns.Contains("CreatedBy"))
                {
                    dgvQuotes.Columns["CreatedBy"].HeaderText = "Created By";
                }

                // Create new handler and store reference
                _cellFormattingHandler = (s, args) =>
                {
                    if (args.ColumnIndex >= 0 && args.RowIndex >= 0)
                    {
                        if (dgvQuotes.Columns[args.ColumnIndex].Name == "CreatedBy")
                        {
                            string creator = dgvQuotes.Rows[args.RowIndex].Cells[args.ColumnIndex].Value?.ToString();
                            if (creator == _username)
                            {
                                args.CellStyle.BackColor = System.Drawing.Color.LightGreen;
                                args.CellStyle.ForeColor = System.Drawing.Color.DarkGreen;
                            }
                        }
                    }
                };

                // Add the handler
                dgvQuotes.CellFormatting += _cellFormattingHandler;

                if (quotes.Count > 0)
                {
                    dgvQuotes.ClearSelection();
                    dgvQuotes.Rows[0].Selected = true;
                }

                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading quotes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtQuoteText.Clear();
            txtAuthor.Clear();
            cmbCategory.SelectedIndex = -1;
            selectedQuoteId = -1;
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            bool canEdit = false;

            if (selectedQuoteId != -1)
            {
                Quote selectedQuote = dbHelper.GetQuoteById(selectedQuoteId);
                if (selectedQuote != null)
                {
                    // If the quote was created before we tracked creators, allow anyone to edit it
                    // Otherwise, only allow the creator to edit it
                    canEdit = string.IsNullOrEmpty(selectedQuote.CreatedBy) ||
                              selectedQuote.CreatedBy == _username;
                }
            }

            btnUpdate.Enabled = canEdit;
            btnDelete.Enabled = canEdit;

            // Ensure buttons maintain their appearance when disabled
            if (!canEdit)
            {
                btnUpdate.BackColor = System.Drawing.Color.Gainsboro;
                btnDelete.BackColor = System.Drawing.Color.Gainsboro;
            }
            else
            {
                btnUpdate.BackColor = System.Drawing.Color.LightSkyBlue;
                btnDelete.BackColor = System.Drawing.Color.LightSkyBlue;
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtQuoteText.Text))
            {
                MessageBox.Show("Quote text cannot be empty.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var newQuote = new Quote
                {
                    QuoteText = txtQuoteText.Text.Trim(),
                    Author = txtAuthor.Text.Trim(),
                    Category = cmbCategory.SelectedItem.ToString(),
                    CreatedBy = _username // Set the creator to the current user
                };

                dbHelper.AddQuote(newQuote);
                LoadQuotes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding quote: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedQuoteId == -1)
            {
                MessageBox.Show("Please select a quote to update.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateInputs()) return;

            try
            {
                // Get the original quote to preserve CreatedBy
                Quote originalQuote = dbHelper.GetQuoteById(selectedQuoteId);
                if (originalQuote == null)
                {
                    MessageBox.Show("The selected quote could not be found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var updatedQuote = new Quote
                {
                    Id = selectedQuoteId,
                    QuoteText = txtQuoteText.Text.Trim(),
                    Author = txtAuthor.Text.Trim(),
                    Category = cmbCategory.SelectedItem.ToString(),
                    CreatedBy = originalQuote.CreatedBy // Preserve original creator
                };

                dbHelper.UpdateQuote(updatedQuote);
                LoadQuotes();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating quote: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedQuoteId == -1)
            {
                MessageBox.Show("Please select a quote to delete.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (MessageBox.Show("Are you sure you want to delete this quote?", "Confirm Delete",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbHelper.DeleteQuote(selectedQuoteId, _username);
                    LoadQuotes();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting quote: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (_loginForm == null || _loginForm.IsDisposed)
            {
                _loginForm = new LoginForm();
            }

            _loginForm.Show();
            this.Close();
        }

        private void DgvQuotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvQuotes.Rows[e.RowIndex];
                selectedQuoteId = Convert.ToInt32(row.Cells["Id"].Value);
                txtQuoteText.Text = row.Cells["QuoteText"].Value.ToString();
                txtAuthor.Text = row.Cells["Author"].Value.ToString();
                cmbCategory.SelectedItem = cmbCategory.Items
                    .Cast<object>()
                    .FirstOrDefault(item => item.ToString() == row.Cells["Category"].Value.ToString());

                UpdateButtonState();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
