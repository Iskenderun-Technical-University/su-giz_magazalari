using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace su_giz_magazalari
{
    public partial class YöneticIslemleri : Form
    {
        public YöneticIslemleri()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;
        DataSet ds;
        public static string baglanti = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = su-giz-magazalari; Integrated Security = True";
        public string sqlSorgu;
        void GridD(string sorgu)
        {


            con = new SqlConnection(baglanti);
            da = new SqlDataAdapter(sorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "urunler");
            dataGridView1.DataSource = ds.Tables["urunler"];
            con.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && comboBox1.Text != "" && textBox2.Text != "" && textBox5.Text != "" && comboBox2.Text != "" && maskedTextBox1.Text != "" && textBox7.Text != "") 
            {
                string sorgu = "insert into urunler(urunAdi,kategori,renk,beden,cinsiyet,barkod,fiyat)values('" + textBox4.Text + "','" + comboBox1.Text+ "','" + textBox2.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "','" + maskedTextBox1.Text + "','" + textBox7.Text + "')";
                VeriTabani.islemler(sorgu);
                VeriTabani.GridD(dataGridView1, "select*from urunler");
            }
            else
            {
                MessageBox.Show("Boşlukları eksiksiz doldurunuz.");
            }

        }

        private void YöneticIslemleri_Load(object sender, EventArgs e)
        {
            VeriTabani.GridD(dataGridView1, "select*from urunler");

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Kategori";
            dataGridView1.Columns[3].HeaderText = "Renk";
            dataGridView1.Columns[4].HeaderText = "Beden";
            dataGridView1.Columns[5].HeaderText = "Cinsiyet";
            dataGridView1.Columns[6].HeaderText = "Barkod";
            dataGridView1.Columns[7].HeaderText = "Fiyat";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sqlSorgu = "select * from urunler where urunAdi like '%" + textBox1.Text + "%'";
            GridD(sqlSorgu);
        }

        private void şifreİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SifreIslemleri a = new SifreIslemleri();
            a.ShowDialog();
        }

        private void kayıtİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KayitIslemleri a = new KayitIslemleri();
            a.ShowDialog();
        }
    }
}
