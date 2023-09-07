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
    public partial class EditPlatz : Form
    {
        public DataGridViewRow selectedRow;
        private XmlDocument ReturnObject;

        public EditPlatz(DataGridViewRow selectedRow) //invoke from Edit Button
        {
            InitializeComponent();
            this.selectedRow = selectedRow;
            loadData();
        }

        private void loadData()
        {
            txtPlatz.Text = selectedRow.Cells["Platz"].Value.ToString();
            txtPlayer.Text = selectedRow.Cells["player"].Value.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            selectedRow.Cells["Platz"].Value = txtPlatz.Text;
            selectedRow.Cells["player"].Value = txtPlayer.Text;
            FrmMain originalForm = (FrmMain) Application.OpenForms["FrmMain"];
            originalForm.UpdateDataGridViewRow(selectedRow);
            Close();
        }
    }
}
