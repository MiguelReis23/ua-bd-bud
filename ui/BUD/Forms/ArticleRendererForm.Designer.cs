namespace BUD.Forms
{
    partial class ArticleRendererForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticleRendererForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMetadata = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(614, 44);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Article Name";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMetadata
            // 
            this.lblMetadata.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMetadata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblMetadata.Location = new System.Drawing.Point(10, 54);
            this.lblMetadata.Name = "lblMetadata";
            this.lblMetadata.Size = new System.Drawing.Size(614, 20);
            this.lblMetadata.TabIndex = 5;
            this.lblMetadata.Text = "Lorem ipsum dolor sit ammet dolor sit ammet dolor sit ammet dolor sit ammet dolor" +
    " sit ammet";
            // 
            // lblContent
            // 
            this.lblContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblContent.Location = new System.Drawing.Point(10, 74);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(614, 244);
            this.lblContent.TabIndex = 6;
            this.lblContent.Text = "Lorem ipsum dolor sit ammet dolor sit ammet dolor sit ammet dolor sit ammet dolor" +
    " sit ammet";
            // 
            // ArticleRendererForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 328);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblMetadata);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ArticleRendererForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balcão Único Digital da Universidade de Aveiro - ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMetadata;
        private System.Windows.Forms.Label lblContent;
    }
}