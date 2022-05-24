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
    public partial class PersonelIslemleri : Form
    {
        public PersonelIslemleri()
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                
                sqlSorgu = "select * from urunler where urunAdi like '%" + textBox1.Text + "%'";
                GridD(sqlSorgu);
            }
            else if (radioButton2.Checked)
            {
                
                sqlSorgu = "select * from urunler where kategori like '%" + textBox1.Text + "%'";
                GridD(sqlSorgu);
            }
            else if (radioButton3.Checked)
            {
                
                sqlSorgu = "select * from urunler where renk like '%" + textBox1.Text + "%'";
                GridD(sqlSorgu);
            }
            else if (radioButton4.Checked)
            {
                
                sqlSorgu = "select * from urunler where beden like '%" + textBox1.Text + "%'";
                GridD(sqlSorgu);
            }
            else if (radioButton5.Checked)
            {
                
                sqlSorgu = "select * from urunler where cinsiyet like '%" + textBox1.Text + "%'";
                GridD(sqlSorgu);
            }

        }

        private void PersonelIslemleri_Load(object sender, EventArgs e)
        {
            VeriTabani.GridD(dataGridView1, "select* from urunler");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Kategori";
            dataGridView1.Columns[3].HeaderText = "Renk";
            dataGridView1.Columns[4].HeaderText = "Beden";
            dataGridView1.Columns[5].HeaderText = "Cinsiyet";
            dataGridView1.Columns[6].HeaderText = "Barkod";
            dataGridView1.Columns[7].HeaderText = "Fiyat";
            dataGridView1.Columns[8].HeaderText= "Adet";

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
