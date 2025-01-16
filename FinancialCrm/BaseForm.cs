using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public class BaseForm : Form
    {

        public BaseForm()
        {
            this.Load += BaseForm_Load;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.Click += btn_Click;
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                OpenFormByButtonName(button.Name);
            }
        }

        protected void OpenFormByButtonName(string buttonName)
        {
            Form targetForm = null;

            switch (buttonName)
            {
                case "btnDashboard":
                    targetForm = new FrmDashboard();
                    break;
                case "btnBank":
                    targetForm = new FrmBanks();
                    break;
                case "btnCategory":
                    targetForm = new FrmCategory();
                    break;
                case "btnBill":
                    targetForm = new FrmBilling();
                    break;
                case "btnSpending":
                    targetForm = new FrmSpendings();
                    break;
                case "btnBankProcess":
                    targetForm = new FrmBankProcess();
                    break;
                case "btnExit":
                    var result = MessageBox.Show("Uygulamadan çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    return;               
                default:
                    MessageBox.Show("Bu buton için form tanımlanmamış.");
                    return;
            }

            targetForm?.Show();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(1383, 875);
            this.Name = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load_1);
            this.ResumeLayout(false);

        }

        private void BaseForm_Load_1(object sender, EventArgs e)
        {

        }
    }

}
