namespace place
{
    partial class EditSelectedRow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPos = new System.Windows.Forms.Label();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblDisziplin = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDisziplinChanged = new System.Windows.Forms.Label();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPos.Location = new System.Drawing.Point(22, 21);
            this.lblPos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(57, 24);
            this.lblPos.TabIndex = 0;
            this.lblPos.Text = "Pos: ";
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(128, 27);
            this.txtPos.Margin = new System.Windows.Forms.Padding(2);
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(151, 20);
            this.txtPos.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(128, 73);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(151, 20);
            this.txtFirstName.TabIndex = 3;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(22, 67);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(111, 24);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "FirstName:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(128, 118);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(2);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(151, 20);
            this.txtLastName.TabIndex = 5;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(22, 112);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(108, 24);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "LastName:";
            // 
            // lblDisziplin
            // 
            this.lblDisziplin.AutoSize = true;
            this.lblDisziplin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisziplin.Location = new System.Drawing.Point(22, 157);
            this.lblDisziplin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisziplin.Name = "lblDisziplin";
            this.lblDisziplin.Size = new System.Drawing.Size(94, 24);
            this.lblDisziplin.TabIndex = 6;
            this.lblDisziplin.Text = "Disziplin:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(-6, 378);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 37);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(104, 378);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 37);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblDisziplinChanged
            // 
            this.lblDisziplinChanged.AutoSize = true;
            this.lblDisziplinChanged.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisziplinChanged.ForeColor = System.Drawing.Color.Red;
            this.lblDisziplinChanged.Location = new System.Drawing.Point(9, 199);
            this.lblDisziplinChanged.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisziplinChanged.Name = "lblDisziplinChanged";
            this.lblDisziplinChanged.Size = new System.Drawing.Size(0, 17);
            this.lblDisziplinChanged.TabIndex = 10;
            // 
            // checkedListBox
            // 
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(128, 157);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox.TabIndex = 11;
            // 
            // EditSelectedRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 471);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.lblDisziplinChanged);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDisziplin);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtPos);
            this.Controls.Add(this.lblPos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditSelectedRow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditSelectedRow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.TextBox txtPos;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblDisziplin;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblDisziplinChanged;
        private System.Windows.Forms.CheckedListBox checkedListBox;
    }
}