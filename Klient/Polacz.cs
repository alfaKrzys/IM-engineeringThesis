using System;
using System.Windows.Forms;

namespace IM
{
    public partial class d_f_polacz : Form
    {
        private d_f_klient d_f_klient;
        private IMClass kk = new IMClass();

        public d_f_polacz(d_f_klient d_f_klient)
        {
            InitializeComponent();
            this.d_f_klient = d_f_klient;
        }

        private void d_b_polacz_Click(object sender, EventArgs e)
        {
            d_f_klient.Polacz(d_tb_login.Text, kk.Hash(d_tb_haslo.Text));
            this.Close();
        }

        private void d_tb_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.d_b_polacz_Click(sender, e);
        }

        private void d_tb_haslo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.d_b_polacz_Click(sender, e);
        }
    }
}
