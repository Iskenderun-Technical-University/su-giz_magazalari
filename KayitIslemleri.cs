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
    public partial class KayitIslemleri : Form
    {
        public KayitIslemleri()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login lg = new login();
            lg.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "update yöneticigiris set sifre='" + textBox2.Text + "'where kullaniciAdi='" + textBox1.Text + "'";
            VeriTabani.islemler(sorgu);
            VeriTabani.GridD(dataGridView1, "select*from yöneticigiris");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
                string sorgu = "delete from yöneticigiris where kullaniciAdi='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'";
                VeriTabani.islemler(sorgu);
                VeriTabani.GridD(dataGridView1, "select *from yöneticigiris");
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                string sss = "select *from yöneticigiris where kullaniciAdi='" + textBox1.Text + "'";

                if (VeriTabani.kullanici_kontrol(sss))
                {
                    MessageBox.Show("Aynı isimde kullanıcı vardır.");
                }
                else
                {
                    if (textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Kullanıcı adı ve şifre giriniz");
                    }
                    else
                    {
                        string sorgu = "insert into yöneticigiris (kullaniciAdi,sifre)values('" + textBox1.Text + "','" + textBox2.Text + "')";
                        VeriTabani.islemler(sorgu);
                        VeriTabani.GridD(dataGridView1, "select*from yöneticigiris");
                    }
                }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KayitIslemleri_Load(object sender, EventArgs e)
        {
            VeriTabani.GridD(dataGridView1, "select *from yöneticigiris");
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Kullanıcı Adı";
        }
    }
    
}
