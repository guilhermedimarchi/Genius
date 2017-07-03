using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (rbFacil.Checked)
            {
                frmGeniusFacil f = new frmGeniusFacil();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            if (rbMedio.Checked)
            {
                frmGeniusMedio f = new frmGeniusMedio();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            if (rbDificil.Checked)
            {
                frmGeniusDificil f = new frmGeniusDificil();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
