using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace IM
{
    delegate void SetTextHTMLCallBack(WebBrowser d_wb_oknorozmowy, string p);
    delegate void SetTextCallBack(ListBox d_lb_komunikaty, string p);
    delegate void ClearTextCallBack(ListBox lista);
    delegate void SetScrollCallBack(WebBrowser d_wb_oknorozmowy);

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
        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        private Point punkt = new Point(10, 10);

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
                SetScrollListBox(d_lb_komunikaty);
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

        internal void ClearText(ListBox lista)
        {
            if (lista.InvokeRequired)
            {
                ClearTextCallBack f = new ClearTextCallBack(ClearText);
                lista.Invoke(f, new object[] { lista });
            }
            else
            {
                lista.Items.Clear();
            }
        }

        private void SetTextHTML(WebBrowser f_wb_oknorozmowy, string tekst)
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

        private void SetScroll(WebBrowser f_wb_oknorozmowy)
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

        internal void WpiszTekst(WebBrowser f_wb_oknorozmowy, string p, string p_2)
        {
            SetTextHTML(f_wb_oknorozmowy, "<table><tr><td width=\"30%\"><b>" + p + "</b></td><td width=\"70%\">(" + DateTime.Now.ToShortTimeString() + "):</td></tr>");
            SetTextHTML(f_wb_oknorozmowy, "<tr><td colspan=2>" + p_2 + "</td></tr></table>");
            SetTextHTML(f_wb_oknorozmowy, "<hr>");
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

        private void SetScrollListBox(ListBox _lista)
        {
            if (_lista.InvokeRequired)
            {
                ClearTextCallBack s = new ClearTextCallBack(SetScrollListBox);
                _lista.Invoke(s, new object[] { _lista });
            }
            else
            {
                _lista.TopIndex = _lista.Items.Count - 1;
            }
        }

        internal Point Lokacja(Size size)
        {
            if (punkt.Y + 10 + size.Height < Screen.PrimaryScreen.Bounds.Size.Height)
            {
                punkt.X += 10;
                punkt.Y += 10;
            }
            else if (punkt.X + 10 + size.Width < Screen.PrimaryScreen.Bounds.Size.Width)
            {
                punkt.X = 10 + size.Width;
                punkt.Y = 10;
            }
            else
            {
                punkt.X = 10;
                punkt.Y = 10;
            }
            return punkt;
        }

        internal void newMessage(d_f_klient d_f_klient, MessageData komunikat, string p, string p_2)
        {
            if (!d_f_klient.okna.ContainsKey(komunikat.nadawca))
                d_f_klient.Invoke((MethodInvoker)delegate() { tworzOkno(d_f_klient, komunikat.nadawca); });
            d_f_klient.Invoke((MethodInvoker)delegate()
            {
                if (!d_f_klient.okna[komunikat.nadawca].Focused)
                    FlashWindow(d_f_klient.okna[komunikat.nadawca].Handle, true);
            });
            WpiszTekst(d_f_klient.okna[komunikat.nadawca].f_wb_oknorozmowy, p, p_2);
        }

        internal void newMessage(d_f_klient d_f_klient, MessageData komunikat)
        {
            if (!d_f_klient.okna.ContainsKey(komunikat.nadawca))
                d_f_klient.Invoke((MethodInvoker)delegate() { tworzOkno(d_f_klient, komunikat.nadawca); });
            d_f_klient.Invoke((MethodInvoker)delegate()
            {
                if (!d_f_klient.okna[komunikat.nadawca].Focused)
                    FlashWindow(d_f_klient.okna[komunikat.nadawca].Handle, true);
            });
            WpiszTekst(d_f_klient.okna[komunikat.nadawca].f_wb_oknorozmowy, komunikat.nadawca, komunikat.tresc);
        }

        internal void tworzOkno(d_f_klient d_f_klient, string p)
        {
            oknoRozmowy okno = new oknoRozmowy(p, d_f_klient);
            d_f_klient.okna.Add(p, okno);
            okno.DesktopLocation = Lokacja(okno.Size);
            okno.Name = p;
            okno.Parent = d_f_klient.Parent;
            okno.Show();
        }
    }
}
