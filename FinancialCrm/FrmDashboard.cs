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
    public partial class FrmDashboard : BaseForm
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities database=new FinancialCrmDbEntities();
        int count = 0;

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
        var totalBalance = database.TblBank.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString()+"₺";
            var lastBankProcess=database.TblBankProcess.OrderByDescending(x=>x.BankProcessId).Take(1).Select(x=>x.Amount).FirstOrDefault();
            lbllastBankProcessAmount.Text = lastBankProcess.ToString() + "₺";


            //grafikller

            var bankData = database.TblBank.Select(x => new
            {
                x.BankTitle,
                x.BankBalance
                
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            
            foreach (var item in bankData) {  
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }

            var billData = database.TblBill.Select(x => new
            {
                x.Billtitle,
                x.BillAmount
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Series1");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            foreach (var item in billData) 
                {
                    series2.Points.AddXY(item.Billtitle, item.BillAmount);
                }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count %4 ==1)
            {
                var billTitle1 = database.TblBill.Where(x => x.Billtitle == "Electricity bill").Select(x => x.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Electricity bill";
                lblBillAmount.Text=billTitle1.ToString();
            }
            if (count % 4 == 2 )
            {
                var billTitle2 = database.TblBill.Where(x => x.Billtitle == "Gas bill").Select(x => x.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Gas bill";
                lblBillAmount.Text = billTitle2.ToString();
            }
            if (count % 4 == 3)
            {
                var billTitle3 = database.TblBill.Where(x => x.Billtitle == "Internet Bill").Select(x => x.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Internet Bill";
                lblBillAmount.Text = billTitle3.ToString();
            }
            if (count % 4 == 4)
            {
                var billTitle4 = database.TblBill.Where(x => x.Billtitle == "Water Bill").Select(x => x.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Water Bill";
                lblBillAmount.Text = billTitle4.ToString();
            }
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
