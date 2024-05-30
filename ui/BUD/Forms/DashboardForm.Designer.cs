namespace BUD
{
    partial class DashboardForm
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
            this.baseLayout = new System.Windows.Forms.TableLayoutPanel();
            this.sectionsTabs = new BUD.HeadlessTabControl();
            this.sectionMyTickets = new System.Windows.Forms.TabPage();
            this.gridMyTickets = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.sectionManageTickets = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.sectionArticles = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUserGreet = new System.Windows.Forms.Label();
            this.btnEditProfile = new System.Windows.Forms.LinkLabel();
            this.btnLogout = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMyTickets = new System.Windows.Forms.Button();
            this.btnNewTicket = new System.Windows.Forms.Button();
            this.btnManageTickets = new System.Windows.Forms.Button();
            this.btnArticles = new System.Windows.Forms.Button();
            this.pbProfilePicture = new System.Windows.Forms.PictureBox();
            this.baseLayout.SuspendLayout();
            this.sectionsTabs.SuspendLayout();
            this.sectionMyTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMyTickets)).BeginInit();
            this.sectionManageTickets.SuspendLayout();
            this.sectionArticles.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // baseLayout
            // 
            this.baseLayout.ColumnCount = 1;
            this.baseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.baseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.baseLayout.Controls.Add(this.sectionsTabs, 0, 1);
            this.baseLayout.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.baseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseLayout.Location = new System.Drawing.Point(0, 0);
            this.baseLayout.Margin = new System.Windows.Forms.Padding(0);
            this.baseLayout.Name = "baseLayout";
            this.baseLayout.RowCount = 2;
            this.baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.baseLayout.Size = new System.Drawing.Size(800, 450);
            this.baseLayout.TabIndex = 0;
            // 
            // sectionsTabs
            // 
            this.sectionsTabs.Controls.Add(this.sectionMyTickets);
            this.sectionsTabs.Controls.Add(this.sectionManageTickets);
            this.sectionsTabs.Controls.Add(this.sectionArticles);
            this.sectionsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectionsTabs.Location = new System.Drawing.Point(3, 53);
            this.sectionsTabs.Name = "sectionsTabs";
            this.sectionsTabs.SelectedIndex = 0;
            this.sectionsTabs.Size = new System.Drawing.Size(794, 394);
            this.sectionsTabs.TabIndex = 2;
            // 
            // sectionMyTickets
            // 
            this.sectionMyTickets.Controls.Add(this.gridMyTickets);
            this.sectionMyTickets.Controls.Add(this.label1);
            this.sectionMyTickets.Location = new System.Drawing.Point(4, 22);
            this.sectionMyTickets.Name = "sectionMyTickets";
            this.sectionMyTickets.Padding = new System.Windows.Forms.Padding(3);
            this.sectionMyTickets.Size = new System.Drawing.Size(786, 368);
            this.sectionMyTickets.TabIndex = 0;
            this.sectionMyTickets.Text = "MyTickets";
            this.sectionMyTickets.UseVisualStyleBackColor = true;
            // 
            // gridMyTickets
            // 
            this.gridMyTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMyTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMyTickets.Location = new System.Drawing.Point(3, 36);
            this.gridMyTickets.Name = "gridMyTickets";
            this.gridMyTickets.Size = new System.Drawing.Size(780, 329);
            this.gridMyTickets.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(780, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "My Tickets";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sectionManageTickets
            // 
            this.sectionManageTickets.Controls.Add(this.label2);
            this.sectionManageTickets.Location = new System.Drawing.Point(4, 22);
            this.sectionManageTickets.Name = "sectionManageTickets";
            this.sectionManageTickets.Padding = new System.Windows.Forms.Padding(3);
            this.sectionManageTickets.Size = new System.Drawing.Size(786, 368);
            this.sectionManageTickets.TabIndex = 1;
            this.sectionManageTickets.Text = "Manage Tickets";
            this.sectionManageTickets.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(780, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Manage Tickets";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sectionArticles
            // 
            this.sectionArticles.Controls.Add(this.label4);
            this.sectionArticles.Location = new System.Drawing.Point(4, 22);
            this.sectionArticles.Name = "sectionArticles";
            this.sectionArticles.Padding = new System.Windows.Forms.Padding(3);
            this.sectionArticles.Size = new System.Drawing.Size(786, 368);
            this.sectionArticles.TabIndex = 3;
            this.sectionArticles.Text = "Help Articles";
            this.sectionArticles.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(780, 33);
            this.label4.TabIndex = 1;
            this.label4.Text = "Help Articles";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.pbProfilePicture, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(800, 50);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.Controls.Add(this.lblUserGreet, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnEditProfile, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnLogout, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(650, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(150, 53);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // lblUserGreet
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.lblUserGreet, 2);
            this.lblUserGreet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserGreet.Location = new System.Drawing.Point(3, 0);
            this.lblUserGreet.Name = "lblUserGreet";
            this.lblUserGreet.Padding = new System.Windows.Forms.Padding(5, 0, 0, 2);
            this.lblUserGreet.Size = new System.Drawing.Size(144, 26);
            this.lblUserGreet.TabIndex = 4;
            this.lblUserGreet.Text = "Hello, First Name";
            this.lblUserGreet.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditProfile.Location = new System.Drawing.Point(63, 26);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.btnEditProfile.Size = new System.Drawing.Size(84, 27);
            this.btnEditProfile.TabIndex = 8;
            this.btnEditProfile.TabStop = true;
            this.btnEditProfile.Text = "Edit Profile";
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.Location = new System.Drawing.Point(3, 26);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(54, 27);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.TabStop = true;
            this.btnLogout.Text = "Logout";
            this.btnLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnLogout_LinkClicked);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnMyTickets);
            this.flowLayoutPanel1.Controls.Add(this.btnNewTicket);
            this.flowLayoutPanel1.Controls.Add(this.btnManageTickets);
            this.flowLayoutPanel1.Controls.Add(this.btnArticles);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(590, 47);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btnMyTickets
            // 
            this.btnMyTickets.Location = new System.Drawing.Point(3, 3);
            this.btnMyTickets.Name = "btnMyTickets";
            this.btnMyTickets.Size = new System.Drawing.Size(94, 41);
            this.btnMyTickets.TabIndex = 0;
            this.btnMyTickets.Text = "My Tickets";
            this.btnMyTickets.UseVisualStyleBackColor = true;
            this.btnMyTickets.Click += new System.EventHandler(this.btnMyTickets_Click);
            // 
            // btnNewTicket
            // 
            this.btnNewTicket.Location = new System.Drawing.Point(103, 3);
            this.btnNewTicket.Name = "btnNewTicket";
            this.btnNewTicket.Size = new System.Drawing.Size(94, 41);
            this.btnNewTicket.TabIndex = 2;
            this.btnNewTicket.Text = "New Ticket";
            this.btnNewTicket.UseVisualStyleBackColor = true;
            this.btnNewTicket.Click += new System.EventHandler(this.btnNewTicket_Click);
            // 
            // btnManageTickets
            // 
            this.btnManageTickets.Location = new System.Drawing.Point(203, 3);
            this.btnManageTickets.Name = "btnManageTickets";
            this.btnManageTickets.Size = new System.Drawing.Size(94, 41);
            this.btnManageTickets.TabIndex = 1;
            this.btnManageTickets.Text = "Manage Tickets";
            this.btnManageTickets.UseVisualStyleBackColor = true;
            this.btnManageTickets.Click += new System.EventHandler(this.btnManageTickets_Click);
            // 
            // btnArticles
            // 
            this.btnArticles.Location = new System.Drawing.Point(303, 3);
            this.btnArticles.Name = "btnArticles";
            this.btnArticles.Size = new System.Drawing.Size(94, 41);
            this.btnArticles.TabIndex = 4;
            this.btnArticles.Text = "Help Articles";
            this.btnArticles.UseVisualStyleBackColor = true;
            this.btnArticles.Click += new System.EventHandler(this.btnArticles_Click);
            // 
            // pbProfilePicture
            // 
            this.pbProfilePicture.BackColor = System.Drawing.Color.White;
            this.pbProfilePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbProfilePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProfilePicture.Image = global::BUD.Properties.Resources.default_profile_picture;
            this.pbProfilePicture.InitialImage = null;
            this.pbProfilePicture.Location = new System.Drawing.Point(596, 3);
            this.pbProfilePicture.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pbProfilePicture.Name = "pbProfilePicture";
            this.pbProfilePicture.Size = new System.Drawing.Size(54, 50);
            this.pbProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProfilePicture.TabIndex = 3;
            this.pbProfilePicture.TabStop = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.baseLayout);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balcão Único Digital da Universidade de Aveiro - Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DashboardForm_FormClosed);
            this.baseLayout.ResumeLayout(false);
            this.sectionsTabs.ResumeLayout(false);
            this.sectionMyTickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMyTickets)).EndInit();
            this.sectionManageTickets.ResumeLayout(false);
            this.sectionArticles.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel baseLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pbProfilePicture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblUserGreet;
        private System.Windows.Forms.LinkLabel btnLogout;
        private System.Windows.Forms.LinkLabel btnEditProfile;
        private HeadlessTabControl sectionsTabs;
        private System.Windows.Forms.TabPage sectionMyTickets;
        private System.Windows.Forms.TabPage sectionManageTickets;
        private System.Windows.Forms.TabPage sectionArticles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gridMyTickets;
        private System.Windows.Forms.Button btnArticles;
        private System.Windows.Forms.Button btnNewTicket;
        private System.Windows.Forms.Button btnManageTickets;
        private System.Windows.Forms.Button btnMyTickets;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}