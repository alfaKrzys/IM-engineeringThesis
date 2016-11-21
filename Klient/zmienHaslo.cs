using System;
using System.IO;
using System.Windows.Forms;

namespace IM
{
    public partial class zmienHaslo : Form
    {
        private d_f_klient d_f_klient;
        private IMClass kk = new IMClass();

        public zmienHaslo(d_f_klient d_f_klient)
        {
            InitializeComponent();
            this.d_f_klient = d_f_klient;
        }

        private void d_b_zmien_Click(object sender, EventArgs e)
        {
            if (d_tb_noweHaslo.Text != d_tb_noweHaslo2.Text)
            {
                MessageBox.Show("Nowe hasło w pierwszym wierszu i w drugim musi być takie samo", "Błąd zmiany hasła", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrWhiteSpace(d_tb_strHaslo.Text))
            {
                MessageBox.Show("Musisz podać stare hasło", "Błąd zmiany hasła", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ustawienia konfiguracja = new ustawienia();
                MessageData nowehaslo = new MessageData();
                nowehaslo.komenda = "NEWPASS";
                nowehaslo.tresc = kk.Hash(d_tb_strHaslo.Text) + ":" + kk.Hash(d_tb_noweHaslo.Text);
                nowehaslo.nadawca = d_f_klient.login;
                nowehaslo.odbiorca = "Serwer";
                BinaryWriter bw = new BinaryWriter(d_f_klient.ns);
                bw.Write(kk.ConvertToXML(nowehaslo));
                this.Close();
            }
        }

        private void d_tb_strHaslo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.d_b_zmien_Click(sender, e);
        }

        private void d_tb_noweHaslo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.d_b_zmien_Click(sender, e);
        }

        private void d_tb_noweHaslo2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.d_b_zmien_Click(sender, e);
        }
    }
}
