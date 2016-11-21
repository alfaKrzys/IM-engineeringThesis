using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml;

namespace IM
{
    public partial class oknoRozmowy : Form
    {
        private string p;
        private IMClass kk = new IMClass();
        MessageData wiadomosc = new MessageData();
        private d_f_klient d_f_klient;
        private int PozycjaKursora;
        public FileInfo infoFile;

        public oknoRozmowy(string p, d_f_klient d_f_klient)
        {
            InitializeComponent();
            this.p = p;
            this.d_f_klient = d_f_klient;
            this.Text = p;
            ustawienia konfiguracja = new ustawienia();
            wiadomosc.nadawca = d_f_klient.login;
            this.GotFocus += (s, e) => { f_wb_oknorozmowy.Document.Body.ScrollTop += Int16.MaxValue; };
            if(d_f_klient.tempRozmowy.ContainsKey(p))
            {
                using (StreamReader sr = new StreamReader(d_f_klient.tempRozmowy[p]))
                {
                    while (sr.Peek() >= 0)
                    {
                        f_wb_oknorozmowy.Document.Write(sr.ReadLine());
                    }
                }
                f_wb_oknorozmowy.Document.Write("<html><head><style>body, table{font-size:10pt; font-family:Verdana, Geneva, sans-serif; margin:3px, 3px, 3px, 3px; font-color:black;}</style></head><body width=\"" + (f_wb_oknorozmowy.ClientSize.Width - 20).ToString() + "\">");
            }
            else
                f_wb_oknorozmowy.Document.Write("<html><head><style>body, table{font-size:10pt; font-family:Verdana, Geneva, sans-serif; margin:3px, 3px, 3px, 3px; font-color:black;}</style></head><body width=\"" + (f_wb_oknorozmowy.ClientSize.Width - 20).ToString() + "\">");
        }

        private void f_b_wyslij_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(f_tb_wiadomosc.Text) && d_f_klient.polaczenieAktywne)
            {
                BinaryWriter pisanie = new BinaryWriter(d_f_klient.ns);
                wiadomosc.komenda = "SAY";
                wiadomosc.odbiorca = p;
                wiadomosc.tresc = f_tb_wiadomosc.Text;
                try
                {
                    
                    pisanie.Write(kk.ConvertToXML(wiadomosc));
                }
                catch (IOException)
                {
                    d_f_klient.d_ms_rozlacz_Click(sender, e);
                }
                kk.WpiszTekst(f_wb_oknorozmowy, "ja", f_tb_wiadomosc.Text);
                f_tb_wiadomosc.Text = "";
            }
        }

        private void f_tb_wiadomosc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.f_b_wyslij_Click(sender, e);
        }

        private void f_bold_Click(object sender, EventArgs e)
        {
            WprowadzTag("<b></b>");
        }

        private void WprowadzTag(string tag)
        {
            string kod = f_tb_wiadomosc.Text;
            f_tb_wiadomosc.Text = kod.Insert(PozycjaKursora, tag);
            f_tb_wiadomosc.Focus();
            if (tag == "<br>" || tag == "<hr>")
            {
                f_tb_wiadomosc.Select(PozycjaKursora + tag.Length, 0);
                PozycjaKursora += tag.Length;
            }
            else
            {
                f_tb_wiadomosc.Select(PozycjaKursora + tag.Length / 2, 0);
                PozycjaKursora += tag.Length / 2;
            }
        }

        private void f_italic_Click(object sender, EventArgs e)
        {
            WprowadzTag("<i></i>");
        }

        private void f_tb_wiadomosc_KeyUp(object sender, KeyEventArgs e)
        {
            PozycjaKursora = f_tb_wiadomosc.SelectionStart;
        }

        private void f_tb_wiadomosc_MouseUp(object sender, MouseEventArgs e)
        {
            PozycjaKursora = f_tb_wiadomosc.SelectionStart;
        }

        private void oknoRozmowy_FormClosed(object sender, FormClosedEventArgs e)
        {
            f_wb_oknorozmowy.Document.Write("</body></html>");
            if (!d_f_klient.tempRozmowy.ContainsKey(p))
            {
                string temp = Path.GetTempFileName();
                StreamWriter sw = new StreamWriter(temp);
                sw.Write(f_wb_oknorozmowy.DocumentText);
                sw.Close();
                d_f_klient.tempRozmowy.Add(p, temp);
            }
            else
            {
                StreamWriter sw = new StreamWriter(d_f_klient.tempRozmowy[p]);
                sw.Write(f_wb_oknorozmowy.DocumentText);
                sw.Close();
            }
            zapiszDoArchiwum();
            d_f_klient.okna.Remove(p);
        }

        private void zapiszDoArchiwum()
        {
            using (IsolatedStorageFile ISpath = IsolatedStorageFile.GetMachineStoreForAssembly())
            {
                if (!ISpath.FileExists(Path.Combine("IM", "archiwum.xml")))
                {
                    ISpath.CreateDirectory("IM");
                    using (Stream s = new IsolatedStorageFileStream(Path.Combine("IM", "archiwum.xml"), FileMode.Create, ISpath))
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                        doc.AppendChild(docNode);
                        XmlNode ArchiwumNode = doc.CreateElement("Archiwum");
                        doc.AppendChild(ArchiwumNode);

                        XmlNode uzytkownikNode = doc.CreateElement("uzytkownik");
                        XmlAttribute uzytkownikAttribute = doc.CreateAttribute("login");
                        uzytkownikAttribute.Value = wiadomosc.nadawca;
                        uzytkownikNode.Attributes.Append(uzytkownikAttribute);
                        ArchiwumNode.AppendChild(uzytkownikNode);


                        XmlNode rozmowcaNode = doc.CreateElement("rozmowca");
                        XmlAttribute rozmowcaAttribute = doc.CreateAttribute("login");
                        rozmowcaAttribute.Value = p;
                        rozmowcaNode.Attributes.Append(rozmowcaAttribute);
                        uzytkownikNode.AppendChild(rozmowcaNode);

                        XmlNode czasNode = doc.CreateElement("czas");
                        XmlAttribute czasAttribute = doc.CreateAttribute("data");
                        czasAttribute.Value = DateTime.Now.ToShortDateString();
                        czasNode.Attributes.Append(czasAttribute);
                        czasNode.AppendChild(doc.CreateTextNode(f_wb_oknorozmowy.DocumentText));
                        rozmowcaNode.AppendChild(czasNode);
                        doc.Save(s);
                    }
                }
                else
                {
                    using (Stream s = new IsolatedStorageFileStream(Path.Combine("IM", "archiwum.xml"), FileMode.Open, ISpath))
                    {
                        int pkt = 0;
                        XmlDocument doc = new XmlDocument();
                        doc.Load(s);
                        pkt += doc.SelectNodes("/Archiwum/uzytkownik[@login=\"" + wiadomosc.nadawca + "\"]").Count;
                        pkt += doc.SelectNodes("/Archiwum/uzytkownik[@login=\"" + wiadomosc.nadawca + "\"]/rozmowca[@login=\"" + p + "\"]").Count;
                        pkt += doc.SelectNodes("/Archiwum/uzytkownik[@login=\"" + wiadomosc.nadawca + "\"]/rozmowca[@login=\"" + p + "\"]/czas[@data=\"" + DateTime.Now.ToShortDateString() + "\"]").Count;
                        switch (pkt)
                        {
                            case 0:
                                XmlNodeList nodes = doc.SelectNodes("/Archiwum");
                                foreach (XmlNode node in nodes)
                                {
                                    XmlNode xmlnode = AddXMLElement("uzytkownik", null, node);
                                    AddXMLAttribute("login", wiadomosc.nadawca, xmlnode);
                                }
                                goto case 1;
                            case 1:
                                XmlNodeList nodes1 = doc.SelectNodes("/Archiwum/uzytkownik[@login=\"" + wiadomosc.nadawca + "\"]");
                                foreach (XmlNode node in nodes1)
                                {
                                    XmlNode xmlnode = AddXMLElement("rozmowca", null, node);
                                    AddXMLAttribute("login", p, xmlnode);
                                }
                                goto case 2;
                            case 2:
                                XmlNodeList nodes2 = doc.SelectNodes("/Archiwum/uzytkownik[@login=\"" + wiadomosc.nadawca + "\"]/rozmowca[@login=\"" + p + "\"]");
                                foreach (XmlNode node in nodes2)
                                {
                                    XmlNode xmlnode = AddXMLElement("czas", null, node);
                                    AddXMLAttribute("data", DateTime.Now.ToShortDateString(), xmlnode);
                                }
                                goto case 3;
                            case 3:
                                {
                                    string tekst = "";
                                    XmlNodeList nodes3 = doc.SelectNodes("/Archiwum/uzytkownik[@login=\"" + wiadomosc.nadawca + "\"]/rozmowca[@login=\"" + p + "\"]/czas[@data=\"" + DateTime.Now.ToShortDateString() + "\"]");
                                    foreach (XmlNode node in nodes3)
                                    {
                                        using (StreamReader sr = new StreamReader(d_f_klient.tempRozmowy[p]))
                                        {
                                            while (sr.Peek() >= 0)
                                            {
                                                tekst += sr.ReadLine();
                                            }
                                        }
                                        node.InnerText += tekst.Substring(tekst.LastIndexOf("<html>"));
                                    }
                                    s.SetLength(0);
                                    doc.Save(s);
                                    break;
                                }
                        }
                    }
                }
            }
        }

        XmlNode AddXMLElement(string name, string text, XmlNode parent)
        {
            XmlNode node = parent.OwnerDocument.CreateElement(name);
            parent.AppendChild(node);
            if (text != null)
            {
                XmlNode content;
                content = parent.OwnerDocument.CreateTextNode(text);
                node.AppendChild(content);
            }
            return node;
        }

        XmlNode AddXMLAttribute(string attname, string text, XmlNode parent)
        {
            XmlAttribute attribute;
            attribute = parent.OwnerDocument.CreateAttribute(attname);
            attribute.Value = text;
            parent.Attributes.Append(attribute);
            return attribute;
        }

        private void d_ll_wyslijPlik_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (d_ofd_wyslijPlik.ShowDialog() == DialogResult.OK && d_f_klient.polaczenieAktywne)
            {
                if (File.Exists(d_ofd_wyslijPlik.FileName))
                {
                    BinaryWriter pisanie = new BinaryWriter(d_f_klient.ns);
                    wiadomosc.komenda = "FILE";
                    infoFile = new FileInfo(d_ofd_wyslijPlik.FileName);
                    wiadomosc.tresc = d_ofd_wyslijPlik.FileName.Substring(d_ofd_wyslijPlik.FileName.LastIndexOf("\\") + 1) + ";" + infoFile.Length;
                    wiadomosc.odbiorca = p;
                    try
                    {
                        pisanie.Write(kk.ConvertToXML(wiadomosc));
                    }
                    catch (IOException)
                    {
                        d_f_klient.d_ms_rozlacz_Click(sender, e);
                    }
                    kk.WpiszTekst(f_wb_oknorozmowy, "IM", "Próba wysłania pliku: <b>"+ infoFile.Name+"</b>");
                }
            }
        }

        private void d_ll_tak_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            d_sfd_zapiszPlik.FileName = d_f_klient.plik;
            if (d_sfd_zapiszPlik.ShowDialog() == DialogResult.OK)
            {
                d_f_postepPobierania oknopostep = new d_f_postepPobierania(d_sfd_zapiszPlik.FileName, d_f_klient, this);
                oknopostep.Parent = this.Parent;
                oknopostep.Show();
                d_l_odbierz.Enabled = false;
                d_ll_tak.Enabled = false;
                d_ll_nie.Enabled = false;
                BinaryWriter pisanie = new BinaryWriter(d_f_klient.ns);
                wiadomosc.komenda = "FILEYES";
                wiadomosc.tresc = d_f_klient.plik;
                wiadomosc.odbiorca = p;
                try
                {
                    pisanie.Write(kk.ConvertToXML(wiadomosc));
                }
                catch (IOException)
                {
                    d_f_klient.d_ms_rozlacz_Click(sender, e);
                }
            }
            else
            {
                d_ll_nie_LinkClicked(sender, e);
            }
        }

        private void d_ll_nie_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            d_l_odbierz.Enabled = false;
            d_ll_tak.Enabled = false;
            d_ll_nie.Enabled = false;
            BinaryWriter pisanie = new BinaryWriter(d_f_klient.ns);
            wiadomosc.komenda = "FILENO";
            wiadomosc.tresc = d_f_klient.plik;
            wiadomosc.odbiorca = p;
            try
            {
                pisanie.Write(kk.ConvertToXML(wiadomosc));
            }
            catch (IOException)
            {
                d_f_klient.d_ms_rozlacz_Click(sender, e);
            }
        }
    }
}
