using System;
using System.Linq;
using System.Windows.Forms;
using FinancialCrm.Models;
namespace FinancialCrm
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities database= new FinancialCrmDbEntities();  

        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var values=database.TblBill.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string title =txtTitle.Text;
            decimal amount = decimal.Parse(txtQuantity.Text);
            string period=txtPeriod.Text;
            TblBill bills=new TblBill();
            bills.Billtitle = title;
            bills.BillPeriod = period;
            bills.BillAmount = amount;
            database.TblBill.Add(bills);
            database.SaveChanges();
            MessageBox.Show("Payment Created");
        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var removeBill=database.TblBill.Find(id);
            database.TblBill.Remove(removeBill);
            database.SaveChanges();
            MessageBox.Show("Payment Deledted");
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var values = database.TblBill.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            decimal amount = decimal.Parse(txtQuantity.Text);
            string period = txtPeriod.Text;
            int id= int.Parse(txtId.Text);

            var values = database.TblBill.Find(id);
            values.Billtitle = title;
            values.BillPeriod = period;
            values.BillAmount = amount;
            database.TblBill.Add(values);
            database.SaveChanges();
            MessageBox.Show("Payment Updated");
            var values2 = database.TblBill.ToList();
            dataGridView1.DataSource=values2;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks form = new FrmBanks();
            form.Show();
            this.Hide();
        }
    }
}
