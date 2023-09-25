using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotSistemi
{
    public partial class OgrenciForm : Form
    {
        public OgrenciForm()
        {
            InitializeComponent();
        }
        //bağlantı
        SqlConnection baglanti = new SqlConnection("Data Source=FatihBuzac\\SQLEXPRESS;Initial Catalog=NotSistemi;Integrated Security=True");
        //dataset nesne
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
         
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void TxtOgrenciAra_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ds.OgrGetir(TxtOgrenciAra.Text);
        }

        private void OgrenciForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand KlpCek = new SqlCommand("Select * From Tbl_Kulüpler",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(KlpCek);
            DataTable dt=new DataTable();
            da.Fill(dt);
            CmbOgrenciKlb.DisplayMember = "Kulüpad";
            CmbOgrenciKlb.ValueMember = "Kulüpid";
            CmbOgrenciKlb.DataSource= dt;
            baglanti.Close();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            //ÖĞRENCİ LİSTELE
            dataGridView1.DataSource = ds.OgrenciListesi();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtOgrenciid.Text != "" && TxtOgrenciad.Text != "" && TxtOgrencisoyad.Text != "" && CmbOgrenciKlb.Text != "" && c != "")
            {
                ds.OgrenciGuncelle(TxtOgrenciad.Text, TxtOgrencisoyad.Text, byte.Parse(CmbOgrenciKlb.SelectedValue.ToString()), c, int.Parse(TxtOgrenciid.Text));
                //ÖĞRENCİ LİSTELE
                dataGridView1.DataSource = ds.OgrenciListesi();
                MessageBox.Show("Öğrenci güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Güncellemek istediğiniz öğrenciyi seçiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        string c = "";
        private void BtnEkle_Click(object sender, EventArgs e)
        {  
            if (TxtOgrenciad.Text != "" && TxtOgrencisoyad.Text != "" && CmbOgrenciKlb.Text != "" && c!="")
            {
                //Ekleme
                ds.OgrenciEkle(TxtOgrenciad.Text, TxtOgrencisoyad.Text, byte.Parse(CmbOgrenciKlb.SelectedValue.ToString()), c);
                MessageBox.Show("Öğrenci eklemesi yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ÖĞRENCİ LİSTELE
                dataGridView1.DataSource = ds.OgrenciListesi();
            }
            else
            {
                MessageBox.Show("Ad, Soyad, Kulüp ve Cinsiyet seçimi hücreleri boş kalamaz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtOgrenciid.Text != "" && TxtOgrenciad.Text != "" && TxtOgrencisoyad.Text != "" && CmbOgrenciKlb.Text != "" && c != "") 
            { 
                ds.OgrenciSil(int.Parse(TxtOgrenciid.Text));
                //ÖĞRENCİ LİSTELE
                dataGridView1.DataSource = ds.OgrenciListesi();
                MessageBox.Show("Öğrenci silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silmek istediğiniz öğrenciyi seçiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CmbOgrenciKlb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtOgrenciid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtOgrenciad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtOgrencisoyad.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbOgrenciKlb.Text= dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (cinsiyet == "Kız")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else if (cinsiyet == "Erkek")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Cinsiyet seçme
            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Cinsiyet seçme
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            TxtOgrenciad.Text = "";
            TxtOgrenciAra.Text = "";
            TxtOgrenciid.Text = "";
            TxtOgrencisoyad.Text = "";
            CmbOgrenciKlb.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
    }
}
