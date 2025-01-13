using System;
using System.Linq;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities database =new FinancialCrmDbEntities();

        private void FrmBanks_Load(object sender, EventArgs e)
        {

            //Para getirme
            var ziraatBalance = database.TblBank.Where(x => x.BankTitle == "Ziraat Bank").Select(y => y.BankBalance).FirstOrDefault();
            var vakifBalance = database.TblBank.Where(x => x.BankTitle == "Vakif Bank").Select(y => y.BankBalance).FirstOrDefault();
            var isBalance = database.TblBank.Where(x => x.BankTitle == "Is Bank").Select(y => y.BankBalance).FirstOrDefault();
            lblZiraatBank.Text = ziraatBalance.ToString()+"₺";
            lblVakifBank.Text = vakifBalance.ToString() + "₺";    
            lblIsBank.Text = isBalance.ToString() + "₺";

            //Banka hareketi
            var process1 = database.TblBankProcess.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();//
            var process2 = database.TblBankProcess.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();//
            var process3 = database.TblBankProcess.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();//
            var process4 = database.TblBankProcess.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();//
            var process5 = database.TblBankProcess.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();//
            lblProcess1.Text =process1.Description+" "+process1.ProcessDate+" "+process1.Amount;
            lblProcess2.Text= process2.Description + " " + process2.ProcessDate + " " + process2.Amount;
            lblProcess3.Text= process3.Description + " " + process3.ProcessDate + " " + process3.Amount;
            lblProcess4.Text= process4.Description + " " + process4.ProcessDate + " " + process4.Amount;
            lblProcess5.Text= process5.Description + " " + process5.ProcessDate + " " + process5.Amount;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBilling form = new FrmBilling();
            form.Show();
            this.Hide();
        }
    }
}
