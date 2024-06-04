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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshMyTickets = new System.Windows.Forms.Button();
            this.btnFilterTicketUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sectionManageTickets = new System.Windows.Forms.TabPage();
            this.gridManageTickets = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMngrNextPage = new System.Windows.Forms.Button();
            this.txtMngrPage = new System.Windows.Forms.TextBox();
            this.btnMngrPreviousPage = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshManageTickets = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnSetFilters = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.sectionArticles = new System.Windows.Forms.TabPage();
            this.articlesGrid = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.sectionStatistics = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTotalTickets = new System.Windows.Forms.Label();
            this.lblLowPriorityTickets = new System.Windows.Forms.Label();
            this.lblMediumPriorityTickets = new System.Windows.Forms.Label();
            this.lblHighPriorityTickets = new System.Windows.Forms.Label();
            this.lblOpenTickets = new System.Windows.Forms.Label();
            this.lblTicketsInProgress = new System.Windows.Forms.Label();
            this.lblClosedTickets = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshStatistics = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUserGreet = new System.Windows.Forms.Label();
            this.btnEditProfile = new System.Windows.Forms.LinkLabel();
            this.btnLogout = new System.Windows.Forms.LinkLabel();
            this.pbProfilePicture = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMyTickets = new System.Windows.Forms.Button();
            this.btnNewTicket = new System.Windows.Forms.Button();
            this.btnManageTickets = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnArticles = new System.Windows.Forms.Button();
            this.baseLayout.SuspendLayout();
            this.sectionsTabs.SuspendLayout();
            this.sectionMyTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMyTickets)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.sectionManageTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridManageTickets)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.sectionArticles.SuspendLayout();
            this.sectionStatistics.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.sectionsTabs.Controls.Add(this.sectionStatistics);
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
            this.sectionMyTickets.Controls.Add(this.tableLayoutPanel1);
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
            this.gridMyTickets.AllowUserToAddRows = false;
            this.gridMyTickets.AllowUserToDeleteRows = false;
            this.gridMyTickets.AllowUserToOrderColumns = true;
            this.gridMyTickets.AllowUserToResizeColumns = false;
            this.gridMyTickets.AllowUserToResizeRows = false;
            this.gridMyTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMyTickets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridMyTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMyTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMyTickets.Location = new System.Drawing.Point(3, 39);
            this.gridMyTickets.MultiSelect = false;
            this.gridMyTickets.Name = "gridMyTickets";
            this.gridMyTickets.ReadOnly = true;
            this.gridMyTickets.RowHeadersVisible = false;
            this.gridMyTickets.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridMyTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMyTickets.ShowCellErrors = false;
            this.gridMyTickets.ShowCellToolTips = false;
            this.gridMyTickets.ShowEditingIcon = false;
            this.gridMyTickets.ShowRowErrors = false;
            this.gridMyTickets.Size = new System.Drawing.Size(780, 326);
            this.gridMyTickets.TabIndex = 3;
            this.gridMyTickets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMyTickets_CellClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.92308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 36);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnRefreshMyTickets);
            this.flowLayoutPanel2.Controls.Add(this.btnFilterTicketUser);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(603, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(174, 30);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // btnRefreshMyTickets
            // 
            this.btnRefreshMyTickets.Location = new System.Drawing.Point(93, 3);
            this.btnRefreshMyTickets.Name = "btnRefreshMyTickets";
            this.btnRefreshMyTickets.Size = new System.Drawing.Size(78, 25);
            this.btnRefreshMyTickets.TabIndex = 0;
            this.btnRefreshMyTickets.Text = "Refresh";
            this.btnRefreshMyTickets.UseVisualStyleBackColor = true;
            this.btnRefreshMyTickets.Click += new System.EventHandler(this.btnRefreshMyTickets_Click);
            // 
            // btnFilterTicketUser
            // 
            this.btnFilterTicketUser.Location = new System.Drawing.Point(4, 3);
            this.btnFilterTicketUser.Name = "btnFilterTicketUser";
            this.btnFilterTicketUser.Size = new System.Drawing.Size(83, 25);
            this.btnFilterTicketUser.TabIndex = 3;
            this.btnFilterTicketUser.Text = "Set Filters";
            this.btnFilterTicketUser.UseVisualStyleBackColor = true;
            this.btnFilterTicketUser.Click += new System.EventHandler(this.btnFilterTicketUser_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(594, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "My Tickets";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sectionManageTickets
            // 
            this.sectionManageTickets.Controls.Add(this.gridManageTickets);
            this.sectionManageTickets.Controls.Add(this.panel1);
            this.sectionManageTickets.Controls.Add(this.tableLayoutPanel4);
            this.sectionManageTickets.Location = new System.Drawing.Point(4, 22);
            this.sectionManageTickets.Margin = new System.Windows.Forms.Padding(0);
            this.sectionManageTickets.Name = "sectionManageTickets";
            this.sectionManageTickets.Padding = new System.Windows.Forms.Padding(3);
            this.sectionManageTickets.Size = new System.Drawing.Size(786, 368);
            this.sectionManageTickets.TabIndex = 1;
            this.sectionManageTickets.Text = "Manage Tickets";
            this.sectionManageTickets.UseVisualStyleBackColor = true;
            // 
            // gridManageTickets
            // 
            this.gridManageTickets.AllowUserToAddRows = false;
            this.gridManageTickets.AllowUserToDeleteRows = false;
            this.gridManageTickets.AllowUserToOrderColumns = true;
            this.gridManageTickets.AllowUserToResizeColumns = false;
            this.gridManageTickets.AllowUserToResizeRows = false;
            this.gridManageTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridManageTickets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridManageTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridManageTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridManageTickets.Location = new System.Drawing.Point(3, 39);
            this.gridManageTickets.MultiSelect = false;
            this.gridManageTickets.Name = "gridManageTickets";
            this.gridManageTickets.ReadOnly = true;
            this.gridManageTickets.RowHeadersVisible = false;
            this.gridManageTickets.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridManageTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridManageTickets.ShowCellErrors = false;
            this.gridManageTickets.ShowCellToolTips = false;
            this.gridManageTickets.ShowEditingIcon = false;
            this.gridManageTickets.ShowRowErrors = false;
            this.gridManageTickets.Size = new System.Drawing.Size(780, 288);
            this.gridManageTickets.TabIndex = 5;
            this.gridManageTickets.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridManageTickets_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 327);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 38);
            this.panel1.TabIndex = 4;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.btnMngrNextPage);
            this.flowLayoutPanel6.Controls.Add(this.txtMngrPage);
            this.flowLayoutPanel6.Controls.Add(this.btnMngrPreviousPage);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(780, 38);
            this.flowLayoutPanel6.TabIndex = 9;
            // 
            // btnMngrNextPage
            // 
            this.btnMngrNextPage.Location = new System.Drawing.Point(706, 9);
            this.btnMngrNextPage.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.btnMngrNextPage.Name = "btnMngrNextPage";
            this.btnMngrNextPage.Size = new System.Drawing.Size(71, 25);
            this.btnMngrNextPage.TabIndex = 6;
            this.btnMngrNextPage.Text = "Next";
            this.btnMngrNextPage.UseVisualStyleBackColor = true;
            this.btnMngrNextPage.Click += new System.EventHandler(this.btnMngrNextPage_Click_1);
            // 
            // txtMngrPage
            // 
            this.txtMngrPage.Location = new System.Drawing.Point(613, 11);
            this.txtMngrPage.Margin = new System.Windows.Forms.Padding(3, 11, 3, 3);
            this.txtMngrPage.Name = "txtMngrPage";
            this.txtMngrPage.Size = new System.Drawing.Size(87, 20);
            this.txtMngrPage.TabIndex = 8;
            this.txtMngrPage.TextChanged += new System.EventHandler(this.txtMngrPage_TextChanged_1);
            // 
            // btnMngrPreviousPage
            // 
            this.btnMngrPreviousPage.Enabled = false;
            this.btnMngrPreviousPage.Location = new System.Drawing.Point(536, 9);
            this.btnMngrPreviousPage.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.btnMngrPreviousPage.Name = "btnMngrPreviousPage";
            this.btnMngrPreviousPage.Size = new System.Drawing.Size(71, 25);
            this.btnMngrPreviousPage.TabIndex = 7;
            this.btnMngrPreviousPage.Text = "Previous";
            this.btnMngrPreviousPage.UseVisualStyleBackColor = true;
            this.btnMngrPreviousPage.Click += new System.EventHandler(this.btnMngrPreviousPage_Click_1);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel3, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(780, 36);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnRefreshManageTickets);
            this.flowLayoutPanel3.Controls.Add(this.btnDeleteSelected);
            this.flowLayoutPanel3.Controls.Add(this.btnSetFilters);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(510, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(267, 30);
            this.flowLayoutPanel3.TabIndex = 8;
            // 
            // btnRefreshManageTickets
            // 
            this.btnRefreshManageTickets.Location = new System.Drawing.Point(196, 3);
            this.btnRefreshManageTickets.Name = "btnRefreshManageTickets";
            this.btnRefreshManageTickets.Size = new System.Drawing.Size(68, 25);
            this.btnRefreshManageTickets.TabIndex = 0;
            this.btnRefreshManageTickets.Text = "Refresh";
            this.btnRefreshManageTickets.UseVisualStyleBackColor = true;
            this.btnRefreshManageTickets.Click += new System.EventHandler(this.btnRefreshManageTickets_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(85, 3);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(105, 25);
            this.btnDeleteSelected.TabIndex = 1;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnSetFilters
            // 
            this.btnSetFilters.Location = new System.Drawing.Point(8, 3);
            this.btnSetFilters.Name = "btnSetFilters";
            this.btnSetFilters.Size = new System.Drawing.Size(71, 25);
            this.btnSetFilters.TabIndex = 2;
            this.btnSetFilters.Text = "Set Filters";
            this.btnSetFilters.UseVisualStyleBackColor = true;
            this.btnSetFilters.Click += new System.EventHandler(this.btnSetFilters_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(501, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "Manage Tickets";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sectionArticles
            // 
            this.sectionArticles.Controls.Add(this.articlesGrid);
            this.sectionArticles.Controls.Add(this.label4);
            this.sectionArticles.Location = new System.Drawing.Point(4, 22);
            this.sectionArticles.Name = "sectionArticles";
            this.sectionArticles.Padding = new System.Windows.Forms.Padding(3);
            this.sectionArticles.Size = new System.Drawing.Size(786, 368);
            this.sectionArticles.TabIndex = 3;
            this.sectionArticles.Text = "Help Articles";
            this.sectionArticles.UseVisualStyleBackColor = true;
            // 
            // articlesGrid
            // 
            this.articlesGrid.AutoScroll = true;
            this.articlesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.articlesGrid.Location = new System.Drawing.Point(3, 36);
            this.articlesGrid.Name = "articlesGrid";
            this.articlesGrid.Size = new System.Drawing.Size(780, 329);
            this.articlesGrid.TabIndex = 2;
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
            // sectionStatistics
            // 
            this.sectionStatistics.Controls.Add(this.flowLayoutPanel5);
            this.sectionStatistics.Controls.Add(this.tableLayoutPanel5);
            this.sectionStatistics.Location = new System.Drawing.Point(4, 22);
            this.sectionStatistics.Name = "sectionStatistics";
            this.sectionStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.sectionStatistics.Size = new System.Drawing.Size(786, 368);
            this.sectionStatistics.TabIndex = 4;
            this.sectionStatistics.Text = "Statistics";
            this.sectionStatistics.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.lblTotalTickets);
            this.flowLayoutPanel5.Controls.Add(this.lblLowPriorityTickets);
            this.flowLayoutPanel5.Controls.Add(this.lblMediumPriorityTickets);
            this.flowLayoutPanel5.Controls.Add(this.lblHighPriorityTickets);
            this.flowLayoutPanel5.Controls.Add(this.lblOpenTickets);
            this.flowLayoutPanel5.Controls.Add(this.lblTicketsInProgress);
            this.flowLayoutPanel5.Controls.Add(this.lblClosedTickets);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 39);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(780, 326);
            this.flowLayoutPanel5.TabIndex = 4;
            // 
            // lblTotalTickets
            // 
            this.lblTotalTickets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTotalTickets.Location = new System.Drawing.Point(3, 5);
            this.lblTotalTickets.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblTotalTickets.Name = "lblTotalTickets";
            this.lblTotalTickets.Size = new System.Drawing.Size(254, 30);
            this.lblTotalTickets.TabIndex = 0;
            this.lblTotalTickets.Text = "Total Tickets:";
            this.lblTotalTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLowPriorityTickets
            // 
            this.lblLowPriorityTickets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLowPriorityTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblLowPriorityTickets.Location = new System.Drawing.Point(263, 5);
            this.lblLowPriorityTickets.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblLowPriorityTickets.Name = "lblLowPriorityTickets";
            this.lblLowPriorityTickets.Size = new System.Drawing.Size(254, 30);
            this.lblLowPriorityTickets.TabIndex = 0;
            this.lblLowPriorityTickets.Text = "Low Priority Tickets:";
            this.lblLowPriorityTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMediumPriorityTickets
            // 
            this.lblMediumPriorityTickets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMediumPriorityTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMediumPriorityTickets.Location = new System.Drawing.Point(523, 5);
            this.lblMediumPriorityTickets.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblMediumPriorityTickets.Name = "lblMediumPriorityTickets";
            this.lblMediumPriorityTickets.Size = new System.Drawing.Size(254, 30);
            this.lblMediumPriorityTickets.TabIndex = 0;
            this.lblMediumPriorityTickets.Text = "Medium Priority Tickets:";
            this.lblMediumPriorityTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHighPriorityTickets
            // 
            this.lblHighPriorityTickets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHighPriorityTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblHighPriorityTickets.Location = new System.Drawing.Point(3, 45);
            this.lblHighPriorityTickets.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblHighPriorityTickets.Name = "lblHighPriorityTickets";
            this.lblHighPriorityTickets.Size = new System.Drawing.Size(254, 30);
            this.lblHighPriorityTickets.TabIndex = 1;
            this.lblHighPriorityTickets.Text = "High Priority Tickets:";
            this.lblHighPriorityTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOpenTickets
            // 
            this.lblOpenTickets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOpenTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblOpenTickets.Location = new System.Drawing.Point(263, 45);
            this.lblOpenTickets.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblOpenTickets.Name = "lblOpenTickets";
            this.lblOpenTickets.Size = new System.Drawing.Size(254, 30);
            this.lblOpenTickets.TabIndex = 1;
            this.lblOpenTickets.Text = "Open Tickets:";
            this.lblOpenTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTicketsInProgress
            // 
            this.lblTicketsInProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTicketsInProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTicketsInProgress.Location = new System.Drawing.Point(523, 45);
            this.lblTicketsInProgress.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblTicketsInProgress.Name = "lblTicketsInProgress";
            this.lblTicketsInProgress.Size = new System.Drawing.Size(254, 30);
            this.lblTicketsInProgress.TabIndex = 1;
            this.lblTicketsInProgress.Text = "Tickets In Progress:";
            this.lblTicketsInProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblClosedTickets
            // 
            this.lblClosedTickets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClosedTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblClosedTickets.Location = new System.Drawing.Point(3, 85);
            this.lblClosedTickets.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblClosedTickets.Name = "lblClosedTickets";
            this.lblClosedTickets.Size = new System.Drawing.Size(254, 30);
            this.lblClosedTickets.TabIndex = 0;
            this.lblClosedTickets.Text = "Tickets Closed:";
            this.lblClosedTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.92308F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel4, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(780, 36);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.btnRefreshStatistics);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(603, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(174, 30);
            this.flowLayoutPanel4.TabIndex = 8;
            // 
            // btnRefreshStatistics
            // 
            this.btnRefreshStatistics.Location = new System.Drawing.Point(103, 3);
            this.btnRefreshStatistics.Name = "btnRefreshStatistics";
            this.btnRefreshStatistics.Size = new System.Drawing.Size(68, 25);
            this.btnRefreshStatistics.TabIndex = 0;
            this.btnRefreshStatistics.Text = "Refresh";
            this.btnRefreshStatistics.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(594, 36);
            this.label3.TabIndex = 0;
            this.label3.Text = "Statistics";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnEditProfile.Text = "My Profile";
            this.btnEditProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnEditProfile_LinkClicked);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnMyTickets);
            this.flowLayoutPanel1.Controls.Add(this.btnNewTicket);
            this.flowLayoutPanel1.Controls.Add(this.btnManageTickets);
            this.flowLayoutPanel1.Controls.Add(this.btnStatistics);
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
            // btnStatistics
            // 
            this.btnStatistics.Location = new System.Drawing.Point(303, 3);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(94, 41);
            this.btnStatistics.TabIndex = 5;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnArticles
            // 
            this.btnArticles.Location = new System.Drawing.Point(403, 3);
            this.btnArticles.Name = "btnArticles";
            this.btnArticles.Size = new System.Drawing.Size(94, 41);
            this.btnArticles.TabIndex = 4;
            this.btnArticles.Text = "Help Articles";
            this.btnArticles.UseVisualStyleBackColor = true;
            this.btnArticles.Click += new System.EventHandler(this.btnArticles_Click);
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
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.baseLayout.ResumeLayout(false);
            this.sectionsTabs.ResumeLayout(false);
            this.sectionMyTickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMyTickets)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.sectionManageTickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridManageTickets)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.sectionArticles.ResumeLayout(false);
            this.sectionStatistics.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnArticles;
        private System.Windows.Forms.Button btnNewTicket;
        private System.Windows.Forms.Button btnManageTickets;
        private System.Windows.Forms.Button btnMyTickets;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnRefreshMyTickets;
        private System.Windows.Forms.DataGridView gridMyTickets;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnRefreshManageTickets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage sectionStatistics;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button btnRefreshStatistics;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label lblHighPriorityTickets;
        private System.Windows.Forms.Label lblTotalTickets;
        private System.Windows.Forms.Label lblOpenTickets;
        private System.Windows.Forms.Label lblLowPriorityTickets;
        private System.Windows.Forms.Label lblTicketsInProgress;
        private System.Windows.Forms.Label lblMediumPriorityTickets;
        private System.Windows.Forms.Label lblClosedTickets;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnSetFilters;
        private System.Windows.Forms.Button btnFilterTicketUser;
        private System.Windows.Forms.DataGridView gridManageTickets;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Button btnMngrNextPage;
        private System.Windows.Forms.TextBox txtMngrPage;
        private System.Windows.Forms.Button btnMngrPreviousPage;
        private System.Windows.Forms.FlowLayoutPanel articlesGrid;
    }
}