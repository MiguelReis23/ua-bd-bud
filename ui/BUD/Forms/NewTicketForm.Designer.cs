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
            this.categoryStep = new System.Windows.Forms.TabPage();
            this.detailsStep = new System.Windows.Forms.TabPage();
            this.flowLayoutCategory = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.stepsTabs.SuspendLayout();
            this.serviceStep.SuspendLayout();
            this.categoryStep.SuspendLayout();
            this.detailsStep.SuspendLayout();
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
            this.flowLayoutService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutService.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutService.Name = "flowLayoutService";
            this.flowLayoutService.Size = new System.Drawing.Size(786, 418);
            this.flowLayoutService.TabIndex = 0;
            // 
            // categoryStep
            // 
            this.categoryStep.Controls.Add(this.flowLayoutCategory);
            this.categoryStep.Location = new System.Drawing.Point(4, 22);
            this.categoryStep.Name = "categoryStep";
            this.categoryStep.Padding = new System.Windows.Forms.Padding(3);
            this.categoryStep.Size = new System.Drawing.Size(792, 424);
            this.categoryStep.TabIndex = 1;
            this.categoryStep.Text = "Category";
            this.categoryStep.UseVisualStyleBackColor = true;
            // 
            // detailsStep
            // 
            this.detailsStep.Controls.Add(this.flowLayoutDetails);
            this.detailsStep.Location = new System.Drawing.Point(4, 22);
            this.detailsStep.Name = "detailsStep";
            this.detailsStep.Padding = new System.Windows.Forms.Padding(3);
            this.detailsStep.Size = new System.Drawing.Size(792, 424);
            this.detailsStep.TabIndex = 2;
            this.detailsStep.Text = "Details";
            this.detailsStep.UseVisualStyleBackColor = true;
            // 
            // flowLayoutCategory
            // 
            this.flowLayoutCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutCategory.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutCategory.Name = "flowLayoutCategory";
            this.flowLayoutCategory.Size = new System.Drawing.Size(786, 418);
            this.flowLayoutCategory.TabIndex = 1;
            // 
            // flowLayoutDetails
            // 
            this.flowLayoutDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutDetails.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutDetails.Name = "flowLayoutDetails";
            this.flowLayoutDetails.Size = new System.Drawing.Size(786, 418);
            this.flowLayoutDetails.TabIndex = 1;
            // 
            // NewTicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stepsTabs);
            this.Name = "NewTicketForm";
            this.Text = "Balcão Único Digital da Universidade de Aveiro - New Ticket";
            this.stepsTabs.ResumeLayout(false);
            this.serviceStep.ResumeLayout(false);
            this.categoryStep.ResumeLayout(false);
            this.detailsStep.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HeadlessTabControl stepsTabs;
        private System.Windows.Forms.TabPage serviceStep;
        private System.Windows.Forms.TabPage categoryStep;
        private System.Windows.Forms.TabPage detailsStep;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutService;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutCategory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutDetails;
    }
}