using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace place
{
    public partial class EditSelectedRow : Form
    {
        private bool AllowAdd ;//if true it means you want to AllowAdd 
        public DataGridViewRow selectedRow;
        private bool shouldHandleTextChanged = true;
        private XmlDocument xmlDoc;
        private HashSet<string> desiredValue=new HashSet<string>();//desiredValue for fill checked Box based on number of player items on each tab

        public EditSelectedRow(DataGridViewRow selectedRow,XmlDocument xmlDoc,List<string> checkedListbox)//invoke From Edit button
        {
            InitializeComponent();
            this.selectedRow = selectedRow;
            this.xmlDoc = xmlDoc;
            desiredValue.Add(selectedRow.Cells["Disziplin"].Value.ToString());
            XmlNodeList Disziplins = xmlDoc.SelectNodes("//Disziplin[Teams/Team[count(.) >=1]]");
            string[] FullName = selectedRow.Cells["Team"].Value.ToString().Split(' ');
            foreach (XmlNode disziplinNode in Disziplins)
            {
                XmlNodeList teamNodes = disziplinNode.SelectNodes("Teams/Team");
                foreach (XmlNode teamNode in teamNodes)
                {
                    XmlNode spielerNode = teamNode.SelectSingleNode("Spieler/Spieler");
                    if (spielerNode != null && FullName[0].Equals(spielerNode.Attributes["Vorname"].Value) && FullName[1].Equals(spielerNode.Attributes["Nachname"].Value))
                    {
                        String str = disziplinNode.Attributes["BezeichnungLang"].Value;
                        //checkedListbox.Add(str);
                        desiredValue.Add(str);
                    }

                   
                }
               
            }
            loadXml(checkedListbox);

        }

        public EditSelectedRow(XmlDocument xmlDoc,bool flag,List<string> checkedListBoxItem)//invoke From Add button
        {
            InitializeComponent();
            checkedListBox.CheckOnClick = true;
            this.xmlDoc = xmlDoc;
            AllowAdd = flag;
            txtPos.Enabled = !AllowAdd;
            fillCheckedListBox(checkedListBoxItem);
        }

        private void fillCheckedListBox(List<string> dataList)
        {
            XmlNodeList bezeichnungNodes = xmlDoc.SelectNodes("//Disziplin");
            foreach (string data in dataList)
            {
                // Add value to the CheckedListBox
                checkedListBox.Items.Add(data);
            }
        }

        private int calculateNewTeamNr(XmlNode disziplinNode)
        {
            XmlNodeList teamNodes = disziplinNode.SelectNodes("Teams/Team");

            // Create a List<int> to store the TeamNr attribute values
            List<int> teamNumbers = new List<int>();
            int teamNr;
            // Iterate over the Team nodes and save the TeamNr attribute values
            foreach (XmlNode teamNode in teamNodes)
            {
                if (int.TryParse(teamNode.Attributes["TeamNr"].Value, out  teamNr))
                {
                    teamNumbers.Add(teamNr);
                }
            }

            return teamNumbers.Count > 0 ? teamNumbers.Max() + 1 : 1;
        }

        private void AddTeamElement()
        {
           
            // Assuming you have a CheckedListBox named checkedListBox with the desired values

            // Get the selected items from the CheckedListBox
            var selectedItems = checkedListBox.CheckedItems.Cast<string>();

            foreach (var selectedItem in selectedItems)
            {
                XmlNode disziplinNode = xmlDoc.SelectSingleNode($"//Disziplin[@BezeichnungLang='{selectedItem}']");


                XmlNode currentTeamNode = disziplinNode.SelectSingleNode(
                    $"Teams/Team[@TeamID='{selectedRow.Cells["TeamID"].Value}']");
                if (currentTeamNode == null)
                {


                    // Assuming you have the team data available
                    string teamID = new Random().Next(10, 100).ToString();
                    string teamNr = calculateNewTeamNr(disziplinNode).ToString();
                    string disziplinID = disziplinNode.Attributes["ID"].Value;
                    string einzel = "";
                    string kategorie = "";
                    string vorangemeldet = "";
                    string gesetzt = "";
                    string angemeldet = "";
                    string zeitpunktAnmeldung = "";
                    string voranmeldungNr = "";
                    string topSeed = "";
                    string teamIDGV = "";
                    string tischtyp = "";
                    string mannschaft = "";
                    string mannschaftsname = "";
                    string dypGruppe = "";
                    string bezahlt = "";
                    string anzSpielerNr = "";
                    string anzSpielerVorname = "";
                    string anzSpielerKurz = "";

                    // Find the <Disziplin> element with the matching BezeichnungLang value

                    if (disziplinNode != null)
                    {
                        XmlNode teamsNode = disziplinNode.SelectSingleNode("Teams");

                        if (teamsNode != null && !teamsNode.HasChildNodes)
                        {
                            disziplinNode.RemoveChild(teamsNode);
                            // Create the <Teams> element if it doesn't exist
                            teamsNode = xmlDoc.CreateElement("Teams");
                            disziplinNode.AppendChild(teamsNode);
                        }
                        // Create the <Team> element
                        //   XmlElement teamsElement = xmlDoc.CreateElement("Teams");

                        XmlElement teamElement = xmlDoc.CreateElement("Team");
                        teamElement.SetAttribute("TeamID", teamID);
                        teamElement.SetAttribute("TeamNr", teamNr);
                        teamElement.SetAttribute("DisziplinID", disziplinID);
                        teamElement.SetAttribute("Einzel", einzel);
                        teamElement.SetAttribute("Kategorie", kategorie);
                        teamElement.SetAttribute("Vorangemeldet", vorangemeldet);
                        teamElement.SetAttribute("Gesetzt", gesetzt);
                        teamElement.SetAttribute("Angemeldet", angemeldet);
                        teamElement.SetAttribute("Zeitpunkt_Anmeldung", zeitpunktAnmeldung);
                        teamElement.SetAttribute("VoranmeldungNr", voranmeldungNr);
                        teamElement.SetAttribute("TopSeed", topSeed);
                        teamElement.SetAttribute("TeamID_GV", teamIDGV);
                        teamElement.SetAttribute("Tischtyp", tischtyp);
                        teamElement.SetAttribute("Mannschaft", mannschaft);
                        teamElement.SetAttribute("Mannschaftsname", mannschaftsname);
                        teamElement.SetAttribute("DYPGruppe", dypGruppe);
                        teamElement.SetAttribute("Bezahlt", bezahlt);
                        teamElement.SetAttribute("AnzSpielerNr", anzSpielerNr);
                        teamElement.SetAttribute("AnzSpielerVorname", anzSpielerVorname);
                        teamElement.SetAttribute("AnzSpielerKurz", anzSpielerKurz);

                        XmlElement ParentSpieler = xmlDoc.CreateElement("Spieler");

                        // Create the <Spieler> element
                        XmlElement childSpieler = xmlDoc.CreateElement("Spieler");
                        childSpieler.SetAttribute("TiFuID", new Random().Next(1000, 9999).ToString());
                        childSpieler.SetAttribute("Vorname", txtFirstName.Text);
                        childSpieler.SetAttribute("Nachname", txtLastName.Text);
                        childSpieler.SetAttribute("Spielernummer", "");
                        childSpieler.SetAttribute("Lizenznummer", "");
                        childSpieler.SetAttribute("Geschlecht", "");
                        childSpieler.SetAttribute("Kategorie", "");
                        childSpieler.SetAttribute("Verein", "");
                        childSpieler.SetAttribute("Vereinssitz", "");
                        childSpieler.SetAttribute("Organisation", "");
                        childSpieler.SetAttribute("Mitgliedsstatus", "");
                        childSpieler.SetAttribute("Geburtsjahr", "");
                        childSpieler.SetAttribute("Angepasst", "");

                        //teamsElement.AppendChild(teamElement);
                        // Append the <Spieler> element to the <Team> element
                        teamElement.AppendChild(ParentSpieler);
                        ParentSpieler.AppendChild(childSpieler);
                        teamsNode.AppendChild(teamElement);
                        // Append the <Team> element to the <Disziplin> element
                        // disziplinNode.AppendChild(teamElement);
                    }
                }

                //// Save the modifiedXmlDocument back to the file
                //xmlDoc.Save("C:/Users/Mohammad/Desktop/newXml123.xml");
                //MessageBox.Show("successfull");
            }
        }


        private void loadXml(List<string> lists)
        {
            txtPos.Text = selectedRow.Cells["Pos"].Value.ToString();
            string[] FullName = selectedRow.Cells["Team"].Value.ToString().Split(' ');
            txtFirstName.Text = FullName[0];
            txtLastName.Text = FullName[1];
            checkedListBox.Items.AddRange(lists.ToArray());

            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                foreach (string d in desiredValue)
                {
                    if (checkedListBox.Items[i].ToString() == d)
                    {
                        checkedListBox.SetItemChecked(i, true);
                       // break;
                    }
                }
               
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EditForm originalForm = (EditForm)Application.OpenForms["EditForm"];
            if (!AllowAdd)
            {
                selectedRow.Cells["Pos"].Value = txtPos.Text;
                selectedRow.Cells["Team"].Value = txtFirstName.Text + " " + txtLastName.Text;
               // selectedRow.Cells["Disziplin"].Value = txtDisziplin.Text;
               AddTeamElement();
                originalForm.UpdateDataGridViewRow(selectedRow, xmlDoc);
                Close();
            }
            else
            {
                AddTeamElement();
                this.Close();
                originalForm.ReloadDataGridViewAfterAddSpieler(xmlDoc);
            }
        }
        private void txtDisziplin_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblDisziplinChanged.Text = "All Disziplin Will be Changed";

        }
    }
}
