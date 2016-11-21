using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IM
{
    public partial class d_f_oknoKonfiguracji : Form
    {
        ustawienia konfiguracja = new ustawienia();

        public d_f_oknoKonfiguracji()
        {
            InitializeComponent();
            d_tb_adresIP.Text = konfiguracja.s_adresIP;
            d_nud_port.Value = konfiguracja.s_port;
        }

        private void d_tb_adresIP_Validating(object sender, CancelEventArgs e)
        {
            Regex reg = new Regex(@"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
            Match sprawdzenie = reg.Match(d_tb_adresIP.Text);
            if (!sprawdzenie.Success)
            {
                d_b_zapisz.Enabled = false;
                MessageBox.Show("Błędny adres IP. Adres powinien mieć postać np. 192.168.2.1", "Błąd adresu IP");
            }
            else
                d_b_zapisz.Enabled = true;
        }

        private void d_b_zapisz_Click(object sender, EventArgs e)
        {
            konfiguracja.s_adresIP = d_tb_adresIP.Text;
            konfiguracja.s_port = d_nud_port.Value;
            konfiguracja.Save();
            this.Close();
        }

        private void d_tb_adresIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.d_b_zapisz_Click(sender, e);
        }

        private void d_nud_port_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.d_b_zapisz_Click(sender, e);
        }

        private void d_tb_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.d_b_zapisz_Click(sender, e);
        }
    }
}
