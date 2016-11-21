using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace IM
{
    public partial class d_f_klient : Form
    {
        public TcpClient klient = null;
        public bool polaczenieAktywne = false;
        private MessageData komunikat = new MessageData();
        private IMClass kk = new IMClass();
        public NetworkStream ns;
        private DateTime ping;
        public Dictionary<string, oknoRozmowy> okna = new Dictionary<string, oknoRozmowy>();
        public Dictionary<string, string> tempRozmowy = new Dictionary<string, string>();
        public string plik;
        public long rozmiar;
        private d_f_oknoKonfiguracji oknoKonfiguracji;
        private d_f_polacz oknoPolacz;
        private zmienHaslo oknozmienHaslo;
        private d_f_archiwum oknoArchiwum;
        public string login;
        private bool brakODP2 = false;

        public d_f_klient()
        {
            InitializeComponent();
        }

        private void d_ms_konfiguracja_Click(object sender, EventArgs e)
        {
            if (oknoKonfiguracji == null)
            {
                oknoKonfiguracji = new d_f_oknoKonfiguracji();
                oknoKonfiguracji.Parent = this.Parent;
                oknoKonfiguracji.FormClosed += (s, ee) => { oknoKonfiguracji = null; };
                oknoKonfiguracji.Show();
            }
            else
            {
                oknoKonfiguracji.Activate();
                oknoKonfiguracji.WindowState = FormWindowState.Normal;
            }
        }

        private void d_ms_polacz_Click(object sender, EventArgs e)
        {
            if (oknoPolacz == null)
            {
                oknoPolacz = new d_f_polacz(this);
                oknoPolacz.Parent = this.Parent;
                oknoPolacz.FormClosed += (s, ee) => { oknoPolacz = null; };
                oknoPolacz.Show();
            }
            else
            {
                oknoPolacz.Activate();
                oknoPolacz.WindowState = FormWindowState.Normal;
            }
        }

        internal void d_ms_rozlacz_Click(object sender, EventArgs e)
        {
            if (polaczenieAktywne)
            {
                if (klient != null)
                {
                    ns.Close();
                    klient.Close();
                }
                d_ss_status.Text = "Rozłączony";
                d_ss_status.Image = Properties.Resources.circle_red;
                kk.SetText(d_lb_komunikaty, DateTime.Now.ToShortTimeString() + " Połączenie zostało przerwane");
                foreach (string key in okna.Keys)
                {
                    kk.WpiszTekst(okna[key].f_wb_oknorozmowy, "IM", "Połączenie z serwerem zostało utracone");
                    this.Invoke((MethodInvoker)delegate() { 
                        okna[key].f_tb_wiadomosc.Enabled = false;
                        okna[key].f_b_wyslij.Enabled = false;
                        okna[key].d_ll_wyslijPlik.Enabled = false;
                        okna[key].d_ll_tak.Enabled = false;
                        okna[key].d_ll_nie.Enabled = false;
                    });
                }
                d_ms_konfiguracja.Enabled = true;
                d_ms_polacz.Enabled = true;
                d_ms_rozlacz.Enabled = false;
                d_ms_haslo.Enabled = false;
                polaczenieAktywne = false;
                d_lb_uzytkownicy.Items.Clear();
                d_t_timer.Enabled = false;
                d_ms_archiwum.Enabled = false;

                this.Invoke((MethodInvoker)delegate()
                {
                    this.Text = "IM";
                });

                foreach (string key in tempRozmowy.Keys)
                {
                    File.Delete(tempRozmowy[key]);
                }
                tempRozmowy.Clear();
            }
        }

        private void d_bw_komunikacja_DoWork(object sender, DoWorkEventArgs e)
        {
            BinaryReader czytanie = new BinaryReader(ns);
            ustawienia konfiguracja = new ustawienia();
            while (true)
            {
                try
                {
                    komunikat = kk.ConvertOutXML(czytanie.ReadString());
                }
                catch (IOException)
                {
                    return;
                }
                switch (komunikat.komenda)
                {
                    case "LISTUSERS":
                        kk.ClearText(d_lb_uzytkownicy);
                        string[] user = komunikat.tresc.Split(new char[] { ':' });
                        for (int i = 0; i < user.Length - 1; i++)
                        {
                            if (login != user[i].Split(';')[1])
                                kk.SetText(d_lb_uzytkownicy, user[i].Split(';')[0]);
                            else
                            {
                                this.Invoke((MethodInvoker)delegate()
                                {
                                    this.Text = "IM - " + user[i].Split(';')[0];
                                });
                            }
                        }
                        break;
                    case "PING":
                        ping = DateTime.Now;
                        break;
                    case "SAY":
                        kk.newMessage(this, komunikat);
                        break;
                    case "ERROR":
                        kk.newMessage(this, komunikat);
                        this.Invoke((MethodInvoker)delegate()
                        {
                            okna[komunikat.nadawca].f_tb_wiadomosc.Enabled = false;
                            okna[komunikat.nadawca].f_b_wyslij.Enabled = false;
                        });
                        break;
                    case "PASSANS":
                        kk.SetText(d_lb_komunikaty, komunikat.tresc);
                        break;
                    case "FILE":
                        kk.newMessage(this, komunikat, "IM", "Użytkownik przesyła plik: <b>" + komunikat.tresc.Split(';')[0] + "</b> o rozmiarze: <b>" + long.Parse(komunikat.tresc.Split(';')[1]) / 1024 + " Kb </b>");
                        plik = komunikat.tresc.Split(';')[0];
                        rozmiar = long.Parse(komunikat.tresc.Split(';')[1]);
                        this.Invoke((MethodInvoker)delegate()
                        {
                            okna[komunikat.nadawca].d_l_odbierz.Enabled = true;
                            okna[komunikat.nadawca].d_ll_tak.Enabled = true;
                            okna[komunikat.nadawca].d_ll_nie.Enabled = true;
                        });
                        break;
                    case "FILEYES":
                        kk.newMessage(this, komunikat, "IM", "Użytkownik potwierdził odbiór pliku: <b>" + komunikat.tresc.Split(';')[0] + "</b>");
                        rozmiar = okna[komunikat.nadawca].infoFile.Length;
                        this.Invoke((MethodInvoker)delegate()
                        {
                            d_f_postepPobierania oknoWysylanie = new d_f_postepPobierania(this, komunikat, okna[komunikat.nadawca].infoFile.Name);
                            oknoWysylanie.Parent = okna[komunikat.nadawca].Parent;
                            oknoWysylanie.Show();
                        });
                        break;
                    case "FILENO":
                        kk.newMessage(this, komunikat, "IM", "Użytkownik odrzucił transfer pliku: <b>" + plik + "</b>");
                        break;
                }
            }
        }

        private void d_t_timer_Tick(object sender, EventArgs e)
        {
            TimeSpan ostatniping = DateTime.Now - ping;
            if (ostatniping.CompareTo(new TimeSpan(0, 0, 0, 6)) >= 0)
            {
                if (brakODP2 == true)
                {
                    this.d_ms_rozlacz_Click(sender, e);
                    brakODP2 = false;
                }
                brakODP2 = true;
            }
        }

        private void d_lb_uzytkownicy_DoubleClick(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedItem != null && !okna.ContainsKey(((ListBox)sender).SelectedItem.ToString()))
            {
                kk.tworzOkno(this, ((ListBox)sender).SelectedItem.ToString());
            }
        }

        internal void Polacz(string p, string p_2)
        {
            if (!polaczenieAktywne)
            {
                ustawienia konfiguracja = new ustawienia();
                try
                {
                    klient = new TcpClient(konfiguracja.s_adresIP, (int)konfiguracja.s_port);
                }
                catch (SocketException se)
                {
                    kk.SetText(d_lb_komunikaty, se.Message);
                    return;
                }
                login = p;
                konfiguracja.Save();
                ns = klient.GetStream();
                polaczenieAktywne = true;
                d_ms_konfiguracja.Enabled = false;
                d_ms_polacz.Enabled = false;
                d_ms_rozlacz.Enabled = true;
                d_ms_haslo.Enabled = true;
                d_t_timer.Enabled = true;
                d_ms_archiwum.Enabled = true;

                foreach (string key in okna.Keys)
                {
                    kk.WpiszTekst(okna[key].f_wb_oknorozmowy, "IM", "Połączenie wznowione");
                    this.Invoke((MethodInvoker)delegate()
                    {
                        okna[key].f_tb_wiadomosc.Enabled = true;
                        okna[key].f_b_wyslij.Enabled = true;
                        okna[key].d_ll_wyslijPlik.Enabled = true;
                        okna[key].d_ll_tak.Enabled = true;
                        okna[key].d_ll_nie.Enabled = true;
                    });
                }


                komunikat.nadawca = p;
                komunikat.odbiorca = klient.Client.RemoteEndPoint.ToString();
                komunikat.komenda = "HI";
                komunikat.tresc = p + ":" + p_2;
                BinaryWriter pisanie = new BinaryWriter(ns);
                pisanie.Write(kk.ConvertToXML(komunikat));

                BinaryReader czytanie = new BinaryReader(ns);
                komunikat = kk.ConvertOutXML(czytanie.ReadString());
                if (komunikat.komenda == "HI")
                {
                    kk.SetText(d_lb_komunikaty, DateTime.Now.ToShortTimeString() + " " + komunikat.tresc);
                    d_ss_status.Text = "Połączono";
                    d_ss_status.Image = Properties.Resources.circle_green;
                    d_bw_komunikacja.RunWorkerAsync();
                }
                else if (komunikat.komenda == "ERROR")
                {
                    kk.SetText(d_lb_komunikaty, komunikat.tresc);
                    d_ms_rozlacz_Click(new object(), new EventArgs());
                }
            }
        }

        private void d_ms_haslo_Click(object sender, EventArgs e)
        {
            if (oknozmienHaslo == null)
            {
                oknozmienHaslo = new zmienHaslo(this);
                oknozmienHaslo.Parent = this.Parent;
                oknozmienHaslo.FormClosed += (s, ee) => { oknozmienHaslo = null; };
                oknozmienHaslo.Show();
            }
            else
            {
                oknozmienHaslo.Activate();
                oknozmienHaslo.WindowState = FormWindowState.Normal;
            }
        }

        private void d_f_klient_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (string key in tempRozmowy.Keys)
            {
                File.Delete(tempRozmowy[key]);
            }
        }

        private void d_ms_archiwum_Click(object sender, EventArgs e)
        {
            if (oknoArchiwum == null)
            {
                oknoArchiwum = new d_f_archiwum(this);
                oknoArchiwum.Parent = this.Parent;
                oknoArchiwum.FormClosed += (s, ee) => { oknoArchiwum = null; };
                oknoArchiwum.Show();
            }
            else
            {
                oknoArchiwum.Activate();
                oknoArchiwum.WindowState = FormWindowState.Normal;
            }
        }

        private void d_f_klient_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
            }
        }

        private void d_ni_tray_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
    }
}

