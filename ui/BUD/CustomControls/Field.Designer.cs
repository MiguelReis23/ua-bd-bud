namespace BUD.CustomControls
{
    partial class Field
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.txtFree = new System.Windows.Forms.TextBox();
            this.cmbSel = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Dock = System.Windows.Forms.DockStyle.Top;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(400, 18);
            this.label.TabIndex = 2;
            this.label.Text = "Label:";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFree
            // 
            this.txtFree.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFree.Location = new System.Drawing.Point(0, 18);
            this.txtFree.Name = "txtFree";
            this.txtFree.Size = new System.Drawing.Size(400, 20);
            this.txtFree.TabIndex = 3;
            // 
            // cmbSel
            // 
            this.cmbSel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbSel.FormattingEnabled = true;
            this.cmbSel.Location = new System.Drawing.Point(0, 38);
            this.cmbSel.Name = "cmbSel";
            this.cmbSel.Size = new System.Drawing.Size(400, 21);
            this.cmbSel.TabIndex = 4;
            // 
            // Field
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbSel);
            this.Controls.Add(this.txtFree);
            this.Controls.Add(this.label);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Field";
            this.Size = new System.Drawing.Size(400, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtFree;
        private System.Windows.Forms.ComboBox cmbSel;
    }
}
