using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private bool isRegisterMode = false;
        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void LoginUser()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // DbContext üzerinden giriş kontrolü
            using (FinancialCrmDbEntities database = new FinancialCrmDbEntities())
            {
                var user = database.TblUser.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    // Kullanıcı bulundu, Dashboard'a geç
                    FrmDashboard dashboard = new FrmDashboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    // Kullanıcı bulunamadı, buton yanıp sönsün
                    Timer timer = new Timer();
                    timer.Interval = 500;
                    timer.Tick += (s, ev) =>
                    {
                        btnSign.BackColor = btnSign.BackColor == Color.Red ? SystemColors.Control : Color.Red;
                    };
                    timer.Start();
                }
            }
        }



        private void RegisterUser()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz.");
                return;
            }

            using (FinancialCrmDbEntities database = new FinancialCrmDbEntities())
            {
                
                var existingUser = database.TblUser.FirstOrDefault(u => u.Username == username);

                if (existingUser != null)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten mevcut.");
                    return;
                }
                var newUser = new TblUser
                {
                    Username = username,
                    Password = password
                };
                database.TblUser.Add(newUser);
                database.SaveChanges();

                MessageBox.Show("Kayıt başarılı! Artık giriş yapabilirsiniz.");

                // Butonları eski haline döndür
                btnLogin.Text = "Login";
                btnSign.Text = "Sign Up";
                isRegisterMode = false;
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            if (isRegisterMode)
            {
                // Kayıt olma işlemi
                RegisterUser();
            }
            else
            {
                // Giriş yapma işlemi
                LoginUser();
            }
        
    }
        private void btnSign_Click(object sender, EventArgs e)
        {
            isRegisterMode = !isRegisterMode;

            if (isRegisterMode)
            {
                btnLogin.Text = "Register";
                btnSign.Text = "Back";
            }
            else
            {
                btnLogin.Text = "Login";
                btnSign.Text = "Sign Up";
            }
        }
    }
}
