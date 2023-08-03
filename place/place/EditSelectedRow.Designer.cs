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
            this.txtDisziplin = new System.Windows.Forms.TextBox();
            this.lblDisziplin = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDisziplinChanged = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPos.Location = new System.Drawing.Point(30, 26);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(72, 29);
            this.lblPos.TabIndex = 0;
            this.lblPos.Text = "Pos: ";
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(170, 33);
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(200, 22);
            this.txtPos.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(170, 90);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 22);
            this.txtFirstName.TabIndex = 3;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(30, 83);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(141, 29);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "FirstName:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(170, 145);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 22);
            this.txtLastName.TabIndex = 5;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(30, 138);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(137, 29);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "LastName:";
            // 
            // txtDisziplin
            // 
            this.txtDisziplin.Location = new System.Drawing.Point(170, 200);
            this.txtDisziplin.Name = "txtDisziplin";
            this.txtDisziplin.Size = new System.Drawing.Size(200, 22);
            this.txtDisziplin.TabIndex = 7;
            this.txtDisziplin.TextChanged += new System.EventHandler(this.txtDisziplin_TextChanged);
            this.txtDisziplin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDisziplin_KeyPress);
            // 
            // lblDisziplin
            // 
            this.lblDisziplin.AutoSize = true;
            this.lblDisziplin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisziplin.Location = new System.Drawing.Point(30, 193);
            this.lblDisziplin.Name = "lblDisziplin";
            this.lblDisziplin.Size = new System.Drawing.Size(120, 29);
            this.lblDisziplin.TabIndex = 6;
            this.lblDisziplin.Text = "Disziplin:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 313);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 45);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(131, 313);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(113, 45);
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
            this.lblDisziplinChanged.Location = new System.Drawing.Point(12, 245);
            this.lblDisziplinChanged.Name = "lblDisziplinChanged";
            this.lblDisziplinChanged.Size = new System.Drawing.Size(0, 20);
            this.lblDisziplinChanged.TabIndex = 10;
            // 
            // EditSelectedRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 370);
            this.Controls.Add(this.lblDisziplinChanged);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDisziplin);
            this.Controls.Add(this.lblDisziplin);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtPos);
            this.Controls.Add(this.lblPos);
            this.Name = "EditSelectedRow";
            this.Text = "EditSelectedRow";
            this.Load += new System.EventHandler(this.EditSelectedRow_Load);
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
        private System.Windows.Forms.TextBox txtDisziplin;
        private System.Windows.Forms.Label lblDisziplin;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblDisziplinChanged;
    }
}