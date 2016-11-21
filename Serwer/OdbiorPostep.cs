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
        private long postep = 0;
        IMClass kk = new IMClass();
        private MessageData dane;
        private d_f_serwer d_f_serwer;
        private MessageData FileMessage;
        private long size;

        public d_f_postepPobierania(MessageData dane, d_f_serwer d_f_serwer)
        {
            InitializeComponent();
            this.dane = dane;
            this.d_f_serwer = d_f_serwer;
            this.Text = "Postęp wysyłania pliku";
            size = d_f_serwer.infoFile.Length;
            d_l_plik.Text = d_f_serwer.infoFile.Name;
            d_l_plik.Location = new Point((this.Size.Width - d_l_plik.Size.Width) / 2, d_l_plik.Location.Y);
            d_bw_wysylaj.RunWorkerAsync();
        }

        public d_f_postepPobierania(string p, MessageData FileMessage, IM.d_f_serwer d_f_serwer)
        {
            InitializeComponent();
            this.p = p;
            this.FileMessage = FileMessage;
            this.d_f_serwer = d_f_serwer;
            size = long.Parse(FileMessage.tresc.Split(';')[1]);
            d_l_plik.Text = p;
            d_l_plik.Location = new Point((this.Size.Width - d_l_plik.Size.Width) / 2, d_l_plik.Location.Y);
            d_bw_odbieraj.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d_pb_postep.Value = (int)((postep * 100) / size);
        }

        private void d_bw_odbieraj_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            string ip = "";
            try { ip = d_f_serwer.d_cb_adresIP.Text; }
            catch { this.Invoke((MethodInvoker)delegate() { ip = d_f_serwer.d_cb_adresIP.Text; }); }
            TcpListener serwer = new TcpListener(IPAddress.Parse(ip), (int)d_f_serwer.d_nud_port.Value + 1);
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
            if (postep != int.Parse(FileMessage.tresc.Split(';')[1]))
                this.Invoke((MethodInvoker)delegate() { kk.WpiszTekst(d_f_serwer.d_wb_oknorozmowy, "IM", "Transfer się nie powiódł"); });
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

            FileStream file = File.OpenRead(d_f_serwer.infoFile.FullName);
            int BuforSize = 0;
            TcpClient client = new TcpClient(dane.tresc.Split(';')[1].Split(':')[0], (int)d_f_serwer.d_nud_port.Value + 1);
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
                    kk.WpiszTekst(d_f_serwer.d_wb_oknorozmowy, "IM", "Transfer do użytkownika <b>" + kk.GetName(dane.nadawca, d_f_serwer.lokalizacja) + "</b> się nie powiódł");
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
