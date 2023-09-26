using NotSistemi.DataSet1TableAdapters;
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
    public partial class OgretmenAyarForm : Form
    {
        public OgretmenAyarForm()
        {
            InitializeComponent();
        }

        //bağlantı
        SqlConnection baglanti = new SqlConnection("Data Source=FatihBuzac\\SQLEXPRESS;Initial Catalog=NotSistemi;Integrated Security=True");

        DataSet1TableAdapters.Tbl_OgretmenlerTableAdapter ds =new DataSet1TableAdapters.Tbl_OgretmenlerTableAdapter();

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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            TxtOgrtad.Text = "";
            TxtOgrtid.Text = "";
            CmbBrans.Text = "";
        }

        private void OgretmenAyarForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.OgretmenListele();
            baglanti.Open();
            SqlCommand DersCek = new SqlCommand("Select * From Tbl_Dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(DersCek);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbBrans.DisplayMember = "Dersad";
            CmbBrans.ValueMember = "Dersid";
            CmbBrans.DataSource = dt;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtOgrtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();           
            TxtOgrtad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtOgrtad.Text!="") {
                ds.OgretmenEkle(byte.Parse(CmbBrans.SelectedValue.ToString()), TxtOgrtad.Text);
                dataGridView1.DataSource = ds.OgretmenListele();
                MessageBox.Show("Öğretmen eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Öğretmen ismi giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtOgrtid.Text != "")
            {
                ds.OgretmenSil(byte.Parse(TxtOgrtid.Text));
                dataGridView1.DataSource = ds.OgretmenListele();
                MessageBox.Show("Öğretmen silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silinecek öğretmeni seçiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtOgrtid.Text!="" && TxtOgrtad.Text!="" && CmbBrans.Text!="")
            {
                ds.OgretmenGuncelle(byte.Parse(CmbBrans.SelectedValue.ToString()),TxtOgrtad.Text,byte.Parse(TxtOgrtid.Text));
                dataGridView1.DataSource = ds.OgretmenListele();
                MessageBox.Show("Öğretmen güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Güncellenecek öğretmeni seçiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
