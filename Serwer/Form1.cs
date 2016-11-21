using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;


namespace IM
{
    public partial class d_f_serwer : Form
    {
        private TcpListener serwer = null;
        private TcpClient klient = null;
        private Hashtable klienci = new Hashtable();
        private bool aktywnySerwer = false;
        private IMClass kk = new IMClass();
        public FileInfo infoFile;
        private MessageData FileMessage;
        private ManageUsers okno;
        public string lokalizacja;

        public d_f_serwer()
        {
            InitializeComponent();
            IPHostEntry adresyIP = Dns.GetHostEntry(Dns.GetHostName());
            lokalizacja = Assembly.GetExecutingAssembly().Location.Substring(0, Assembly.GetExecutingAssembly().Location.LastIndexOf("\\") + 1) + "UserDatabase.xml";
            foreach (IPAddress pozycja in adresyIP.AddressList)
            {
                if (pozycja.IsIPv6LinkLocal == false)
                    d_cb_adresIP.Items.Add(pozycja.ToString());
            }
            d_wb_oknorozmowy.Document.Write("<html><head><style>body, table{font-size:10pt; font-family:Verdana, Geneva, sans-serif; margin:3px, 3px, 3px, 3px; font-color:black;}</style></head><body width=\"" + (d_wb_oknorozmowy.ClientSize.Width - 20).ToString() + "\">");
        }

        private void d_b_start_Click(object sender, EventArgs e)
        {
            if (!aktywnySerwer)
            {
                try
                {
                    serwer = new TcpListener(IPAddress.Parse(d_cb_adresIP.Text), (int)d_nud_port.Value);
                    serwer.Start();
                    d_bw_polaczenia.RunWorkerAsync();
                    d_bw_statusPol.RunWorkerAsync();
                    aktywnySerwer = true;
                }
                catch (Exception ex)
                {
                    kk.SetText(d_lb_komunikaty, DateTime.Now.ToShortTimeString() + " Błąd inicjacji serwera (" + ex.Message + ")");
                }
            }
        }

        private void d_b_stop_Click(object sender, EventArgs e)
        {
            if (aktywnySerwer)
            {
                kk.SetText(d_lb_komunikaty, DateTime.Now.ToShortTimeString() + " Serwer wyłączony");
                if (klient != null)
                    klient.Close();
                serwer.Stop();
                d_bw_polaczenia.CancelAsync();
                d_bw_statusPol.CancelAsync();
                d_lb_listauzytk.Items.Clear();
                klienci.Clear();
                aktywnySerwer = false;
            }
        }

        private void d_bw_polaczenia_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;
            serwer.Start();
            kk.SetText(d_lb_komunikaty, DateTime.Now.ToShortTimeString() + " Serwer oczekuje na połączenie...");
            while (true)
            {
                if (bw.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                try
                {
                    klient = serwer.AcceptTcpClient();
                }
                catch (SocketException)
                {
                    return;
                }
                NetworkStream ns = klient.GetStream();
                BinaryReader czytanie = new BinaryReader(ns);
                BinaryWriter pisanie = new BinaryWriter(ns);
                MessageData komunikat = kk.ConvertOutXML(czytanie.ReadString());
                if (komunikat.komenda == "HI")
                {
                    string temp = komunikat.odbiorca;
                    komunikat.odbiorca = komunikat.nadawca;
                    komunikat.nadawca = temp;
                    string[] auth = komunikat.tresc.Split(':');
                    XmlDocument doc = new XmlDocument();
                    if (File.Exists("UserDatabase.xml"))
                        doc.Load("UserDatabase.xml");
                    XmlNodeList nodes = doc.SelectNodes("/USERS/user[@login=\"" + auth[0] + "\" and pass=\"" + auth[1] + "\"]");
                    if (nodes.Count!=0)
                    {
                        string name = "";
                        foreach (XmlNode node in nodes)
                        {
                            name += node.LastChild.PreviousSibling.InnerText + " " + node.LastChild.LastChild.Value;
                        }

                        object[] argument = new object[] { komunikat.odbiorca };
                        BackgroundWorker watek = new BackgroundWorker();
                        watek.WorkerSupportsCancellation = true;
                        watek.DoWork += new DoWorkEventHandler(watek_DoWork);

                        clientInfo info = new clientInfo();
                        info.tcpclient = klient;
                        info.watek = watek;
                        try
                        {
                            klienci.Add(komunikat.odbiorca, info);
                        }
                        catch (ArgumentException)
                        {
                            kk.SetText(d_lb_komunikaty, DateTime.Now.ToShortTimeString() + " Próba ponownego zalogowania się użytkownika: " + komunikat.odbiorca);
                            komunikat.komenda = "ERROR";
                            komunikat.tresc = "Użytkownik o tym loginie jest już zalogowany";
                            pisanie.Write(kk.ConvertToXML(komunikat));
                            continue;
                        }
                        
                        komunikat.tresc = "Połączono z serwerem";
                        pisanie.Write(kk.ConvertToXML(komunikat));

                        watek.RunWorkerAsync(argument);
                        kk.SetText(d_lb_komunikaty, DateTime.Now.ToShortTimeString() + " Klient " + name + " podłączony");
                        kk.SetText(d_lb_listauzytk, name);
                        kk.UaktualniListy(klienci, d_lb_listauzytk, lokalizacja);
                    }
                    else
                    {
                        kk.SetText(d_lb_komunikaty, DateTime.Now.ToShortTimeString() + " Próba nieautoryzowanego dostępu: "+klient.Client.RemoteEndPoint.ToString());
                        komunikat.komenda = "ERROR";
                        komunikat.tresc = "Błąd hasła lub loginu";
                        pisanie.Write(kk.ConvertToXML(komunikat));
                    }
                }
            }
        }

        private void d_bw_statusPol_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;
            MessageData ping = new MessageData();
            ping.komenda = "PING";
            while (true)
            {
                if (bw.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                if (klienci.Count != 0)
                {
                    foreach (DictionaryEntry de in klienci)
                    {
                        clientInfo odblisty = (clientInfo)klienci[de.Key];
                        try
                        {
                            BinaryWriter pisanie = new BinaryWriter(odblisty.tcpclient.GetStream());
                            pisanie.Write(kk.ConvertToXML(ping));
                        }
                        catch (Exception)
                        {
                            kk.RemoveItems(d_lb_listauzytk, de.Key);
                            kk.SetText(d_lb_komunikaty, DateTime.Now.ToShortTimeString() + " Klient " + kk.GetName((string)de.Key, lokalizacja) + " rozłączony");
                            odblisty.tcpclient.Close();
                            odblisty.watek.CancelAsync();
                            klienci.Remove(de.Key);
                            kk.UaktualniListy(klienci, d_lb_listauzytk, lokalizacja);
                            break;
                        }
                    }
                }
                System.Threading.Thread.Sleep(3000);
            }
        }

        private void watek_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;
            string userkey = (string)(e.Argument as object[])[0];
            clientInfo uzytkownik = (clientInfo)klienci[userkey];

            BinaryReader r = new BinaryReader(uzytkownik.tcpclient.GetStream());
            BinaryWriter w = new BinaryWriter(uzytkownik.tcpclient.GetStream());
            MessageData dane;
            while (true)
            {
                if (bw.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                try
                {
                    dane = kk.ConvertOutXML(r.ReadString());
                }
                catch (IOException)
                {
                    return;
                }
                switch (dane.komenda)
                {
                    case "NEWPASS":
                        dane.komenda = "PASSANS";
                        string temp = dane.odbiorca;
                        dane.odbiorca = dane.nadawca;
                        dane.nadawca = temp;
                        XmlDocument doc = new XmlDocument();
                        doc.Load("UserDatabase.xml");
                        XmlNodeList nodes = doc.SelectNodes("/USERS/user[@login=\"" + dane.odbiorca + "\" and pass=\"" + dane.tresc.Split(':')[0] + "\"]");
                        if (nodes.Count != 0)
                        {
                            XmlNode newNode = doc.CreateElement("pass");
                            newNode.AppendChild(doc.CreateTextNode(dane.tresc.Split(':')[1]));
                            foreach (XmlNode node in nodes)
                            {
                                node.ReplaceChild(newNode, node.FirstChild.NextSibling);
                            }
                            doc.Save("UserDatabase.xml");
                            dane.tresc = "Operacja zmiany hasła powiodła się.";
                            try
                            {
                                w.Write(kk.ConvertToXML(dane));
                            }
                            catch
                            {
                                return;
                            }
                        }
                        else
                        {
                            dane.tresc = "Operacja zmiany hasła NIE powiodła się.";
                            try
                            {
                                w.Write(kk.ConvertToXML(dane));
                            }
                            catch
                            {
                                return;
                            }
                        }
                        break;
                    case "FILEYES":
                        try
                        {
                            dane.tresc += ";" + uzytkownik.tcpclient.Client.RemoteEndPoint.ToString();
                            clientInfo odbKlient = (clientInfo)klienci[kk.GetLogin(dane.odbiorca, lokalizacja)];
                            dane.nadawca = kk.GetName(dane.nadawca, lokalizacja);
                            BinaryWriter bwKlient = new BinaryWriter(odbKlient.tcpclient.GetStream());
                            bwKlient.Write(kk.ConvertToXML(dane));
                            dane.komenda = "";
                        }
                        catch (Exception)
                        {
                            if (dane.odbiorca == "ADMIN")
                            {
                                kk.WpiszTekst(d_wb_oknorozmowy, "IM", "Użytkownik potwierdził odbiór pliku: <b>" + dane.tresc.Split(';')[0] + "</b>");
                                this.Invoke((MethodInvoker)delegate()
                                {
                                    d_f_postepPobierania oknoWysylanie = new d_f_postepPobierania(dane, this);
                                    oknoWysylanie.Parent = this.Parent;
                                    oknoWysylanie.Show();
                                });
                                continue;
                            }
                            dane.komenda = "ERROR";
                            string tmp = dane.odbiorca;
                            dane.odbiorca = dane.nadawca;
                            dane.nadawca = tmp;
                            dane.tresc = "Serwer: Użytkownik się rozłączył";
                            w.Write(kk.ConvertToXML(dane));
                        }
                        break;
                    default:
                        try
                        {
                            clientInfo odbKlient = (clientInfo)klienci[kk.GetLogin(dane.odbiorca, lokalizacja)];
                            dane.nadawca = kk.GetName(dane.nadawca, lokalizacja);
                            BinaryWriter bwKlient = new BinaryWriter(odbKlient.tcpclient.GetStream());
                            bwKlient.Write(kk.ConvertToXML(dane));
                            dane.komenda = "";
                        }
                        catch (Exception)
                        {
                            if (dane.odbiorca == "ADMIN")
                            {
                                if (dane.komenda == "FILE")
                                {
                                    FileMessage = dane;
                                    kk.WpiszTekst(d_wb_oknorozmowy, "IM", "Użytkownik przesyła plik: <b>" + dane.tresc.Split(';')[0] + "</b> o rozmiarze: <b>" + long.Parse(dane.tresc.Split(';')[1]) / 1024 + " Kb </b>");
                                    this.Invoke((MethodInvoker)delegate()
                                    {
                                        d_l_odbierz.Enabled = true;
                                        d_ll_tak.Enabled = true;
                                        d_ll_nie.Enabled = true;
                                    });
                                }
                                else if (dane.komenda == "FILENO")
                                {
                                    kk.WpiszTekst(d_wb_oknorozmowy, "IM", "Użytkownik odrzucił transfer pliku: <b>" + infoFile.Name + "</b>");
                                }
                                else
                                    kk.WpiszTekst(d_wb_oknorozmowy, kk.GetName(dane.nadawca, lokalizacja), dane.tresc);
                                continue;
                            }
                            dane.komenda = "ERROR";
                            string tmp = dane.odbiorca;
                            dane.odbiorca = dane.nadawca;
                            dane.nadawca = tmp;
                            dane.tresc = "Serwer: Użytkownik się rozłączył";
                            w.Write(kk.ConvertToXML(dane));
                        }
                        break;
                }
            }
        }

        private void d_tsm_zarzadzaj_Click(object sender, EventArgs e)
        {
            if (okno == null)
            {
                okno = new ManageUsers(lokalizacja);
                okno.Parent = this.Parent;
                okno.FormClosed += (s, ee) => { okno = null; };
                okno.Show();
            }
            else
            {
                okno.Activate();
                okno.WindowState = FormWindowState.Normal;
            }
        }

        private void d_b_usun_Click(object sender, EventArgs e)
        {
            if (d_lb_listauzytk.SelectedItem != null)
            {
                for (int i = 0; i < d_lb_listauzytk.SelectedItems.Count; i++)
                {

                    string delUser = kk.GetLogin((string)d_lb_listauzytk.SelectedItems[i], lokalizacja);
                    clientInfo odblisty = (clientInfo)klienci[delUser];
                    kk.RemoveItems(d_lb_listauzytk, delUser);
                    kk.SetText(d_lb_komunikaty, DateTime.Now.ToShortTimeString() + " Klient [" + odblisty.tcpclient.Client.RemoteEndPoint.ToString() + "] rozłączony");
                    odblisty.tcpclient.Close();
                    odblisty.watek.CancelAsync();
                    klienci.Remove(delUser);
                    kk.UaktualniListy(klienci, d_lb_listauzytk, lokalizacja);
                }
            }
        }

        private void d_b_wyslij_Click(object sender, EventArgs e)
        {
            if (d_lb_listauzytk.SelectedItem != null && !string.IsNullOrWhiteSpace(d_tb_wyslij.Text))
            {
                MessageData komunikat = new MessageData();
                komunikat.nadawca = "ADMIN";
                komunikat.komenda = "SAY";
                komunikat.tresc = d_tb_wyslij.Text;
                kk.WpiszTekst(d_wb_oknorozmowy, "ADMIN", d_tb_wyslij.Text);
                for (int i = 0; i<d_lb_listauzytk.SelectedItems.Count; i++)
                {
                    komunikat.odbiorca = (string)d_lb_listauzytk.SelectedItems[i];
                    clientInfo odbKlient = (clientInfo)klienci[kk.GetLogin((string)d_lb_listauzytk.SelectedItems[i], lokalizacja)];
                    BinaryWriter bwKlient = new BinaryWriter(odbKlient.tcpclient.GetStream());
                    try
                    {
                        bwKlient.Write(kk.ConvertToXML(komunikat));
                    }
                    catch (Exception)
                    {
                        kk.WpiszTekst(d_wb_oknorozmowy, "serwer", "Błąd komunikacji z użytkownikiem");
                    }
                }
                d_tb_wyslij.Text = "";
            }
        }

        private void d_tb_wyslij_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.d_b_wyslij_Click(sender, e);
        }

        private void d_ll_wyslijPlik_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (d_lb_listauzytk.SelectedItem != null)
            {
                if (d_ofd_wyslijPlik.ShowDialog() == DialogResult.OK)
                {
                    infoFile = new FileInfo(d_ofd_wyslijPlik.FileName);
                    MessageData komunikat = new MessageData();
                    komunikat.nadawca = "ADMIN";
                    komunikat.komenda = "FILE";
                    komunikat.tresc = d_ofd_wyslijPlik.FileName.Substring(d_ofd_wyslijPlik.FileName.LastIndexOf("\\") + 1) + ";" + infoFile.Length; ;
                    kk.WpiszTekst(d_wb_oknorozmowy, "ADMIN", d_tb_wyslij.Text);
                    for (int i = 0; i < d_lb_listauzytk.SelectedItems.Count; i++)
                    {
                        komunikat.odbiorca = (string)d_lb_listauzytk.SelectedItems[i];
                        clientInfo odbKlient = (clientInfo)klienci[kk.GetLogin((string)d_lb_listauzytk.SelectedItems[i], lokalizacja)];
                        BinaryWriter bwKlient = new BinaryWriter(odbKlient.tcpclient.GetStream());
                        try
                        {
                            bwKlient.Write(kk.ConvertToXML(komunikat));
                        }
                        catch (Exception)
                        {
                            kk.WpiszTekst(d_wb_oknorozmowy, "serwer", "Błąd komunikacji z użytkownikiem");
                        }
                        kk.WpiszTekst(d_wb_oknorozmowy, "IM", "Próba wysłania pliku: <b>" + infoFile.Name + "</b> do użytkownika <b>" + komunikat.odbiorca + "</b>");
                    }
                }
            }
        }

        private void d_ll_nie_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BinaryWriter pisanie = new BinaryWriter(((clientInfo)klienci[FileMessage.nadawca]).tcpclient.GetStream());

            FileMessage.komenda = "FILENO";
            FileMessage.tresc = FileMessage.tresc.Split(';')[0];
            FileMessage.odbiorca = FileMessage.nadawca;
            FileMessage.nadawca = "ADMIN";
            try
            {
                pisanie.Write(kk.ConvertToXML(FileMessage));
            }
            catch (IOException)
            {
                return;
            }
            d_l_odbierz.Enabled = false;
            d_ll_tak.Enabled = false;
            d_ll_nie.Enabled = false;
        }

        private void d_ll_tak_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            d_sfd_zapiszPlik.FileName = FileMessage.tresc.Split(';')[0];
            if (d_sfd_zapiszPlik.ShowDialog() == DialogResult.OK)
            {
                d_f_postepPobierania oknopostep = new d_f_postepPobierania(d_sfd_zapiszPlik.FileName, FileMessage, this);
                oknopostep.Parent = this.Parent;
                oknopostep.Show();
            }

            BinaryWriter pisanie = new BinaryWriter(((clientInfo)klienci[FileMessage.nadawca]).tcpclient.GetStream());

            FileMessage.komenda = "FILEYES";
            FileMessage.tresc = FileMessage.tresc.Split(';')[0]+";"+serwer.LocalEndpoint.ToString();
            FileMessage.odbiorca = FileMessage.nadawca;
            FileMessage.nadawca = "ADMIN";
            try
            {
                pisanie.Write(kk.ConvertToXML(FileMessage));
            }
            catch (IOException)
            {
                return;
            }

            d_l_odbierz.Enabled = false;
            d_ll_tak.Enabled = false;
            d_ll_nie.Enabled = false;
        }
    }
}
