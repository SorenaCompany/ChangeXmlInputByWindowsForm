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

        private int rowIndex4Change;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void loadXml()
        {
            #region Team Table

            DataTable dt = new DataTable();
            dt.Columns.Add("Datum");
            dt.Columns.Add("Turnier");
            dt.Columns.Add("Ort");

            // Get the "Voranmeldungen" element
            XmlNodeList VoranmeldungenNodes = xmlDoc.SelectNodes("//Voranmeldungen");

            foreach (XmlNode node in VoranmeldungenNodes)
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

            // Set the AutoSizeMode property of each column to AllCells
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            #endregion
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
                MessageBox.Show("File had saved successfully");
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

            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                rowIndex4Change = selectedRow.Index;
                new EditVoranmeldungen(selectedRow).ShowDialog();
                // Access the values of the selected row
            }
        }
        // Create a public method to receive the modified data
        public void UpdateDataGridViewRow(DataGridViewRow changedRow)
        {
            // Update the data in the underlying data source
            // Assuming you are using a DataTable
            DataTable dataTable = (DataTable)dataGridView1.DataSource;
            DataRowCollection rows = dataTable.Rows;
            DataRow row = rows[rowIndex4Change];
            row["Datum"] = changedRow.Cells["Datum"].Value;
            row["Turnier"] = changedRow.Cells["Turnier"].Value;
            row["Ort"] = changedRow.Cells["Ort"].Value;

            // Refresh the specific row in the DataGridView
            dataGridView1.Refresh();
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            changeddataGridView = (DataGridView)sender;
        }

        
    }
}
