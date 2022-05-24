using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace su_giz_magazalari
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        public static string kullanicim = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (VeriTabani.login(textBox1.Text, textBox2.Text))
            {
               
                    MessageBox.Show("giris basarili");
                    kullanicim = textBox1.Text;
                    PersonelIslemleri f = new PersonelIslemleri();
                    f.Show();
                    this.Hide();
            }

            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Kullanıcı adı ve şifre giriniz");
            }
            else
                MessageBox.Show("kullanıcı adı veya şifre hatalı");
        }
    
       
        private void button2_Click(object sender, EventArgs e)
        {
            if (VeriTabani.login(textBox1.Text, textBox2.Text))
            {
                if (textBox1.Text == "gizem" || textBox1.Text == "şüşü")
                {
                    MessageBox.Show("giris basarili");
                    kullanicim = textBox1.Text;
                    YöneticIslemleri f = new YöneticIslemleri();
                    f.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Giriş için yetkiniz yoktur.");

            }
            
            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Kullanıcı adı ve şifre giriniz");
            }
            else
                MessageBox.Show("kullanıcı adı veya şifre hatalı");
        }
    }
}
