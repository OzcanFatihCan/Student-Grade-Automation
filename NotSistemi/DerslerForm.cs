using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotSistemi
{
    public partial class DerslerForm : Form
    {
        public DerslerForm()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.Tbl_DerslerTableAdapter();
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
        private void DerslerForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtDersad.Text != "")
            {
                ds.DersEkle(TxtDersad.Text);
                dataGridView1.DataSource = ds.DersListesi();
                MessageBox.Show("Ders eklemesi yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Boş girdi yapmayınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtDersad.Text != "" && TxtDersid.Text != "") {
                ds.DersGuncelle(TxtDersad.Text, byte.Parse(TxtDersid.Text));
                dataGridView1.DataSource = ds.DersListesi();
                MessageBox.Show("Ders güncellemesi yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen güncelleyeceğiniz dersi seçiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtDersad.Text != "" && TxtDersid.Text != "") {
                ds.DersSil(byte.Parse(TxtDersid.Text));
                dataGridView1.DataSource = ds.DersListesi();
            }
            else
            {
                MessageBox.Show("Lütfen sileceğiniz dersi seçiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtDersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDersad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            TxtDersad.Text = "";
            TxtDersid.Text = "";
        }
    }
}
