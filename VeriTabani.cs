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
    internal class VeriTabani
    {
        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlCommand cmd;
        static SqlDataReader dr;
        static System.Data.DataSet ds;


        public static string baglanti = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = su-giz-magazalari; Integrated Security = True";
        public static bool login(string kullanici, string sifre)
        {
            string sorgu = "select * from yöneticigiris where kullaniciAdi=@k and sifre=@s ";
            con = new SqlConnection(baglanti);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@k", kullanici);
            cmd.Parameters.AddWithValue("@s", sifre);

            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }


        }
        public static DataGridView GridD(DataGridView grid, string sorgu)
        {

            con = new SqlConnection(baglanti);
            da = new SqlDataAdapter(sorgu, con);
            ds = new System.Data.DataSet();
            con.Open();
            da.Fill(ds, sorgu);
            grid.DataSource = ds.Tables[sorgu];
            con.Close();
            return grid;
        }
        public static bool baglantikontrol()
        {
            using (con = new SqlConnection(baglanti))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return false;


                }

            }
        }

        public static string MD5Sifrele(string sifre)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifre);
            dizi = md5.ComputeHash(dizi);

            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());
            return sb.ToString();


        }

        public static bool kullanici_kontrol(string s)
        {
            con = new SqlConnection(baglanti);
            SqlCommand kontrol = new SqlCommand(s, con);
            con.Open();
            dr = kontrol.ExecuteReader();

            if (dr.Read())
            {
                return true;
                con.Close();
            }
            else
            {
                return false;
                con.Close();
            }
        }

        public static void islemler(string sql)
        {
            con = new SqlConnection(baglanti);

            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }


}
