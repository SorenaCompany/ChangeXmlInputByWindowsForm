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

        public EditForm(XmlDocument xmlDoc)
        {
            InitializeComponent();
            this.xmlDoc = xmlDoc;
            XmlNodeList Disziplins = xmlDoc.SelectNodes("//Disziplin[Teams/Team[count(.) >=1]]");
            int disziplinsCount = xmlDoc.SelectNodes("//Disziplin").Count;
            int count = Disziplins.Count;
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

        private void makeTabPage(List<XmlNodeList> DisziplinsLists)
        {
            for (int j = 0; j < DisziplinsLists.Count; j++)
            {
                TabPage tabPage = new TabPage();
                DataGridView dataGridView = new DataGridView();
                dataGridView.ColumnHeadersHeightSizeMode =
                    System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataGridView.Location = new System.Drawing.Point(0, 0);
                dataGridView.Name = $"dataGridView{j}";
                dataGridView.SelectionChanged += DataGridView_SelectionChanged;
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
                tabPage.Text = $"tabpage{j}";
                tabPage.UseVisualStyleBackColor = true;
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

        private void btnEditRow_Click(object sender, EventArgs e)
        {
          
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                rowIndex4Change = selectedRow.Index;
                new EditSelectedRow(selectedRow).ShowDialog();
                // Access the values of the selected row
            }
        }
        // Create a public method to receive the modified data
        public void UpdateDataGridViewRow(DataGridViewRow changedRow)
        {
            // Update the data in the underlying data source
            // Assuming you are using a DataTable
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
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView = (DataGridView) sender;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet...");
        }
    }
}