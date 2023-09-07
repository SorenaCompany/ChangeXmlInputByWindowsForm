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
    public partial class EditForm : Form
    {
        public XmlDocument xmlDoc;
        public XmlDocument ReturnedObject;
        private List<XmlNodeList> DisziplinsLists;
        private DataGridView dataGridView = new DataGridView();
        private int rowIndex4Change;
        private string filePath;
        private TabPage previousTabPage; // Store the previously selected tab page

        public EditForm(XmlDocument xmlDoc, string filePath)
        {
            InitializeComponent();
            this.xmlDoc = xmlDoc;
            XmlNodeList Disziplins = xmlDoc.SelectNodes("//Disziplin[Teams/Team[count(.) >=1]]");
            int disziplinsCount = xmlDoc.SelectNodes("//Disziplin").Count;
            int count = Disziplins.Count;
            this.filePath = filePath;
            DisziplinsLists = disLists();
            makeTabPage(DisziplinsLists);
        }

        private List<XmlNodeList> disLists()
        {
            int disziplinsCount = xmlDoc.SelectNodes("//Disziplin").Count;
            List<XmlNodeList> lists = new List<XmlNodeList>();
            for (int i = 1; i <= disziplinsCount; i++)
            {
                XmlNodeList Disziplins = xmlDoc.SelectNodes($"//Disziplin[{i}]/Teams/Team[count(.) >=1]");

                if (Disziplins.Count > 0)
                {
                    lists.Add(Disziplins);
                }
            }

            return lists;
        }


        private void RemoveTabPagesWithDataGridView()
        {
            // Create a list to store the TabPages to be removed
            List<TabPage> pagesToRemove = new List<TabPage>();

            // Iterate through each TabPage in the TabControl
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                // Check if the TabPage contains a DataGridView control
                foreach (Control control in tabPage.Controls)
                {
                    if (control is DataGridView)
                    {
                        // Add the TabPage to the list of pages to be removed
                        pagesToRemove.Add(tabPage);
                        break; // No need to continue checking other controls in the TabPage
                    }
                }
            }

            // Remove the TabPages from the TabControl
            foreach (TabPage tabPage in pagesToRemove)
            {
                tabControl1.TabPages.Remove(tabPage);
            }
        }

        private void makeTabPage(List<XmlNodeList> DisziplinsLists)
        {
            RemoveTabPagesWithDataGridView();
            for (int j = 0; j < DisziplinsLists.Count; j++)
            {
                TabPage tabPage = new TabPage();
                DataGridView dataGridView = new DataGridView();
                dataGridView.ColumnHeadersHeightSizeMode =
                    System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataGridView.Location = new System.Drawing.Point(0, 0);
                dataGridView.Name = $"dataGridView{j}";
                dataGridView.SelectionChanged += DataGridView_SelectionChanged;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView.AllowUserToAddRows = false;
                dataGridView.Dock = DockStyle.Fill;
                dataGridView.ReadOnly = true;
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView.Size = new System.Drawing.Size(511, 240);
                dataGridView.TabIndex = j;
                tabPage.Controls.Add(dataGridView);
                tabPage.Location = new System.Drawing.Point(4, 22);
                tabPage.Name = $"tabpage{j}";
                tabPage.Padding = new System.Windows.Forms.Padding(3);
                tabPage.Size = new System.Drawing.Size(514, 246);
                tabPage.TabIndex = j;
                tabPage.UseVisualStyleBackColor = true;
                tabPage.Dock = DockStyle.Fill;
                tabControl1.Dock = DockStyle.Fill;
                tabControl1.TabPages.Add(tabPage);

                // Create a DataTable object for the current DataGridView control
                DataTable dt = new DataTable();
                dt.Columns.Add("Pos");
                dt.Columns.Add("Team");
                dt.Columns.Add("Disziplin");

                dt.Columns.Add("TeamID");
                dt.Columns.Add("DisziplinID");


                // Fill the DataTable with data for the current tab page
                foreach (XmlNode teamNode in DisziplinsLists[j])
                {
                    tabPage.Text = String.Format("Voranmeldungen {0}",
                        teamNode.ParentNode.ParentNode.Attributes["BezeichnungLang"].Value);

                    DataRow newRow = dt.NewRow();
                    newRow["Pos"] = teamNode.Attributes["TeamNr"].Value;
                    newRow["Disziplin"] = teamNode.ParentNode.ParentNode.Attributes["BezeichnungLang"].Value;
                    XmlNode spielerNode = teamNode.SelectSingleNode("Spieler/Spieler");
                    if (spielerNode != null)
                    {
                        newRow["Team"] = spielerNode.Attributes["Vorname"].Value + " " +
                                         spielerNode.Attributes["Nachname"].Value;
                    }

                    // Set the value of the TeamID column for the current row
                    newRow["TeamID"] = teamNode.Attributes["TeamID"].Value;
                    newRow["DisziplinID"] = teamNode.ParentNode.ParentNode.Attributes["ID"].Value;

                    dt.Rows.Add(newRow);
                }

                // Set the DataSource property of the current DataGridView control
                dataGridView.DataSource = dt;
                dataGridView.Columns["TeamID"].Visible = false;
                dataGridView.Columns["DisziplinID"].Visible = false;

            }
        }

        private void SaveChangesToXml_Click(object sender, EventArgs e)
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                DataGridView dataGridView = tabPage.Controls.OfType<DataGridView>().FirstOrDefault();
                if (dataGridView != null)
                {
                    DataTable dt = dataGridView.DataSource as DataTable;
                    if (dt != null)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            string teamNr = row["Pos"].ToString();
                            string disziplin = row["Disziplin"].ToString();
                            string[] fullName = row["Team"].ToString().Split(' ');
                            string teamID = row["TeamID"].ToString();
                            string disziplinID = row["DisziplinID"].ToString();


                            XmlNode teamNode = xmlDoc.SelectSingleNode(
                                $"//Disziplin[@ID='{disziplinID}']/Teams/Team[@TeamID='{teamID}']");
                            if (teamNode != null)
                            {
                                teamNode.Attributes["TeamNr"].Value = teamNr;
                                //  teamNode.ParentNode.ParentNode.Attributes["BezeichnungLang"].Value=disziplin;
                                XmlNode parent = teamNode?.ParentNode?.ParentNode;
                                if (parent != null && parent.Attributes["BezeichnungLang"] != null)
                                {
                                    parent.Attributes["BezeichnungLang"].Value = disziplin;
                                }

                                XmlNode spielerNode = teamNode.SelectSingleNode("Spieler/Spieler");
                                if (spielerNode != null)
                                {
                                    spielerNode.Attributes["Vorname"].Value = fullName[0];
                                    spielerNode.Attributes["Nachname"].Value = fullName[1];

                                }
                            }
                        }
                    }
                }
            }

            ReturnedObject = xmlDoc;
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Create a public method to receive the modified data
        public void UpdateDataGridViewRow(DataGridViewRow changedRow,XmlDocument xmlDoc)
        {
            // Update the data in the underlying data source
            // Assuming you are using a DataTable
            this.xmlDoc = xmlDoc;
            DataTable dataTable = (DataTable) dataGridView.DataSource;
            DataRowCollection rows = dataTable.Rows;
            DataRow row = rows[rowIndex4Change];
            row["Pos"] = changedRow.Cells["Pos"].Value;
            row["Team"] = changedRow.Cells["Team"].Value;
            foreach (DataRow dataRow in rows)
            {
                dataRow["Disziplin"] = changedRow.Cells["Disziplin"].Value;
            }

            // Refresh the specific row in the DataGridView
            dataGridView.Refresh();
            //this.Close();
        }

        public void ReloadDataGridViewAfterAddSpieler(XmlDocument xmlDoc)
        {
           FrmMain FrmMain = (FrmMain)Application.OpenForms["FrmMain"];

            this.xmlDoc = xmlDoc;
            makeTabPage(disLists());
            this.Close();
            FrmMain.trigger_btnShowDetails_Click_Again();
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView = (DataGridView) sender;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete the player?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                string teamID = selectedRow.Cells["TeamID"].Value.ToString();
                string disziplinID = selectedRow.Cells["DisziplinID"].Value.ToString();

                string xpathExpression =
                    String.Format("//Team[@TeamID='{0}' and @DisziplinID='{1}']", teamID, disziplinID);
                int rowIndex4Delete = selectedRow.Index;
                if (ReturnedObject == null)
                {
                    ReturnedObject = xmlDoc;
                }

                XmlNode teamNode = ReturnedObject.SelectSingleNode(xpathExpression);
                if (teamNode != null)
                {
                    // Remove the Team node from its parent
                    teamNode.ParentNode.RemoveChild(teamNode);
                    if (dataGridView.Rows.Count > 0 && rowIndex4Delete >= 0 &&
                        rowIndex4Delete < dataGridView.Rows.Count)
                    {
                        dataGridView.Rows.RemoveAt(rowIndex4Delete);
                    }

                    dataGridView.Refresh();
                }
            }
        }

        private void btnEditRow_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                rowIndex4Change = selectedRow.Index;
                new AddEditSelectedRow(selectedRow, xmlDoc, fillCheckedListBox()).ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new AddEditSelectedRow(xmlDoc, true, fillCheckedListBox()).ShowDialog();
        }

        private List<string> fillCheckedListBox()
        {
            XmlNodeList bezeichnungNodes = xmlDoc.SelectNodes("//Disziplin");
            List<string> checkedListBoxItems = new List<string>();
            foreach (XmlNode node in bezeichnungNodes)
            {
                string value = node.Attributes["BezeichnungLang"].Value;
                checkedListBoxItems.Add(value);
            }

            return checkedListBoxItems;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
             dataGridView = tabControl1.SelectedTab?.Controls.OfType<DataGridView>().FirstOrDefault();

        }
    }

}