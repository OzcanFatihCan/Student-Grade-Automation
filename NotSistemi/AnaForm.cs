using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotSistemi
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OgrenciNotlarForm fr= new OgrenciNotlarForm();
            fr.numara = textBox1.Text;
            if (int.TryParse(fr.numara, out _))
                fr.Show();
            else
            {
                MessageBox.Show("Lütfen numara girişi yapınız", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OgretmenForm fr= new OgretmenForm();
            fr.Show();
        }

       

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
           
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
           
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnKapat_MouseHover(object sender, EventArgs e)
        {
            BtnKapat.BackColor = Color.Red;
        }

        private void BtnKapat_MouseLeave(object sender, EventArgs e)
        {
            BtnKapat.BackColor = Color.Transparent;
        }
    }
}
