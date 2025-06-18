using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DigitalWallet
{
    public partial class MainForm : Form
    {
        private decimal totalBalance = 0;
        private List<Expense> expenses = new List<Expense>();
        private const string DATA_FILE = "wallet_data.txt";

        public MainForm()
        {
            InitializeComponent();
            LoadData();
            UpdateBalanceDisplay();
        }

        private void InitializeComponent()
        {
            lblTotalBalance = new Label();
            btnIncomeExpense = new Button();
            btnExpenses = new Button();
            btnReset = new Button();
            btnSaveExit = new Button();
            SuspendLayout();
            // 
            // lblTotalBalance
            // 
            lblTotalBalance.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalBalance.Location = new Point(25, 30);
            lblTotalBalance.Name = "lblTotalBalance";
            lblTotalBalance.Size = new Size(350, 40);
            lblTotalBalance.TabIndex = 0;
            lblTotalBalance.Text = "Toplam Bakiye: 0 TL";
            lblTotalBalance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnIncomeExpense
            // 
            btnIncomeExpense.Location = new Point(100, 100);
            btnIncomeExpense.Name = "btnIncomeExpense";
            btnIncomeExpense.Size = new Size(200, 50);
            btnIncomeExpense.TabIndex = 1;
            btnIncomeExpense.Text = "Gelir/Gider";
            btnIncomeExpense.Click += BtnIncomeExpense_Click;
            // 
            // btnExpenses
            // 
            btnExpenses.Location = new Point(100, 170);
            btnExpenses.Name = "btnExpenses";
            btnExpenses.Size = new Size(200, 50);
            btnExpenses.TabIndex = 2;
            btnExpenses.Text = "Harcamalarım";
            btnExpenses.Click += BtnExpenses_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(100, 240);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(200, 50);
            btnReset.TabIndex = 3;
            btnReset.Text = "Sıfırla";
            btnReset.Click += BtnReset_Click;
            // 
            // btnSaveExit
            // 
            btnSaveExit.Location = new Point(100, 310);
            btnSaveExit.Name = "btnSaveExit";
            btnSaveExit.Size = new Size(200, 50);
            btnSaveExit.TabIndex = 4;
            btnSaveExit.Text = "Kaydet ve Çık";
            btnSaveExit.Click += BtnSaveExit_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(384, 461);
            Controls.Add(lblTotalBalance);
            Controls.Add(btnIncomeExpense);
            Controls.Add(btnExpenses);
            Controls.Add(btnReset);
            Controls.Add(btnSaveExit);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dijital Cüzdan - Ana Sayfa";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        private void BtnIncomeExpense_Click(object sender, EventArgs e)
        {
            IncomeExpenseForm incomeExpenseForm = new IncomeExpenseForm(this);
            incomeExpenseForm.Show();
            this.Hide();
        }

        private void BtnExpenses_Click(object sender, EventArgs e)
        {
            ExpensesForm expensesForm = new ExpensesForm(expenses, this);
            expensesForm.Show();
            this.Hide();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tüm veriler sıfırlanacak. Emin misiniz?",
                "Sıfırlama Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                totalBalance = 0;
                expenses.Clear();
                UpdateBalanceDisplay();
                SaveData();
                MessageBox.Show("Tüm veriler sıfırlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnSaveExit_Click(object sender, EventArgs e)
        {
            SaveData();
            Application.Exit();
        }

        public void AddIncome(decimal amount)
        {
            totalBalance += amount;
            UpdateBalanceDisplay();
        }

        public void AddExpense(decimal amount, string category)
        {
            totalBalance -= amount;
            expenses.Add(new Expense { Amount = amount, Category = category });
            UpdateBalanceDisplay();
        }

        private void UpdateBalanceDisplay()
        {
            lblTotalBalance.Text = $"Toplam Bakiye: {totalBalance:C}";
        }

        private void SaveData()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(DATA_FILE))
                {
                    writer.WriteLine(totalBalance.ToString());
                    foreach (var expense in expenses)
                    {
                        writer.WriteLine($"{expense.Category}|{expense.Amount}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri kaydedilirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                if (File.Exists(DATA_FILE))
                {
                    string[] lines = File.ReadAllLines(DATA_FILE);
                    if (lines.Length > 0)
                    {
                        if (decimal.TryParse(lines[0], out decimal balance))
                        {
                            totalBalance = balance;
                        }

                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] parts = lines[i].Split('|');
                            if (parts.Length == 2 && decimal.TryParse(parts[1], out decimal amount))
                            {
                                expenses.Add(new Expense { Category = parts[0], Amount = amount });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Form kontrolleri
        private Label lblTotalBalance;
        private Button btnIncomeExpense;
        private Button btnExpenses;
        private Button btnReset;
        private Button btnSaveExit;

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class Expense
    {
        public string Category { get; set; }
        public decimal Amount { get; set; }
    }
} 