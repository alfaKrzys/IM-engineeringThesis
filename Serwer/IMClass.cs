using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace IM
{
    delegate void SetTextHTMLCallBack(WebBrowser d_wb_oknorozmowy, string p);
    delegate void SetTextCallBack(ListBox d_lb_komunikaty, string p);
    delegate void RemoveItemsCallBack(ListBox d_lb_komunikaty, object p);
    delegate void SetScrollCallBack(ListBox lista);

    struct clientInfo
    {
        public BackgroundWorker watek;
        public TcpClient tcpclient;
    }

    [Serializable]
    public struct MessageData
    {
        public string komenda;
        public string odbiorca;
        public string nadawca;
        public string tresc;
    }

    class IMClass
    {
        internal void SetText(ListBox d_lb_komunikaty, string p)
        {
            if (d_lb_komunikaty.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetText);
                d_lb_komunikaty.Invoke(f, new object[] { d_lb_komunikaty, p });
            }
            else
            {
                d_lb_komunikaty.Items.Add(p);
                SetScroll(d_lb_komunikaty);
            }
        }

        internal string ConvertToXML(MessageData komprzet)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MessageData));
            StringWriter stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, komprzet);
            return stringWriter.ToString();
        }

        internal MessageData ConvertOutXML(string komprzet)
        {
            StringReader stringReader = new StringReader(komprzet);
            XmlSerializer serializer = new XmlSerializer(typeof(MessageData));
            MessageData wiadomosc = (MessageData)serializer.Deserialize(stringReader);
            return wiadomosc;
        }

        internal void RemoveItems(ListBox d_lb_listauzytk, object p)
        {
            if (d_lb_listauzytk.InvokeRequired)
            {
                RemoveItemsCallBack f = new RemoveItemsCallBack(RemoveItems);
                d_lb_listauzytk.Invoke(f, new object[] { d_lb_listauzytk, p });
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("UserDatabase.xml");
                XmlNodeList nodes = doc.SelectNodes("/USERS/user[@login=\"" + p + "\"]");
                string name = "";
                foreach (XmlNode node in nodes)
                {
                    name += node.LastChild.PreviousSibling.InnerText + " " + node.LastChild.LastChild.Value;
                }
                d_lb_listauzytk.Items.Remove(name);
            }
        }

        internal void SetScroll(ListBox _lista)
        {
            if (_lista.InvokeRequired)
            {
                SetScrollCallBack s = new SetScrollCallBack(SetScroll);
                _lista.Invoke(s, new object[] { _lista });
            }
            else
            {
                _lista.TopIndex = _lista.Items.Count - 1;
            }
        }

        internal string GetLogin(string p, string lokalizacja)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(lokalizacja);
            XmlNodeList nodes = doc.SelectNodes("/USERS/user[firstname=\"" + p.Split(' ')[0] + "\" and lastname=\"" + p.Split(' ')[1] + "\"]");
            string name = "";
            foreach (XmlNode node in nodes)
            {
                name += node.FirstChild.InnerText;
            }
            return name;
        }

        internal string GetName(string p, string lokalizacja)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(lokalizacja);
            XmlNodeList nodes = doc.SelectNodes("/USERS/user[@login=\"" + p + "\"]");
            string name = "";
            foreach (XmlNode node in nodes)
            {
                name += node.LastChild.PreviousSibling.InnerText + " " + node.LastChild.LastChild.Value;
            }
            return name;
        }

        internal void WpiszTekst(WebBrowser d_wb_oknorozmowy, string p, string p_2)
        {
            SetTextHTML(d_wb_oknorozmowy, "<table><tr><td width=\"30%\"><b>" + p + "</b></td><td width=\"70%\">(" + DateTime.Now.ToShortTimeString() + "):</td></tr>");
            SetTextHTML(d_wb_oknorozmowy, "<tr><td colspan=2>" + p_2 + "</td></tr></table>");
            SetTextHTML(d_wb_oknorozmowy, "<hr>");
        }

        internal void SetTextHTML(WebBrowser f_wb_oknorozmowy, string tekst)
        {
            if (f_wb_oknorozmowy.InvokeRequired)
            {
                SetTextHTMLCallBack f = new SetTextHTMLCallBack(SetTextHTML);
                f_wb_oknorozmowy.Invoke(f, new object[] { f_wb_oknorozmowy, tekst });
            }
            else
            {
                f_wb_oknorozmowy.Document.Write(tekst);
                SetScroll(f_wb_oknorozmowy);
            }
        }

        internal void SetScroll(WebBrowser f_wb_oknorozmowy)
        {
            if (f_wb_oknorozmowy.InvokeRequired)
            {
                SetScrollCallBack s = new SetScrollCallBack(SetScroll);
                f_wb_oknorozmowy.Invoke(s, new object[] { f_wb_oknorozmowy });
            }
            else
            {
                f_wb_oknorozmowy.Document.Body.ScrollTop += Int16.MaxValue;
            }
        }

        internal string Hash(string p)
        {
            using (HashAlgorithm hA = HashAlgorithm.Create("SHA256"))
            {
                byte[] hasloByte = Encoding.Default.GetBytes(p);
                byte[] hashHaslo = hA.ComputeHash(hasloByte);
                return BitConverter.ToString(hashHaslo);
            }
        }

        internal void UaktualniListy(Hashtable klienci, ListBox d_lb_listauzytk, string lokalizacja)
        {
            MessageData komunikat = new MessageData();
            komunikat.komenda = "LISTUSERS";
            komunikat.tresc = "";
            for (int i = 0; i < d_lb_listauzytk.Items.Count; i++)
            {
                komunikat.tresc += d_lb_listauzytk.Items[i].ToString() + ";" + GetLogin(d_lb_listauzytk.Items[i].ToString(), lokalizacja) + ":";
            }
            foreach (DictionaryEntry de in klienci)
            {
                clientInfo odblisty = (clientInfo)klienci[de.Key];
                if (odblisty.tcpclient.Client.IsBound)
                {
                    try
                    {
                        BinaryWriter bwOdblisty = new BinaryWriter(odblisty.tcpclient.GetStream());
                        bwOdblisty.Write(ConvertToXML(komunikat));
                    }
                    catch
                    {
                        RemoveItems(d_lb_listauzytk, de.Key);
                        odblisty.tcpclient.Close();
                        odblisty.watek.CancelAsync();
                        klienci.Remove(de.Key);
                        UaktualniListy(klienci, d_lb_listauzytk, lokalizacja);
                        break;
                    }
                }
            }
        }
    }
}
