using System;
using System.Windows.Forms;

namespace DigitalWallet
{
    public partial class IncomeExpenseForm : Form
    {
        private MainForm mainForm;

        public IncomeExpenseForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            lblIncome = new Label();
            txtIncome = new TextBox();
            btnAddIncome = new Button();
            lblExpense = new Label();
            txtExpense = new TextBox();
            btnAddExpense = new Button();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            btnBackToMain = new Button();
            SuspendLayout();
            // 
            // lblIncome
            // 
            lblIncome.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblIncome.Location = new Point(20, 30);
            lblIncome.Name = "lblIncome";
            lblIncome.Size = new Size(100, 30);
            lblIncome.TabIndex = 0;
            lblIncome.Text = "Gelir Ekle:";
            // 
            // txtIncome
            // 
            txtIncome.Location = new Point(130, 30);
            txtIncome.Name = "txtIncome";
            txtIncome.PlaceholderText = "Miktar giriniz";
            txtIncome.Size = new Size(150, 23);
            txtIncome.TabIndex = 1;
            // 
            // btnAddIncome
            // 
            btnAddIncome.Location = new Point(290, 30);
            btnAddIncome.Name = "btnAddIncome";
            btnAddIncome.Size = new Size(80, 30);
            btnAddIncome.TabIndex = 2;
            btnAddIncome.Text = "Ekle";
            btnAddIncome.Click += BtnAddIncome_Click;
            // 
            // lblExpense
            // 
            lblExpense.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblExpense.Location = new Point(20, 100);
            lblExpense.Name = "lblExpense";
            lblExpense.Size = new Size(100, 30);
            lblExpense.TabIndex = 3;
            lblExpense.Text = "Gider Ekle:";
            // 
            // txtExpense
            // 
            txtExpense.Location = new Point(130, 100);
            txtExpense.Name = "txtExpense";
            txtExpense.PlaceholderText = "Miktar giriniz";
            txtExpense.Size = new Size(150, 23);
            txtExpense.TabIndex = 4;
            // 
            // btnAddExpense
            // 
            btnAddExpense.Location = new Point(290, 100);
            btnAddExpense.Name = "btnAddExpense";
            btnAddExpense.Size = new Size(80, 30);
            btnAddExpense.TabIndex = 5;
            btnAddExpense.Text = "Ekle";
            btnAddExpense.Click += BtnAddExpense_Click;
            // 
            // lblCategory
            // 
            lblCategory.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblCategory.Location = new Point(130, 140);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(80, 25);
            lblCategory.TabIndex = 6;
            lblCategory.Text = "Kategori:";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Items.AddRange(new object[] { "Giyim", "Yiyecek", "Alışveriş", "Diğer" });
            cmbCategory.Location = new Point(130, 165);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(150, 23);
            cmbCategory.TabIndex = 7;
            // 
            // btnBackToMain
            // 
            btnBackToMain.Location = new Point(150, 250);
            btnBackToMain.Name = "btnBackToMain";
            btnBackToMain.Size = new Size(150, 40);
            btnBackToMain.TabIndex = 8;
            btnBackToMain.Text = "Ana sayfaya dön";
            btnBackToMain.Click += BtnBackToMain_Click;
            // 
            // IncomeExpenseForm
            // 
            ClientSize = new Size(434, 361);
            Controls.Add(lblIncome);
            Controls.Add(txtIncome);
            Controls.Add(btnAddIncome);
            Controls.Add(lblExpense);
            Controls.Add(txtExpense);
            Controls.Add(btnAddExpense);
            Controls.Add(lblCategory);
            Controls.Add(cmbCategory);
            Controls.Add(btnBackToMain);
            Name = "IncomeExpenseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gelir/Gider Ekle";
            Load += IncomeExpenseForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnAddIncome_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtIncome.Text, out decimal amount) && amount > 0)
            {
                mainForm.AddIncome(amount);
                txtIncome.Clear();
                MessageBox.Show($"{amount:C} gelir eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir miktar giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAddExpense_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtExpense.Text, out decimal amount) && amount > 0)
            {
                string category = cmbCategory.SelectedItem.ToString();
                mainForm.AddExpense(amount, category);
                txtExpense.Clear();
                MessageBox.Show($"{amount:C} gider eklendi! Kategori: {category}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir miktar giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnBackToMain_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }

        // Form kontrolleri
        private TextBox txtIncome;
        private Button btnAddIncome;
        private TextBox txtExpense;
        private Button btnAddExpense;
        private ComboBox cmbCategory;
        private Label lblIncome;
        private Label lblExpense;
        private Label lblCategory;
        private Button btnBackToMain;

        private void IncomeExpenseForm_Load(object sender, EventArgs e)
        {

        }
    }
} 