namespace BUD.CustomControls
{
    partial class ArticleCard
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(128, 44);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Article Name";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAuthor
            // 
            this.lblAuthor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblAuthor.Location = new System.Drawing.Point(10, 118);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(128, 20);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Lorem ipsum dolor sit ammet dolor sit ammet dolor sit ammet dolor sit ammet dolor" +
    " sit ammet";
            // 
            // lblService
            // 
            this.lblService.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblService.Location = new System.Drawing.Point(10, 98);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(128, 20);
            this.lblService.TabIndex = 4;
            this.lblService.Text = "Lorem ipsum dolor sit ammet dolor sit ammet dolor sit ammet dolor sit ammet dolor" +
    " sit ammet";
            // 
            // lblContent
            // 
            this.lblContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblContent.Location = new System.Drawing.Point(10, 54);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(128, 44);
            this.lblContent.TabIndex = 5;
            this.lblContent.Text = "Lorem ipsum dolor sit ammet dolor sit ammet dolor sit ammet dolor sit ammet dolor" +
    " sit ammet";
            // 
            // ArticleCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTitle);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ArticleCard";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(148, 148);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Label lblContent;
    }
}
