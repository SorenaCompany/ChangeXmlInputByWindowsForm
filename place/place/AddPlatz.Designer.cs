namespace place
{
    partial class AddPlatz
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.lblPlatz = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPlatz = new System.Windows.Forms.TextBox();
            this.lblPlayerFamily = new System.Windows.Forms.Label();
            this.txtPlayerFamily = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtPlayerName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPlatz, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPlayerName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPlatz, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPlayerFamily, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPlayerFamily, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(337, 127);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlayerName.Location = new System.Drawing.Point(102, 29);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(232, 20);
            this.txtPlayerName.TabIndex = 5;
            // 
            // lblPlatz
            // 
            this.lblPlatz.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPlatz.AutoSize = true;
            this.lblPlatz.Location = new System.Drawing.Point(3, 6);
            this.lblPlatz.Name = "lblPlatz";
            this.lblPlatz.Size = new System.Drawing.Size(30, 13);
            this.lblPlatz.TabIndex = 0;
            this.lblPlatz.Text = "Platz";
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(3, 32);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(64, 13);
            this.lblPlayerName.TabIndex = 1;
            this.lblPlayerName.Text = "PlayerName";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExit.Location = new System.Drawing.Point(102, 81);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(93, 36);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.Location = new System.Drawing.Point(3, 81);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 36);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPlatz
            // 
            this.txtPlatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlatz.Location = new System.Drawing.Point(102, 3);
            this.txtPlatz.Name = "txtPlatz";
            this.txtPlatz.Size = new System.Drawing.Size(232, 20);
            this.txtPlatz.TabIndex = 4;
            // 
            // lblPlayerFamily
            // 
            this.lblPlayerFamily.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPlayerFamily.AutoSize = true;
            this.lblPlayerFamily.Location = new System.Drawing.Point(3, 58);
            this.lblPlayerFamily.Name = "lblPlayerFamily";
            this.lblPlayerFamily.Size = new System.Drawing.Size(65, 13);
            this.lblPlayerFamily.TabIndex = 6;
            this.lblPlayerFamily.Text = "PlayerFamily";
            // 
            // txtPlayerFamily
            // 
            this.txtPlayerFamily.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlayerFamily.Location = new System.Drawing.Point(102, 55);
            this.txtPlayerFamily.Name = "txtPlayerFamily";
            this.txtPlayerFamily.Size = new System.Drawing.Size(232, 20);
            this.txtPlayerFamily.TabIndex = 7;
            // 
            // AddPlatz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 146);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddPlatz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddPlatz";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label lblPlatz;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPlatz;
        private System.Windows.Forms.Label lblPlayerFamily;
        private System.Windows.Forms.TextBox txtPlayerFamily;
    }
}