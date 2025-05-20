namespace InspiraQuotesManager.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvQuotes;
        private System.Windows.Forms.TextBox txtQuoteText;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;

        private void InitializeComponent()
        {
            this.dgvQuotes = new System.Windows.Forms.DataGridView();
            this.txtQuoteText = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            var lblQuote = new System.Windows.Forms.Label();
            var lblAuthor = new System.Windows.Forms.Label();
            var lblCategory = new System.Windows.Forms.Label();

            // Labels
            lblQuote.Text = "Quote Text:";
            lblQuote.Location = new System.Drawing.Point(12, 215);
            lblQuote.AutoSize = true;

            lblAuthor.Text = "Author:";
            lblAuthor.Location = new System.Drawing.Point(12, 245);
            lblAuthor.AutoSize = true;

            lblCategory.Text = "Category:";
            lblCategory.Location = new System.Drawing.Point(12, 275);
            lblCategory.AutoSize = true;

            // DataGridView
            this.dgvQuotes.Location = new System.Drawing.Point(12, 12);
            this.dgvQuotes.Size = new System.Drawing.Size(560, 200);
            this.dgvQuotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuotes.ReadOnly = true;
            this.dgvQuotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuotes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvQuotes_CellClick);

            // TextBoxes and ComboBox
            this.txtQuoteText.Location = new System.Drawing.Point(90, 212);
            this.txtQuoteText.Width = 480;

            this.txtAuthor.Location = new System.Drawing.Point(90, 242);
            this.txtAuthor.Width = 480;

            this.cmbCategory.Location = new System.Drawing.Point(90, 272);
            this.cmbCategory.Width = 480;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Items.AddRange(new object[] { "Motivation", "Life", "Love", "Humor" });

            // Buttons
            this.btnAdd.Text = "Add";
            this.btnAdd.Location = new System.Drawing.Point(90, 310);
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            this.btnUpdate.Text = "Update";
            this.btnUpdate.Location = new System.Drawing.Point(200, 310);
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            this.btnDelete.Text = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(310, 310);
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            this.btnClear.Text = "Clear";
            this.btnClear.Location = new System.Drawing.Point(420, 310);
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.dgvQuotes);
            this.Controls.Add(lblQuote);
            this.Controls.Add(this.txtQuoteText);
            this.Controls.Add(lblAuthor);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Name = "MainForm";
        }
    }
}
