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
    public partial class EditVoranmeldungen : Form
    {
        public DataGridViewRow selectedRow;

        public EditVoranmeldungen(DataGridViewRow selectedRow)
        {
            InitializeComponent();
            this.selectedRow = selectedRow;
            loadXml();
        }
        private void loadXml()
        {
            txtDatum.Text = selectedRow.Cells["Datum"].Value.ToString();
            txtTurnier.Text = selectedRow.Cells["Turnier"].Value.ToString();
            txtOrt.Text = selectedRow.Cells["Ort"].Value.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            selectedRow.Cells["Datum"].Value = txtDatum.Text;
            selectedRow.Cells["Turnier"].Value = txtTurnier.Text;
            selectedRow.Cells["Ort"].Value = txtOrt.Text;
            Form1 originalForm = (Form1)Application.OpenForms["Form1"];
            originalForm.UpdateDataGridViewRow(selectedRow);
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
