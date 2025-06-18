using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DigitalWallet
{
    public partial class ExpensesForm : Form
    {
        private List<Expense> expenses;
        private Label lblTitle;
        private MainForm mainForm;

        public ExpensesForm(List<Expense> expenses, MainForm mainForm)
        {
            this.expenses = expenses;
            this.mainForm = mainForm;
            InitializeComponent();
            LoadExpenses();
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lstExpenses = new ListBox();
            btnBackToMain = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(25, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Harcamalarım";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // lstExpenses
            // 
            lstExpenses.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lstExpenses.ItemHeight = 16;
            lstExpenses.Location = new Point(25, 80);
            lstExpenses.Name = "lstExpenses";
            lstExpenses.Size = new Size(350, 292);
            lstExpenses.TabIndex = 1;
            // 
            // btnBackToMain
            // 
            btnBackToMain.Location = new Point(125, 400);
            btnBackToMain.Name = "btnBackToMain";
            btnBackToMain.Size = new Size(150, 40);
            btnBackToMain.TabIndex = 2;
            btnBackToMain.Text = "Ana sayfaya dön";
            btnBackToMain.Click += BtnBackToMain_Click;
            // 
            // ExpensesForm
            // 
            ClientSize = new Size(384, 461);
            Controls.Add(lblTitle);
            Controls.Add(lstExpenses);
            Controls.Add(btnBackToMain);
            Name = "ExpensesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Harcamalarım";
            ResumeLayout(false);
        }

        private void LoadExpenses()
        {
            lstExpenses.Items.Clear();

            if (expenses.Count == 0)
            {
                lstExpenses.Items.Add("Henüz harcama kaydı bulunmamaktadır.");
            }
            else
            {
                foreach (var expense in expenses)
                {
                    lstExpenses.Items.Add($"{expense.Category}: {expense.Amount:C}");
                }
            }
        }

        private void BtnBackToMain_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }

        // Form kontrolleri
        private ListBox lstExpenses;
        private Button btnBackToMain;

        private void lblTitle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Arif hocamdan iyisi yoktur diye düşünüyorum.");
        }
    }
} 