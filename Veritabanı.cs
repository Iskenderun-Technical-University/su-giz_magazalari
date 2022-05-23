using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace su_giz_magazalari
{
    class Veritabanı
    {
        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlCommand cmd;
        static SqlDataReader dr;
        static System.Data.DataSet ds;



        public static string SqlCon = @"Data Source=DESKTOP-KFDP1D2\SQLEXPRESS;Initial Catalog=Kırtasiye;Integrated Security=True";

        public static bool BaglantiDurum()
        {
            // veritabani baglantisi kontrol


            using (con = new SqlConnection(SqlCon))
            {
                try
                {
                    con.Open();
                    //System.Windows.Forms.MessageBox.Show("Baglanti Kuruldu");
                    return true;
                }
                catch (SqlException exp)
                {
                    System.Windows.Forms.MessageBox.Show(exp.Message);
                    return false;
                }
            }
        }
        //void GridDoldur(System.Windows.Forms.DataGrid dataGridView1)
        public static DataGridView GridTumunuDoldur(DataGridView gridim, string SqlSelectSorgu)  // selectsorgu= bu sadece bi tablonun hepsini secmek istiyorsaniz
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from " + SqlSelectSorgu, con);
            ds = new System.Data.DataSet();
            con.Open();
            da.Fill(ds, SqlSelectSorgu);

            gridim.DataSource = ds.Tables[SqlSelectSorgu];
            //gridim.DataSource = ds.Tables[0]; // istersek istedigimiz siradaki tabloyu getirtebiliriz

            con.Close();
            return gridim;
        }

        public static bool LoginKontrol(string KullaniciAdi, string Sifre)
        {
            string sorgu = "select * from tbl_login where kullanici= @user and sifre= @pass ";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", KullaniciAdi);
            cmd.Parameters.AddWithValue("@pass", Veritabanı.MD5sifreleme(Sifre));

            con.Open();
            dr = cmd.ExecuteReader(); // var mi yok mu diye okuyup getiriyoruz
                                      //eger veri geldiyse

            if (dr.Read())
            {
                //MessageBox.Show("Tebrikler Giris Basarili..");
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
                //MessageBox.Show("Kullanici Adi veya Sifre Hatali !");
                //textBox1.Clear();
                //textBox2.Clear();
                //textBox1.Focus();
            }


        }

        public static string MD5sifreleme(string sifrelenecekMetin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekMetin);

            // Dizinin hash degeri cikariliyor
            dizi = md5.ComputeHash(dizi);

            StringBuilder sb = new StringBuilder();

            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());

            return sb.ToString();
        }

        public static string SHA256Sifreleme(string sifrelenecekMetin)
        {
            SHA256 sha256Hash = SHA256.Create();
            //byte[] dizi = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(sifrelenecekMetin));

            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekMetin);

            // Dizinin hash degeri cikariliyor
            dizi = sha256Hash.ComputeHash(dizi);

            StringBuilder sb = new StringBuilder();

            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());

            return sb.ToString();

        }

        public static void KomutYolla(string sql)
        {
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void KomutYollaParametreleri(string sql, SqlCommand cmd)
        {
            con = new SqlConnection(SqlCon);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
