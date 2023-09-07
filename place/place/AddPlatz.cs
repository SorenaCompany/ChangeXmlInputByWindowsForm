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

namespace place
{
    public partial class AddPlatz : Form
    {
        public DataGridViewRow selectedRow;
        private XmlDocument ReturnObject;
        private bool allowAdd;
     
        public AddPlatz(XmlDocument xmlDoc)//invoke from Add Button
        {
            InitializeComponent();
            ReturnObject = xmlDoc;
            txtPlatz.Enabled = false;
            //allowAdd = true;
            XmlNodeList meldungNodes = ReturnObject.SelectNodes("//disziplin/meldung");
            txtPlatz.Text = calculateNewPlatz(meldungNodes).ToString();
            ////


            /// 
        }
        private int calculateNewPlatz(XmlNodeList meldungNodes)
        {
            // Create a List<int> to store the Platz attribute values
            List<int> platz = new List<int>();
            foreach (XmlNode meldungNode in meldungNodes)
            {
                int p = int.Parse(meldungNode.Attributes["platz"].Value);
                platz.Add(p);
            }
            return platz.Count > 0 ? platz.Max() + 1 : 1;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddNewSpieler();
        }
        private void AddNewSpieler()
        {
            XmlNode disziplin = ReturnObject.SelectSingleNode("//disziplin");
            // ReturnObject.Attributes["platz"].Value = txtPlatz.Text;
            string platz = txtPlatz.Text;
            string playerName = txtPlayerName.Text;
            string playerFamily = txtPlayerFamily.Text;
            XmlElement meldungElement = ReturnObject.CreateElement("meldung");
            meldungElement.SetAttribute("name", playerName+" "+playerFamily);
            meldungElement.SetAttribute("platz", platz);
            XmlElement spielerElement = ReturnObject.CreateElement("spieler");
            spielerElement.SetAttribute("name", playerName + " " + playerFamily);
            spielerElement.SetAttribute("vorname", playerName); 
            spielerElement.SetAttribute("nachname", playerFamily);
            spielerElement.SetAttribute("verein", "");
            spielerElement.SetAttribute("spielerpass", "");
            meldungElement.AppendChild(spielerElement);

            disziplin.AppendChild(meldungElement);

            FrmMain originalForm = (FrmMain)Application.OpenForms["FrmMain"];
            XmlNodeList meldungNodes = ReturnObject.SelectNodes("//disziplin/meldung");
            originalForm.makePlatzDataGridView(meldungNodes);
            MessageBox.Show("Platz Added Successfuly..");
            this.Close();
        }
    }
}
