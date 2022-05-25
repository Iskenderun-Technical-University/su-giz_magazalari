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
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
             {
                if (radioButton1.Checked)
                {

                    sqlSorgu = "select * from urunler where urunAdi like '%" + textBox3.Text + "%'";
                    GridD(sqlSorgu);
                }
                else if (radioButton2.Checked)
                {

                    sqlSorgu = "select * from urunler where kategori like '%" + textBox3.Text + "%'";
                    GridD(sqlSorgu);
                }
                else if (radioButton3.Checked)
                {

                    sqlSorgu = "select * from urunler where renk like '%" + textBox3.Text + "%'";
                    GridD(sqlSorgu);
                }
                else if (radioButton4.Checked)
                {

                    sqlSorgu = "select * from urunler where beden like '%" + textBox3.Text + "%'";
                    GridD(sqlSorgu);
                }
                else if (radioButton5.Checked)
                {

                    sqlSorgu = "select * from urunler where cinsiyet like '%" + textBox3.Text + "%'";
                    GridD(sqlSorgu);
                } 
            }
            else
            {
                sqlSorgu = "select * from urunler";
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

         


        }
        double para = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            para = Convert.ToDouble(textBox7.Text); 
            if (textBox1.Text != "" && comboBox4.Text != "" && textBox2.Text != "" && textBox5.Text != "" && comboBox3.Text != "" && maskedTextBox2.Text != "" && textBox7.Text != "" && comboBox1.Text != "")
            { 
                
             
                    string sorgu = "insert into satis (urunAdi,kategori,renk,beden,cinsiyet,barkod,fiyat,adet)values('" + textBox1.Text + "','" + comboBox4.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + comboBox3.Text + "','" + maskedTextBox2.Text + "','" + para.ToString()+ "','" + comboBox1.Text + "')";
                    VeriTabani.islemler(sorgu);
            }
            else
            {
                MessageBox.Show("Boşlukları doldurduğunuzdan emin olunuz.");
            }

        }
    }
}
