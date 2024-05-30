namespace BUD
{
    partial class NewTicketForm
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
            this.stepsTabs = new BUD.HeadlessTabControl();
            this.serviceStep = new System.Windows.Forms.TabPage();
            this.flowLayoutService = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.categoryStep = new System.Windows.Forms.TabPage();
            this.flowLayoutCategory = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.detailsStep = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutCommonDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.stepsTabs.SuspendLayout();
            this.serviceStep.SuspendLayout();
            this.categoryStep.SuspendLayout();
            this.detailsStep.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stepsTabs
            // 
            this.stepsTabs.Controls.Add(this.serviceStep);
            this.stepsTabs.Controls.Add(this.categoryStep);
            this.stepsTabs.Controls.Add(this.detailsStep);
            this.stepsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepsTabs.Location = new System.Drawing.Point(0, 0);
            this.stepsTabs.Name = "stepsTabs";
            this.stepsTabs.SelectedIndex = 0;
            this.stepsTabs.Size = new System.Drawing.Size(800, 450);
            this.stepsTabs.TabIndex = 0;
            // 
            // serviceStep
            // 
            this.serviceStep.Controls.Add(this.flowLayoutService);
            this.serviceStep.Controls.Add(this.label1);
            this.serviceStep.Location = new System.Drawing.Point(4, 22);
            this.serviceStep.Name = "serviceStep";
            this.serviceStep.Padding = new System.Windows.Forms.Padding(3);
            this.serviceStep.Size = new System.Drawing.Size(792, 424);
            this.serviceStep.TabIndex = 0;
            this.serviceStep.Text = "Service";
            this.serviceStep.UseVisualStyleBackColor = true;
            // 
            // flowLayoutService
            // 
            this.flowLayoutService.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutService.Location = new System.Drawing.Point(3, 36);
            this.flowLayoutService.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.flowLayoutService.Name = "flowLayoutService";
            this.flowLayoutService.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.flowLayoutService.Size = new System.Drawing.Size(786, 385);
            this.flowLayoutService.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(786, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a Service";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // categoryStep
            // 
            this.categoryStep.Controls.Add(this.flowLayoutCategory);
            this.categoryStep.Controls.Add(this.label2);
            this.categoryStep.Location = new System.Drawing.Point(4, 22);
            this.categoryStep.Name = "categoryStep";
            this.categoryStep.Padding = new System.Windows.Forms.Padding(3);
            this.categoryStep.Size = new System.Drawing.Size(792, 424);
            this.categoryStep.TabIndex = 1;
            this.categoryStep.Text = "Category";
            this.categoryStep.UseVisualStyleBackColor = true;
            // 
            // flowLayoutCategory
            // 
            this.flowLayoutCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutCategory.Location = new System.Drawing.Point(3, 36);
            this.flowLayoutCategory.Name = "flowLayoutCategory";
            this.flowLayoutCategory.Size = new System.Drawing.Size(786, 385);
            this.flowLayoutCategory.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(786, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select a Category";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // detailsStep
            // 
            this.detailsStep.Controls.Add(this.tableLayoutPanel1);
            this.detailsStep.Controls.Add(this.label3);
            this.detailsStep.Location = new System.Drawing.Point(4, 22);
            this.detailsStep.Name = "detailsStep";
            this.detailsStep.Padding = new System.Windows.Forms.Padding(3);
            this.detailsStep.Size = new System.Drawing.Size(792, 424);
            this.detailsStep.TabIndex = 2;
            this.detailsStep.Text = "Details";
            this.detailsStep.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutCommonDetails, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutDetails, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(786, 385);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // flowLayoutCommonDetails
            // 
            this.flowLayoutCommonDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutCommonDetails.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutCommonDetails.Location = new System.Drawing.Point(18, 3);
            this.flowLayoutCommonDetails.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.flowLayoutCommonDetails.Name = "flowLayoutCommonDetails";
            this.flowLayoutCommonDetails.Size = new System.Drawing.Size(372, 344);
            this.flowLayoutCommonDetails.TabIndex = 8;
            // 
            // flowLayoutDetails
            // 
            this.flowLayoutDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutDetails.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutDetails.Location = new System.Drawing.Point(411, 3);
            this.flowLayoutDetails.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.flowLayoutDetails.Name = "flowLayoutDetails";
            this.flowLayoutDetails.Size = new System.Drawing.Size(372, 344);
            this.flowLayoutDetails.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSubmit);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(393, 350);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(393, 35);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(302, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(88, 29);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(208, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(786, 33);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fill in the Details";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewTicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stepsTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewTicketForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balcão Único Digital da Universidade de Aveiro - New Ticket";
            this.stepsTabs.ResumeLayout(false);
            this.serviceStep.ResumeLayout(false);
            this.categoryStep.ResumeLayout(false);
            this.detailsStep.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HeadlessTabControl stepsTabs;
        private System.Windows.Forms.TabPage serviceStep;
        private System.Windows.Forms.TabPage categoryStep;
        private System.Windows.Forms.TabPage detailsStep;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutDetails;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutCommonDetails;
    }
}