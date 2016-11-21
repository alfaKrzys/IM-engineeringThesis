using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Forms;
using System.Xml;

namespace IM
{
    public partial class d_f_archiwum : Form
    {
        private string p, rozmowca;
        public d_f_archiwum(d_f_klient d_f_klient)
        {
            InitializeComponent();
            ustawienia konfiguracja = new ustawienia();
            p = d_f_klient.login;
            CzytUzytkownikow();
        }

        private void CzytUzytkownikow()
        {
            using (IsolatedStorageFile ISpath = IsolatedStorageFile.GetMachineStoreForAssembly())
            {
                if (ISpath.FileExists(Path.Combine("IM", "archiwum.xml")))
                {
                    using (Stream s = new IsolatedStorageFileStream(Path.Combine("IM", "archiwum.xml"), FileMode.Open, ISpath))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(s);
                        XmlNodeList nodes1 = doc.SelectNodes("/Archiwum/uzytkownik[@login=\"" + p + "\"]");
                        foreach (XmlNode node in nodes1)
                        {
                            for (int i = 0; i < node.ChildNodes.Count; i++)
                            {
                                f_lb_uzytkownik.Items.Add(node.ChildNodes[i].Attributes["login"].Value);
                            }
                        }
                    }
                }
            }
        }

        private void f_lb_uzytkownik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedItem != null)
            {
                rozmowca = ((ListBox)sender).SelectedItem.ToString();
                f_lb_data.Items.Clear();
                using (IsolatedStorageFile ISpath = IsolatedStorageFile.GetMachineStoreForAssembly())
                {
                    if (ISpath.FileExists(Path.Combine("IM", "archiwum.xml")))
                    {
                        using (Stream s = new IsolatedStorageFileStream(Path.Combine("IM", "archiwum.xml"), FileMode.Open, ISpath))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(s);
                            XmlNodeList nodes1 = doc.SelectNodes("/Archiwum/uzytkownik[@login=\"" + p + "\"]/rozmowca[@login=\"" + ((ListBox)sender).SelectedItem.ToString() + "\"]");
                            foreach (XmlNode node in nodes1)
                            {
                                for (int i = 0; i < node.ChildNodes.Count; i++)
                                {
                                    f_lb_data.Items.Add(node.ChildNodes[i].Attributes["data"].Value);
                                }
                            }
                        }
                    }
                }
                f_lb_data.Enabled = true;
            }
        }

        private void f_lb_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedItem!=null)
            {

                f_wb_rozmowa.Document.OpenNew(true);
                using (IsolatedStorageFile ISpath = IsolatedStorageFile.GetMachineStoreForAssembly())
                {
                    if (ISpath.FileExists(Path.Combine("IM", "archiwum.xml")))
                    {
                        using (Stream s = new IsolatedStorageFileStream(Path.Combine("IM", "archiwum.xml"), FileMode.Open, ISpath))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(s);
                            XmlNodeList nodes1 = doc.SelectNodes("/Archiwum/uzytkownik[@login=\"" + p + "\"]/rozmowca[@login=\"" + rozmowca + "\"]/czas[@data=\"" + ((ListBox)sender).SelectedItem.ToString() + "\"]");
                            foreach (XmlNode node in nodes1)
                            {
                                f_wb_rozmowa.Document.Write(node.InnerText);
                            }
                        }
                    }
                }
            }
        }
    }
}
