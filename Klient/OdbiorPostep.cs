using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace IM
{
    public partial class d_f_postepPobierania : Form
    {
        private string p;
        private d_f_klient d_f_klient;
        private long postep = 0;
        private MessageData komunikat;
        IMClass kk = new IMClass();
        private oknoRozmowy oknoRozmowy;

        public d_f_postepPobierania(string p, IM.d_f_klient d_f_klient, oknoRozmowy oknoRozmowy)
        {
            InitializeComponent();
            this.p = p;
            this.d_f_klient = d_f_klient;
            this.oknoRozmowy = oknoRozmowy;
            d_l_plik.Text = d_f_klient.plik;
            d_l_plik.Location = new Point((this.Size.Width - d_l_plik.Size.Width) / 2, d_l_plik.Location.Y);
            d_bw_odbieraj.RunWorkerAsync();
        }

        public d_f_postepPobierania(IM.d_f_klient d_f_klient, MessageData komunikat, string p)
        {
            InitializeComponent();
            this.d_f_klient = d_f_klient;
            this.komunikat = komunikat;
            this.p = p;
            this.Text = "Postęp wysyłania pliku";
            d_l_plik.Text = p;
            d_l_plik.Location = new Point((this.Size.Width - d_l_plik.Size.Width) / 2, d_l_plik.Location.Y);
            d_bw_wysylaj.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d_pb_postep.Value = (int)((postep * 100) / d_f_klient.rozmiar);
        }

        private void d_bw_odbieraj_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            ustawienia konfiguracja = new ustawienia();
            TcpListener serwer = new TcpListener(IPAddress.Parse(d_f_klient.klient.Client.LocalEndPoint.ToString().Split(':')[0]), (int)konfiguracja.s_port + 1);
            serwer.Start();
            TcpClient client = serwer.AcceptTcpClient();
            int BuforSize = 0;
            byte[] ReceiveBufor = new byte[client.ReceiveBufferSize];
            NetworkStream stream = client.GetStream();
            FileStream nowyPlik = new FileStream(p, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            while ((BuforSize = stream.Read(ReceiveBufor, 0, ReceiveBufor.Length)) > 0)
            {
                if (bw.CancellationPending == true)
                {
                    e.Cancel = true;
                    nowyPlik.Close();
                    stream.Close();
                    client.Close();
                    serwer.Stop();
                    return;
                }
                nowyPlik.Write(ReceiveBufor, 0, BuforSize);
                postep += BuforSize;
            }
            if (postep != d_f_klient.rozmiar)
                this.Invoke((MethodInvoker)delegate() { kk.WpiszTekst(oknoRozmowy.f_wb_oknorozmowy, "IM", "Transfer się nie powiódł"); });
            nowyPlik.Close();
            stream.Close();
            client.Close();
            serwer.Stop();
            this.Invoke((MethodInvoker)delegate() { this.Close(); });
        }

        private void d_f_postepPobierania_FormClosing(object sender, FormClosingEventArgs e)
        {
            d_bw_odbieraj.CancelAsync();
            d_bw_wysylaj.CancelAsync();
        }

        private void d_bw_wysylaj_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            ustawienia konfiguracja = new ustawienia();
            FileStream file = File.OpenRead(d_f_klient.okna[komunikat.nadawca].infoFile.FullName);
            int BuforSize = 0;
            TcpClient client = new TcpClient(komunikat.tresc.Split(';')[1].Split(':')[0], (int)konfiguracja.s_port + 1);
            byte[] SendBufor = new byte[client.ReceiveBufferSize];
            NetworkStream stream = client.GetStream();
            while ((BuforSize = file.Read(SendBufor, 0, SendBufor.Length)) > 0)
            {
                if (bw.CancellationPending == true)
                {
                    e.Cancel = true;
                    file.Close();
                    stream.Close();
                    client.Close();

                    return;
                }
                try
                {
                    stream.Write(SendBufor, 0, BuforSize);
                    postep += BuforSize;
                }
                catch
                {
                    if (d_f_klient.okna.ContainsKey(komunikat.nadawca))
                        kk.WpiszTekst(((oknoRozmowy)d_f_klient.okna[komunikat.nadawca]).f_wb_oknorozmowy, "IM", "Transfer się nie powiódł");
                    this.Invoke((MethodInvoker)delegate() { this.Close(); });
                    return;
                }
            }
            file.Close();
            stream.Close();
            client.Close();
            this.Invoke((MethodInvoker)delegate() { this.Close(); });
        }
    }
}
