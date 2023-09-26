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
    public partial class SinavNotlarForm : Form
    {
        public SinavNotlarForm()
        {
            InitializeComponent();
        }
        //Dataset
        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        //bağlantı
        SqlConnection baglanti = new SqlConnection("Data Source=FatihBuzac\\SQLEXPRESS;Initial Catalog=NotSistemi;Integrated Security=True");
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            CmbDers.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtOgrenciid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        int sinav1, sinav2, sinav3, proje;
        double ortalama;
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            if (TxtOgrenciid.Text!="" && CmbDers.Text != "" && TxtSinav1.Text!="" && TxtSinav2.Text != "" && TxtSinav3.Text != "" && TxtProje.Text != "")
            {
                try
                {
                    sinav1 = Convert.ToInt16(TxtSinav1.Text);
                    sinav2 = Convert.ToInt16(TxtSinav2.Text);
                    sinav3 = Convert.ToInt16(TxtSinav3.Text);
                    proje = Convert.ToInt16(TxtProje.Text);
                    ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4.0;
                    TxtOrtalama.Text = ortalama.ToString("F2");
                    if (ortalama >= 50)
                    {
                        TxtDurum.Text = "True";
                    }
                    else
                    {
                        TxtDurum.Text = "False";
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Lütfen Sayısal değer giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Hesaplama için boş hücre bırakmayınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand DersKontrol = new SqlCommand("Select count(*) From Tbl_Notlar WHERE Dersid = @d1 AND Ogrid = @d2", baglanti);
            DersKontrol.Parameters.AddWithValue("@d1",CmbDers.SelectedValue.ToString());
            DersKontrol.Parameters.AddWithValue("@d2", TxtOgrenciid.Text);

            int dersVarMi = (int)DersKontrol.ExecuteScalar();

            if (CmbDers.Text != "" && TxtOgrenciid.Text != "" && TxtSinav1.Text != "" && TxtSinav2.Text != "" && TxtSinav3.Text != "" && TxtProje.Text != "" && TxtOrtalama.Text != "" && TxtDurum.Text != "")
            {
                if (dersVarMi > 0)
                {
                    try
                    {

                        ds.NotGuncelle(byte.Parse(CmbDers.SelectedValue.ToString()), int.Parse(TxtOgrenciid.Text), byte.Parse(TxtSinav1.Text), byte.Parse(TxtSinav2.Text), byte.Parse(TxtSinav3.Text), byte.Parse(TxtProje.Text), decimal.Parse(TxtOrtalama.Text), bool.Parse(TxtDurum.Text), notid);
                        MessageBox.Show("Güncelleme yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //datagrid güncelle
                        dataGridView1.DataSource = ds.NotGetir(int.Parse(TxtOgrenciid.Text));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lütfen Sayısal değer giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    try
                    {
                        ds.NotEkle(byte.Parse(CmbDers.SelectedValue.ToString()), int.Parse(TxtOgrenciid.Text), byte.Parse(TxtSinav1.Text), byte.Parse(TxtSinav2.Text), byte.Parse(TxtSinav3.Text), byte.Parse(TxtProje.Text), decimal.Parse(TxtOrtalama.Text), bool.Parse(TxtDurum.Text));
                        dataGridView1.DataSource = ds.NotGetir(int.Parse(TxtOgrenciid.Text));
                        MessageBox.Show("İlgili derse ait kayıt açıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lütfen Sayısal değer giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {      
                MessageBox.Show("Boş hücre bırakmayınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            baglanti.Close();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtOgrenciid.Text = "";
            TxtSinav1.Text = "";
            TxtSinav2.Text = "";
            TxtSinav3.Text = "";
            TxtProje.Text = "";
            TxtOrtalama.Text = "";
            TxtDurum.Text = "";

            
        }

        private void SinavNotlarForm_Load(object sender, EventArgs e)
        {        
            baglanti.Open();
            SqlCommand DersCek = new SqlCommand("Select * From Tbl_Dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(DersCek);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbDers.DisplayMember = "Dersad";
            CmbDers.ValueMember = "Dersid";
            CmbDers.DataSource = dt;
            baglanti.Close();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotGetir(int.Parse(TxtOgrenciid.Text));
           
        }

       
    }
}
