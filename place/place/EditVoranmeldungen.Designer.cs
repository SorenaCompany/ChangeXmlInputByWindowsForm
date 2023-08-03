namespace place
{
    partial class EditVoranmeldungen
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtOrt = new System.Windows.Forms.TextBox();
            this.lblOrt = new System.Windows.Forms.Label();
            this.txtTurnier = new System.Windows.Forms.TextBox();
            this.lblTurnier = new System.Windows.Forms.Label();
            this.txtDatum = new System.Windows.Forms.TextBox();
            this.lblDatum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(140, 176);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(113, 45);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 176);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 45);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtOrt
            // 
            this.txtOrt.Location = new System.Drawing.Point(152, 128);
            this.txtOrt.Name = "txtOrt";
            this.txtOrt.Size = new System.Drawing.Size(200, 22);
            this.txtOrt.TabIndex = 15;
            // 
            // lblOrt
            // 
            this.lblOrt.AutoSize = true;
            this.lblOrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrt.Location = new System.Drawing.Point(12, 121);
            this.lblOrt.Name = "lblOrt";
            this.lblOrt.Size = new System.Drawing.Size(56, 29);
            this.lblOrt.TabIndex = 14;
            this.lblOrt.Text = "Ort:";
            this.lblOrt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTurnier
            // 
            this.txtTurnier.Location = new System.Drawing.Point(152, 73);
            this.txtTurnier.Name = "txtTurnier";
            this.txtTurnier.Size = new System.Drawing.Size(200, 22);
            this.txtTurnier.TabIndex = 13;
            // 
            // lblTurnier
            // 
            this.lblTurnier.AutoSize = true;
            this.lblTurnier.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnier.Location = new System.Drawing.Point(12, 66);
            this.lblTurnier.Name = "lblTurnier";
            this.lblTurnier.Size = new System.Drawing.Size(105, 29);
            this.lblTurnier.TabIndex = 12;
            this.lblTurnier.Text = "Turnier:";
            // 
            // txtDatum
            // 
            this.txtDatum.Location = new System.Drawing.Point(152, 16);
            this.txtDatum.Name = "txtDatum";
            this.txtDatum.Size = new System.Drawing.Size(200, 22);
            this.txtDatum.TabIndex = 11;
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatum.Location = new System.Drawing.Point(12, 9);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(94, 29);
            this.lblDatum.TabIndex = 10;
            this.lblDatum.Text = "Datum:";
            // 
            // EditVoranmeldungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 246);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtOrt);
            this.Controls.Add(this.lblOrt);
            this.Controls.Add(this.txtTurnier);
            this.Controls.Add(this.lblTurnier);
            this.Controls.Add(this.txtDatum);
            this.Controls.Add(this.lblDatum);
            this.Name = "EditVoranmeldungen";
            this.Text = "EditVoranmeldungen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtOrt;
        private System.Windows.Forms.Label lblOrt;
        private System.Windows.Forms.TextBox txtTurnier;
        private System.Windows.Forms.Label lblTurnier;
        private System.Windows.Forms.TextBox txtDatum;
        private System.Windows.Forms.Label lblDatum;
    }
}