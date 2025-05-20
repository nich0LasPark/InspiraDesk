using System;
using System.Linq;
using System.Windows.Forms;
using InspiraQuotesManager.Data;
using InspiraQuotesManager.Models;

namespace InspiraQuotesManager.Forms
{
    public partial class MainForm : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private int selectedQuoteId = -1;
        private string _username;

        public MainForm(string username)
        {
            InitializeComponent();
            _username = username;
            this.Text = $"InspiraDesk Manager - Logged in as: {_username}";
            LoadQuotes();
        }

        private void LoadQuotes()
        {
            var quotes = dbHelper.GetAllQuotes();
            quotes.Reverse(); // Newest first
            dgvQuotes.DataSource = null;
            dgvQuotes.DataSource = quotes;

            if (quotes.Count > 0)
            {
                dgvQuotes.ClearSelection();
                dgvQuotes.Rows[0].Selected = true;
            }

            ClearInputs();
        }

        private void ClearInputs()
        {
            txtQuoteText.Clear();
            txtAuthor.Clear();
            cmbCategory.SelectedIndex = -1;
            selectedQuoteId = -1;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtQuoteText.Text))
            {
                MessageBox.Show("Quote text cannot be empty.");
                return false;
            }
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.");
                return false;
            }
            return true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var newQuote = new Quote
            {
                QuoteText = txtQuoteText.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Category = cmbCategory.SelectedItem.ToString()
            };

            dbHelper.AddQuote(newQuote);
            LoadQuotes();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedQuoteId == -1)
            {
                MessageBox.Show("Please select a quote to update.");
                return;
            }
            if (!ValidateInputs()) return;

            var updatedQuote = new Quote
            {
                Id = selectedQuoteId,
                QuoteText = txtQuoteText.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Category = cmbCategory.SelectedItem.ToString()
            };

            dbHelper.UpdateQuote(updatedQuote);
            LoadQuotes();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedQuoteId == -1)
            {
                MessageBox.Show("Please select a quote to delete.");
                return;
            }

            dbHelper.DeleteQuote(selectedQuoteId);
            LoadQuotes();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
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
            }
        }
    }
}
