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

        private void button1_Click(object sender, EventArgs e)
        {
            if (VeriTabani.login(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Tebrikler Giris Basarili..");
                this.Hide();
                kullanicim = textBox1.Text;
                //personel ise
                Personel_Islemleri a = new Personel_Islemleri();
                a.Show();


            }
        }
        public static string kullanicim = "";
        private void button2_Click(object sender, EventArgs e)
        {
            if (VeriTabani.login(textBox1.Text, textBox2.Text))
            {
                if (kullanicim == "şüşü" || kullanicim == "gizem")
                {

                    MessageBox.Show("giris basarili");
                    kullanicim = textBox1.Text;
                    this.Hide();
                    YöneticIslemleri f = new YöneticIslemleri();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Giris icin yetkiniz yoktur");
                }

            }
            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Kullanıcı adı ve şifre giriniz");
            } 
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre hatalı");
            }
        }
    
        
    }
}
