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
    public partial class FrmMain : Form
    {
        private XmlDocument ReturnedObject;
        XmlDocument xmlDoc = new XmlDocument();
        private DataGridView changeddataGridView = new DataGridView();
        private bool displayPlatzTable;

        private int rowIndex4Change;

        public FrmMain()
        {
            InitializeComponent();
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnShowDetails.Enabled = false;
        }

        private void loadXml()
        {
            XmlNodeList VoranmeldungenNode = xmlDoc.SelectNodes("//Voranmeldungen");
            if (VoranmeldungenNode.Count>0)
            {
                #region Make Voranmeldungen Data Table

                DataTable dt = new DataTable();
                dt.Columns.Add("Datum");
                dt.Columns.Add("Turnier");
                dt.Columns.Add("Ort");

                // Get the "Voranmeldungen" element

                foreach (XmlNode node in VoranmeldungenNode)
                {
                    DataRow newRow = dt.NewRow();
                    // Access the attributes of each "Voranmeldungen" node as needed
                    newRow["Datum"] = node.Attributes["Turnierstart"].Value;
                    newRow["Turnier"] = node.Attributes["Name"].Value;
                    newRow["Ort"] = node.Attributes["Ort"].Value;
                    if (node.Attributes["Turnierstart"] != null)
                        dt.Rows.Add(newRow);
                }

                dataGridView1.DataSource = dt;

                btnEdit.Enabled = true;
                btnShowDetails.Enabled = true;
                btnSave.Enabled = true;
                #endregion
            }
            else
            {
                XmlNodeList disziplinNode = xmlDoc.SelectNodes("//disziplin/meldung");

                #region Make Disziplin Data Table

                DataTable disziplinDT = new DataTable();
                disziplinDT.Columns.Add("Platz");
                disziplinDT.Columns.Add("Player");

                // Get the "Voranmeldungen" element

                foreach (XmlNode node in disziplinNode)
                {
                    DataRow newRow = disziplinDT.NewRow();
                    // Access the attributes of each "Voranmeldungen" node as needed
                    newRow["Platz"] = node.Attributes["platz"].Value;
                    newRow["Player"] = node.Attributes["name"].Value;
                    if (node.Attributes["platz"] != null)
                        disziplinDT.Rows.Add(newRow);
                }

                dataGridView1.DataSource = disziplinDT;
                btnEdit.Enabled = true;
                btnSave.Enabled = true;
                displayPlatzTable = true;

                
                #endregion
            }

        }

        private void sortDataGridView()
        {
            // Sort the DataGridView by the "platz" column in ascending order
            dataGridView1.Sort(dataGridView1.Columns["platz"], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(xmlDoc);
            editForm.ShowDialog();
            editForm.FormClosed += EditForm_FormClosed;
        }
        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            EditForm editForm = (EditForm)sender;
            ReturnedObject = editForm.ReturnedObject;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ReturnedObject==null)
            {
                ReturnedObject = xmlDoc;
            }
            string Turnierstart=string.Empty;
            string Name= string.Empty;
            string Ort=string.Empty;
            DataTable dt = dataGridView1.DataSource as DataTable;
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                     Turnierstart = row["Datum"].ToString();
                     Name = row["Turnier"].ToString();
                     Ort = row["Ort"].ToString();
                }
            }
            XmlNode voranmeldungenNode = ReturnedObject.SelectSingleNode("/root/Voranmeldungen");

            if (voranmeldungenNode!=null)
            {
                voranmeldungenNode.Attributes["Turnierstart"].Value = Turnierstart;
                voranmeldungenNode.Attributes["Name"].Value = Name;
                voranmeldungenNode.Attributes["Ort"].Value = Ort;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog.Title = "Save XML File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                string filePath = saveFileDialog.FileName;
                ReturnedObject.Save(filePath);
                MessageBox.Show("The file has been saved successfully.");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the initial directory and filter for the file dialog
            openFileDialog.InitialDirectory = "C:/Users/Mohammad/Desktop";
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";

            // Show the file dialog and check if the user clicked the OK button
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Load the XML file using the selected file path
                xmlDoc.Load(filePath);
                loadXml();
             

                // Process the XML file as needed
                // ...
            }
        }

        private void btnEditRow_Click(object sender, EventArgs e)
        {
            // Get the selected row
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            rowIndex4Change = selectedRow.Index;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (displayPlatzTable)
                {
                    new EditPlatz(selectedRow).ShowDialog();
                    sortDataGridView();
                }
                else
                {
                    new EditVoranmeldungen(selectedRow).ShowDialog();
                    // Access the values of the selected row
                }
            }
            else
            {
                MessageBox.Show("Please Select just one Row..");
            }
        }
        // Create a public method to receive the modified data
        public void UpdateDataGridViewRow(DataGridViewRow changedRow)
        {
            DataTable dataTable = (DataTable)dataGridView1.DataSource;
            DataRowCollection rows = dataTable.Rows;
            DataRow row = rows[rowIndex4Change];
            if (displayPlatzTable)
            {
                // Update the data in the underlying data source
                // Assuming you are using a DataTable
                row["Platz"] = changedRow.Cells["Platz"].Value;
                row["player"] = changedRow.Cells["player"].Value;
                for (int i = 0; i < rows.Count; i++)
                {
                  var x=  rows[i]["platz"];
                }
            }
            else
            {
                // Update the data in the underlying data source
                // Assuming you are using a DataTable
                row["Datum"] = changedRow.Cells["Datum"].Value;
                row["Turnier"] = changedRow.Cells["Turnier"].Value;
                row["Ort"] = changedRow.Cells["Ort"].Value;
            }
            
            // Refresh the specific row in the DataGridView
            dataGridView1.Refresh();
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            changeddataGridView = (DataGridView)sender;
        }

        
    }
}
