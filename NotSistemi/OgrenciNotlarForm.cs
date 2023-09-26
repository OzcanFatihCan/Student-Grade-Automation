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

namespace NotSistemi
{
    public partial class OgrenciNotlarForm : Form
    {
        public OgrenciNotlarForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection("Data Source=FatihBuzac\\SQLEXPRESS;Initial Catalog=NotSistemi;Integrated Security=True");
        public string numara;
        private void OgrenciNotlarForm_Load(object sender, EventArgs e)
        {
            //Ogridye göre notlar ve ders adı çekme INNER JOİN
            SqlCommand NotGetir=new SqlCommand("Select Dersad, Sınav1,Sınav2,Sınav3,Proje,Ortalama,Durum From Tbl_Notlar INNER JOIN Tbl_Dersler on Tbl_Notlar.Dersid=Tbl_Dersler.Dersid Where Ogrid=@p1 ", baglanti);
            NotGetir.Parameters.AddWithValue("@p1", numara);
            SqlDataAdapter da = new SqlDataAdapter(NotGetir);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Ogridye Öğrenci adı çekme INNER JOİN
            SqlCommand AdGetir =new SqlCommand("Select (OgrAd+' '+OgrSoyad) From Tbl_Notlar INNER JOIN Tbl_Ogrenciler ON Tbl_Notlar.Ogrid = Tbl_Ogrenciler.Ogrid Where Tbl_Notlar.Ogrid=@p2", baglanti);
            AdGetir.Parameters.AddWithValue("@p2", numara);      
            baglanti.Open();
            SqlDataReader dr=AdGetir.ExecuteReader();
            string ogrenciAdSoyad;
            while (dr.Read())
            {
                this.Text = dr[0].ToString() + " Notları";
            }
            baglanti.Close();

            
           
           
            
        }
    }
}

