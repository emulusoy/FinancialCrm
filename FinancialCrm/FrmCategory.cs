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
    public partial class FrmCategory : BaseForm
    {
        public FrmCategory()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities database=new FinancialCrmDbEntities();
        private void FrmCategory_Load(object sender, EventArgs e)
        {
            var lbl4 = database.TblCategory.OrderBy(x => x.CategoryId).Take(1).Select(y=>y.CategoryName).FirstOrDefault();
            label4.Text = lbl4;
            var lbl5 = database.TblCategory.OrderBy(x => x.CategoryId).Take(2).Skip(1).Select(y => y.CategoryName).FirstOrDefault();
            label5.Text = lbl5;
            var lbl6 = database.TblCategory.OrderBy(x => x.CategoryId).Take(3).Skip(2).Select(y => y.CategoryName).FirstOrDefault();
            label6.Text = lbl6;
            var lbl7 = database.TblCategory.OrderBy(x => x.CategoryId).Take(4).Skip(3).Select(y => y.CategoryName).FirstOrDefault();
            label7.Text = lbl7;
            var lbl8 = database.TblCategory.OrderBy(x => x.CategoryId).Take(5).Skip(4).Select(y => y.CategoryName).FirstOrDefault();
            label8.Text = lbl8;
            var lbl9 = database.TblCategory.OrderBy(x => x.CategoryId).Take(6).Skip(5).Select(y => y.CategoryName).FirstOrDefault();
            label9.Text = lbl9;
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
