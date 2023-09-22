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
    public partial class OgretmenForm : Form
    {
        public OgretmenForm()
        {
            InitializeComponent();
        }

        private void BtnKulüp_Click(object sender, EventArgs e)
        {
            KulüpForm fr=new KulüpForm();
            fr.Show();
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            this.Hide();
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
