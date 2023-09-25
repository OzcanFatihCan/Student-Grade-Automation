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
    public partial class KulüpForm : Form
    {
        public KulüpForm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=FatihBuzac\\SQLEXPRESS;Initial Catalog=NotSistemi;Integrated Security=True");

        void KulüpListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Kulüpler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void KulüpForm_Load(object sender, EventArgs e)
        {
            //Kulüpleri Listele
            KulüpListele();
        }

      

        private void BtnListele_Click(object sender, EventArgs e)
        {
            //Kulüpleri Listele
            KulüpListele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtKlpad.Text!="")
            {
                baglanti.Open();
                SqlCommand KulüpEkle = new SqlCommand("insert into Tbl_Kulüpler (Kulüpad) Values (@k1)", baglanti);
                KulüpEkle.Parameters.AddWithValue("@k1", TxtKlpad.Text);
                KulüpEkle.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kulüp eklemesi yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Kulüpleri Listele
                KulüpListele();
            }
            else
            {
                MessageBox.Show("Boş girdi yapmayınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }        
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtKlpad.Text != "" && TxtKlpid.Text != "") {
                baglanti.Open();
                SqlCommand KulüpGuncelle = new SqlCommand("Update Tbl_Kulüpler Set Kulüpad=@k1 Where Kulüpid=@k2", baglanti);
                KulüpGuncelle.Parameters.AddWithValue("@k1", TxtKlpad.Text);
                KulüpGuncelle.Parameters.AddWithValue("@k2", TxtKlpid.Text);
                KulüpGuncelle.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kulüp güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Kulüpleri Listele
                KulüpListele();
            }
            else
            {
                MessageBox.Show("Lütfen güncelleyeceğiniz kulübü seçiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtKlpad.Text != "" && TxtKlpid.Text!="")
            {
                baglanti.Open();
                SqlCommand KulüpSil = new SqlCommand("Delete From Tbl_Kulüpler Where Kulüpid=@k1", baglanti);
                KulüpSil.Parameters.AddWithValue("@k1", TxtKlpid.Text);
                KulüpSil.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kulüp silme işlemi yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Kulüpleri Listele
                KulüpListele();
            }
            else
            {
                MessageBox.Show("Lütfen sileceğiniz kulübü seçiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor= Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKlpid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKlpad.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            TxtKlpad.Text = "";
            TxtKlpid.Text = "";
        }
    }
}
