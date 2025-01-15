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
    public partial class FrmSpendings : BaseForm
    {
        public FrmSpendings()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities database=new FinancialCrmDbEntities();
        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            var title1 = database.TblSpending.OrderBy(x => x.SpendingId).Take(1).Select(x => x.SpendingTitle).FirstOrDefault(); 
            lblSpendingTitle.Text = title1.ToString();
            var amount1=database.TblSpending.OrderBy(x => x.SpendingId).Take(1).Select(x => x.SpendingAmount).FirstOrDefault();
            lblSpendingAmount.Text = amount1.ToString();
            var date1 = database.TblSpending.OrderBy(x => x.SpendingId).Take(1).Select(x => x.SpendingDate).FirstOrDefault();
            lblSpendingDate.Text = date1.ToString();


            var title2 = database.TblSpending.OrderBy(x => x.SpendingId).Take(2).Skip(1).Select(x => x.SpendingTitle).FirstOrDefault();
            lblSpendingTitle2.Text = title2.ToString();
            var amount2 = database.TblSpending.OrderBy(x => x.SpendingId).Take(2).Skip(1).Select(x => x.SpendingAmount).FirstOrDefault();
            lblSpendingAmount2.Text = amount2.ToString();
            var date2 = database.TblSpending.OrderBy(x => x.SpendingId).Take(2).Skip(1).Select(x => x.SpendingDate).FirstOrDefault();
            lblSpendingDate2.Text = date2.ToString();


            var title3 = database.TblSpending.OrderBy(x => x.SpendingId).Take(3).Skip(2).Select(x => x.SpendingTitle).FirstOrDefault();
            lblSpendingTitle3.Text = title3.ToString();
            var amount3 = database.TblSpending.OrderBy(x => x.SpendingId).Take(3).Skip(2).Select(x => x.SpendingAmount).FirstOrDefault();
            lblSpendingAmount3.Text = amount3.ToString();
            var date3 = database.TblSpending.OrderBy(x => x.SpendingId).Take(3).Skip(2).Select(x => x.SpendingDate).FirstOrDefault();
            lblSpendingDate3.Text = date3.ToString();
        }

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
    }
}
