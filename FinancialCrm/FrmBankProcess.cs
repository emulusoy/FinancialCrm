using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;
namespace FinancialCrm
{
    public partial class FrmBankProcess : BaseForm
    {
        public FrmBankProcess()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities data= new FinancialCrmDbEntities();
        private void btnCategory_Click(object sender, EventArgs e)
        {
            OpenFormByButtonName("btnCategory");
        }
        private void btnBank_Click(object sender, EventArgs e)
        {
            OpenFormByButtonName("btnBank");
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            OpenFormByButtonName("btnBill");
        }

        private void btnSpending_Click(object sender, EventArgs e)
        {
            OpenFormByButtonName("btnSpending");
        }
        private void btnBankProcess_Click(object sender, EventArgs e)
        {
            OpenFormByButtonName("btnBankProcess");
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenFormByButtonName("btnDashboard");
        }

        private void FrmBankProcess_Load(object sender, EventArgs e)
        {
            var total = data.TblBankProcess.Sum(y => y.Amount).ToString();
            lbltotal.Text = total.ToString()+"₺";
        }
    }
}
