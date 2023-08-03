using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace place
{
    public partial class EditSelectedRow : Form
    {
        public DataGridViewRow selectedRow;
        private bool shouldHandleTextChanged = true;

        public EditSelectedRow(DataGridViewRow selectedRow)
        {
            InitializeComponent();
            this.selectedRow = selectedRow;
            loadXml();
        }

        private void loadXml()
        {
         txtPos.Text = selectedRow.Cells["Pos"].Value.ToString();
         string[] FullName = selectedRow.Cells["Team"].Value.ToString().Split(' ');
          txtFirstName.Text = FullName[0];
          txtLastName.Text = FullName[1];
            txtDisziplin.Text = selectedRow.Cells["Disziplin"].Value.ToString();
        }

        private void EditSelectedRow_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            selectedRow.Cells["Pos"].Value = txtPos.Text;
            selectedRow.Cells["Team"].Value = txtFirstName.Text + " " + txtLastName.Text;
            selectedRow.Cells["Disziplin"].Value = txtDisziplin.Text;
            EditForm originalForm = (EditForm)Application.OpenForms["EditForm"];
            originalForm.UpdateDataGridViewRow( selectedRow);
            Close();
        }

        private void txtDisziplin_TextChanged(object sender, EventArgs e)
        {
        
            
        }

        private void txtDisziplin_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblDisziplinChanged.Text = "All Disziplin Will be Changed";

        }
    }
}
