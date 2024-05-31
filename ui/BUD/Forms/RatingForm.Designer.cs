namespace BUD.Forms
{
    partial class RatingForm
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
            this.rd0 = new System.Windows.Forms.RadioButton();
            this.rd1 = new System.Windows.Forms.RadioButton();
            this.rd2 = new System.Windows.Forms.RadioButton();
            this.rd3 = new System.Windows.Forms.RadioButton();
            this.rd4 = new System.Windows.Forms.RadioButton();
            this.rd5 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rd0
            // 
            this.rd0.AutoSize = true;
            this.rd0.Location = new System.Drawing.Point(29, 60);
            this.rd0.Name = "rd0";
            this.rd0.Size = new System.Drawing.Size(31, 17);
            this.rd0.TabIndex = 0;
            this.rd0.TabStop = true;
            this.rd0.Text = "0";
            this.rd0.UseVisualStyleBackColor = true;
            // 
            // rd1
            // 
            this.rd1.AutoSize = true;
            this.rd1.Location = new System.Drawing.Point(66, 60);
            this.rd1.Name = "rd1";
            this.rd1.Size = new System.Drawing.Size(31, 17);
            this.rd1.TabIndex = 1;
            this.rd1.TabStop = true;
            this.rd1.Text = "1";
            this.rd1.UseVisualStyleBackColor = true;
            // 
            // rd2
            // 
            this.rd2.AutoSize = true;
            this.rd2.Location = new System.Drawing.Point(103, 60);
            this.rd2.Name = "rd2";
            this.rd2.Size = new System.Drawing.Size(31, 17);
            this.rd2.TabIndex = 2;
            this.rd2.TabStop = true;
            this.rd2.Text = "2";
            this.rd2.UseVisualStyleBackColor = true;
            // 
            // rd3
            // 
            this.rd3.AutoSize = true;
            this.rd3.Location = new System.Drawing.Point(140, 60);
            this.rd3.Name = "rd3";
            this.rd3.Size = new System.Drawing.Size(31, 17);
            this.rd3.TabIndex = 3;
            this.rd3.TabStop = true;
            this.rd3.Text = "3";
            this.rd3.UseVisualStyleBackColor = true;
            // 
            // rd4
            // 
            this.rd4.AutoSize = true;
            this.rd4.Location = new System.Drawing.Point(177, 60);
            this.rd4.Name = "rd4";
            this.rd4.Size = new System.Drawing.Size(31, 17);
            this.rd4.TabIndex = 4;
            this.rd4.TabStop = true;
            this.rd4.Text = "4";
            this.rd4.UseVisualStyleBackColor = true;
            // 
            // rd5
            // 
            this.rd5.AutoSize = true;
            this.rd5.Location = new System.Drawing.Point(214, 60);
            this.rd5.Name = "rd5";
            this.rd5.Size = new System.Drawing.Size(31, 17);
            this.rd5.TabIndex = 5;
            this.rd5.TabStop = true;
            this.rd5.Text = "5";
            this.rd5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(76, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rate This Ticket";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(98, 97);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(79, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Ok";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // RatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 132);
            this.ControlBox = false;
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rd5);
            this.Controls.Add(this.rd4);
            this.Controls.Add(this.rd3);
            this.Controls.Add(this.rd2);
            this.Controls.Add(this.rd1);
            this.Controls.Add(this.rd0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RatingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rate This Ticket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rd0;
        private System.Windows.Forms.RadioButton rd1;
        private System.Windows.Forms.RadioButton rd2;
        private System.Windows.Forms.RadioButton rd3;
        private System.Windows.Forms.RadioButton rd4;
        private System.Windows.Forms.RadioButton rd5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
    }
}