using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace IM
{
    public partial class ManageUsers : Form
    {
        private IMClass kk = new IMClass();
        private string lokalizacja;

        public ManageUsers(string lokalizacja)
        {
            InitializeComponent();
            this.lokalizacja = lokalizacja;
            Odczyt();
        }

        private void Odczyt()
        {
            if (File.Exists(lokalizacja))
            {
                ArrayList temp = new ArrayList();
                XmlDocument doc = new XmlDocument();
                doc.Load(lokalizacja);
                XmlNodeList matches = doc.SelectNodes("/USERS/user");
                foreach(XmlNode node in matches)
                {
                    foreach (XmlNode node2 in node)
                    {
                        temp.Add(node2.InnerText);
                    }
                    object[] obj = new object[] { temp[2], temp[3], temp[0], temp[1] };
                    temp.Clear();
                    d_dgv_tabela.Rows.Add(obj);
                }
            }
        }

        private void d_b_dodaj_Click(object sender, EventArgs e)
        {
            d_dgv_tabela.Rows.Add();
        }

        private void d_b_usun_Click(object sender, EventArgs e)
        {
            d_dgv_tabela.Rows.RemoveAt(d_dgv_tabela.CurrentCell.RowIndex);
        }

        private void d_b_zapisz_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode usersNode = doc.CreateElement("USERS");
            doc.AppendChild(usersNode);
            foreach (DataGridViewRow row in d_dgv_tabela.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null && row.Cells[0].Value.ToString().Trim() != "" && row.Cells[1].Value.ToString().Trim() != "" && row.Cells[2].Value.ToString().Trim() != "" && row.Cells[3].Value.ToString().Trim() != "")
                {
                    XmlNode userNode = doc.CreateElement("user");
                    XmlAttribute userAttribute = doc.CreateAttribute("login");
                    userAttribute.Value = (string)row.Cells[2].Value;
                    userNode.Attributes.Append(userAttribute);
                    usersNode.AppendChild(userNode);

                    XmlNode loginNode = doc.CreateElement("login");
                    loginNode.AppendChild(doc.CreateTextNode((string)row.Cells[2].Value));
                    userNode.AppendChild(loginNode);
                    XmlNode passNode = doc.CreateElement("pass");
                    if (row.Cells[3].Tag != null)
                        passNode.AppendChild(doc.CreateTextNode(kk.Hash((string)row.Cells[3].Value)));
                    else
                        passNode.AppendChild(doc.CreateTextNode((string)row.Cells[3].Value));
                    userNode.AppendChild(passNode);
                    XmlNode imie = doc.CreateElement("firstname");
                    imie.AppendChild(doc.CreateTextNode((string)row.Cells[0].Value));
                    userNode.AppendChild(imie);
                    XmlNode nazwisko = doc.CreateElement("lastname");
                    nazwisko.AppendChild(doc.CreateTextNode((string)row.Cells[1].Value));
                    userNode.AppendChild(nazwisko);
                }
            }
            doc.Save(lokalizacja);
            this.Close();
        }

        private void d_dgv_tabela_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (d_dgv_tabela.Columns[e.ColumnIndex].Name == "pass" && e.Value != null)
            {
                d_dgv_tabela.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private void d_dgv_tabela_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (d_dgv_tabela.Columns[e.ColumnIndex].Name == "pass")
            {
                d_dgv_tabela.Rows[e.RowIndex].Cells[3].Tag = true;
            }
        }

        private void d_dgv_tabela_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (d_dgv_tabela.Columns[e.ColumnIndex].Name == "login")
            {
                for (int i=0; i<d_dgv_tabela.Rows.Count; i++)
                {
                    if (i == e.RowIndex)
                        continue;
                    else
                    {
                        if (d_dgv_tabela[e.ColumnIndex, i].Value.ToString() == d_dgv_tabela[e.ColumnIndex, e.RowIndex].Value.ToString())
                        {
                            MessageBox.Show("Błąd! Użytkownik o podanym loginie istnieje", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            d_dgv_tabela[e.ColumnIndex, e.RowIndex].Value = null;
                            break;
                        }
                    }
                }
            }
        }
    }
}
