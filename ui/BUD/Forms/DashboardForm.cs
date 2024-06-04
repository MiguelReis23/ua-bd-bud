using BUD.CustomControls;
using BUD.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BUD
{
    public partial class DashboardForm : Form
    {
        private int selectedServiceId = -1;
        private int selectedCategoryId = -1;
        private int selectedStatusId = -1;
        private int selectedPriorityId = -1;

        private int currentPageNumber = 1;
        private int pageSize = 20;

        User authenticatedUser = AuthenticatedUser.GetAuthenticatedUser();
        AuthenticationForm authenticationForm;
        private bool isLoggingOut = false;

        public DashboardForm(AuthenticationForm authenticationForm)
        {
            this.authenticationForm = authenticationForm;

            InitializeComponent();
            sectionsTabs.SelectedIndex = 0;

            string[] segmented_name = authenticatedUser.FullName.Split(' ');
            string first_name = segmented_name.GetValue(0).ToString();
            string last_name = segmented_name.GetValue(segmented_name.Length - 1).ToString();

            lblUserGreet.Text = "Hello, " + first_name + " " + last_name + "!";
            btnManageTickets.Visible = authenticatedUser.UserIdentifiesAs("Staff");
            btnStatistics.Visible = authenticatedUser.UserIdentifiesAs("Staff");

            RefreshProfilePic();
            

            txtMngrPage.Text = currentPageNumber.ToString();
        }

        public void RefreshProfilePic()
        {
            if (authenticatedUser.Picture != null)
            {
                RetrieveAndDisplayPicture(authenticatedUser.Picture);
            }
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isLoggingOut)
            {
                Application.Exit();
            }
        }

        private void btnMyTickets_Click(object sender, EventArgs e)
        {
            sectionsTabs.SelectTab(0);

            selectedServiceId = -1;
            selectedCategoryId = -1;
            selectedStatusId = -1;
            selectedPriorityId = -1;

            currentPageNumber = 1;
            LoadUserTickets();
        }

        private void btnManageTickets_Click(object sender, EventArgs e)
        {
            sectionsTabs.SelectTab(1);

            selectedServiceId = -1;
            selectedCategoryId = -1;
            selectedStatusId = -1;
            selectedPriorityId = -1;

            currentPageNumber = 1;
            LoadAllTickets();
        }

        private void btnNewTicket_Click(object sender, EventArgs e)
        {
            new NewTicketForm(this).ShowDialog();
        }

        private void ApplyEventRecursive(Control parent_control, EventHandler eventHandler)
        {
            foreach (Control control in parent_control.Controls)
            {
                control.Tag = parent_control;
                control.Click += eventHandler;
                //ApplyEventRecursive(control, eventHandler);
            }

            parent_control.Click += eventHandler;
        }
        private void btnArticles_Click(object sender, EventArgs e)
        {
            sectionsTabs.SelectTab(2);

            using (SqlConnection connection = Database.GetDatabase().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                SELECT 
                    a.id, 
                    a.title, 
                    a.author, 
                    a.content, 
                    a.[date], 
                    a.service_id,
                    s.[name] AS service_name
                FROM 
                    BUD.article a
                JOIN 
                    BUD.service s ON a.service_id = s.id";

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        articlesGrid.Controls.Clear(); // Clear previous controls

                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string title = reader.GetString(1);
                            string author = reader.GetString(2);
                            string content = reader.GetString(3);
                            DateTime date = reader.GetDateTime(4);
                            int serviceId = reader.GetInt32(5);
                            string serviceName = reader.GetString(6);

                            ArticleCard articleCard = new ArticleCard(id, title, content, author, date, serviceName)
                            {
                                Width = articlesGrid.Width / 2 - 15
                            };

                            ApplyEventRecursive(articleCard, (s, ev) =>
                            {
                                Control control = (Control)s;
                                ArticleCard articleCard1;

                                if (control is  ArticleCard)
                                {
                                    articleCard1 = (ArticleCard)control;
                                } else
                                {
                                    articleCard = (ArticleCard)control.Parent;
                                }

                                ArticleRendererForm articleRendererForm = new ArticleRendererForm(articleCard.ArticleId);
                                articleRendererForm.ShowDialog();
                            });

                            articlesGrid.Controls.Add(articleCard);
                        }
                    }
                }
            }
        }

        private void btnLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            isLoggingOut = true;
            AuthenticatedUser.Logout();
            authenticationForm.Show();
            this.Close();
        }

        public void LoadAllTickets()
        {
            DataTable dataTable = GetUserTickets(null);
            gridManageTickets.DataSource = dataTable;

            if (gridManageTickets.Rows.Count < pageSize)
            {
                btnMngrNextPage.Enabled = false;
            } else
            {
                btnMngrNextPage.Enabled = true;
            }
        }

        public void LoadUserTickets()
        {
            DataTable dataTable = GetUserTickets(authenticatedUser.UserId);
            gridMyTickets.DataSource = dataTable;
        }

        private DataTable GetUserTickets(int? userId)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = Database.GetDatabase().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SeeUserTickets";
                    command.CommandType = CommandType.StoredProcedure;

                    if (userId != null)
                    {
                        command.Parameters.AddWithValue("@user_id", userId);
                    }

                    if (selectedServiceId != -1)
                    {
                        Console.WriteLine("Added filter for service_id: " + selectedServiceId);
                        command.Parameters.AddWithValue("@service_id", selectedServiceId);
                    }

                    if (selectedCategoryId != -1)
                    {
                        Console.WriteLine("Added filter for category_id: " + selectedCategoryId);
                        command.Parameters.AddWithValue("@category_id", selectedCategoryId);
                    }

                    if (selectedStatusId != -1)
                    {
                        Console.WriteLine("Added filter for status_id: " + selectedStatusId);
                        command.Parameters.AddWithValue("@status_id", selectedStatusId);
                    }

                    if (selectedPriorityId != -1)
                    {
                        Console.WriteLine("Added filter for priority_id: " + selectedPriorityId);
                        command.Parameters.AddWithValue("@priority_id", selectedPriorityId);
                    }

                    command.Parameters.AddWithValue("@page_number", currentPageNumber);
                    command.Parameters.AddWithValue("@page_size", pageSize);

                    connection.Open();
                    command.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        private void btnRefreshMyTickets_Click(object sender, EventArgs e)
        {
            LoadUserTickets();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadUserTickets();
        }

        private void btnRefreshManageTickets_Click(object sender, EventArgs e)
        {
            LoadAllTickets();
        }

        private void gridMyTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gridMyTickets.Rows.Count)
            {
                int ticketId = Convert.ToInt32(gridMyTickets.Rows[e.RowIndex].Cells["ticket_id"].Value);

                TicketViewerForm ticketDetailsForm = new TicketViewerForm(this, ticketId, true);
                ticketDetailsForm.ShowDialog();
            }
        }

        private void LoadStatistics()
        {
            string connectionString = Database.GetDatabase().GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Total Tickets
                using (SqlCommand cmd = new SqlCommand("SELECT BUD.TotalTickets(NULL) AS TotalTickets", connection))
                {
                    lblTotalTickets.Text = "Total Tickets: " + cmd.ExecuteScalar().ToString();
                }

                // Low Priority Tickets
                using (SqlCommand cmd = new SqlCommand("SELECT BUD.TotalTicketsWithPriority(1) AS LowPriorityTickets", connection))
                {
                    lblLowPriorityTickets.Text = "Low Priority Tickets: " + cmd.ExecuteScalar().ToString();
                }

                // Medium Priority Tickets
                using (SqlCommand cmd = new SqlCommand("SELECT BUD.TotalTicketsWithPriority(2) AS MediumPriorityTickets", connection))
                {
                    lblMediumPriorityTickets.Text = "Medium Priority Tickets: " + cmd.ExecuteScalar().ToString();
                }

                // High Priority Tickets
                using (SqlCommand cmd = new SqlCommand("SELECT BUD.TotalTicketsWithPriority(3) AS HighPriorityTickets", connection))
                {
                    lblHighPriorityTickets.Text = "High Priority Tickets: " + cmd.ExecuteScalar().ToString();
                }

                // Open Tickets
                using (SqlCommand cmd = new SqlCommand("SELECT BUD.TotalTicketsWithStatus(1) AS OpenTickets", connection))
                {
                    lblOpenTickets.Text = "Open Tickets: " + cmd.ExecuteScalar().ToString();
                }

                // Closed Tickets
                using (SqlCommand cmd = new SqlCommand("SELECT BUD.TotalTicketsWithStatus(3) AS ClosedTickets", connection))
                {
                    lblClosedTickets.Text = "Closed Tickets: " + cmd.ExecuteScalar().ToString();
                }

                // Tickets In Progress
                using (SqlCommand cmd = new SqlCommand("SELECT BUD.TotalTicketsWithStatus(2) AS TicketsInProgress", connection))
                {
                    lblTicketsInProgress.Text = "Tickets In Progress: " + cmd.ExecuteScalar().ToString();
                }
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            sectionsTabs.SelectTab(3);
            LoadStatistics();
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            gridManageTickets.SelectedRows.Cast<DataGridViewRow>().ToList().ForEach(row =>
            {
                int ticketId = Convert.ToInt32(row.Cells["ticket_id"].Value);
                using (SqlConnection connection = Database.GetDatabase().GetConnection())
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "DeleteTicket";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ticket_id", ticketId);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            });

            LoadAllTickets();
        }

        private void btnSetFilters_Click(object sender, EventArgs e)
        {
            FilterForm filterForm = new FilterForm();
            filterForm.ShowDialog();

            currentPageNumber = 1;
            txtMngrPage.Text = currentPageNumber.ToString();
            btnMngrPreviousPage.Enabled = false;

            selectedServiceId = filterForm.SelectedServiceId;
            selectedCategoryId = filterForm.SelectedCategoryId;
            selectedStatusId = filterForm.SelectedStatusId;
            selectedPriorityId = filterForm.SelectedPriorityId;

            currentPageNumber = 1;
            LoadAllTickets();
        }

        private void btnFilterTicketUser_Click(object sender, EventArgs e)
        {
            FilterForm filterForm = new FilterForm();
            filterForm.ShowDialog();

            selectedServiceId = filterForm.SelectedServiceId;
            selectedCategoryId = filterForm.SelectedCategoryId;
            selectedStatusId = filterForm.SelectedStatusId;
            selectedPriorityId = filterForm.SelectedPriorityId;

            currentPageNumber = 1;
            LoadUserTickets();
        }

        private void btnMngrNextPage_Click_1(object sender, EventArgs e)
        {
            currentPageNumber++;
            txtMngrPage.Text = currentPageNumber.ToString();
            btnMngrPreviousPage.Enabled = true;
            LoadAllTickets();
        }

        private void txtMngrPage_TextChanged_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtMngrPage.Text, out int pageNumber))
            {
                currentPageNumber = pageNumber > 0 ? pageNumber : 1;
                btnMngrPreviousPage.Enabled = currentPageNumber > 1;
                LoadAllTickets();
            }
        }

        private void btnMngrPreviousPage_Click_1(object sender, EventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber--;
                txtMngrPage.Text = currentPageNumber.ToString();
                LoadAllTickets();
            }
            else
            {
                btnMngrPreviousPage.Enabled = false;
            }
        }

        private void gridManageTickets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gridManageTickets.Rows.Count)
            {
                int ticketId = Convert.ToInt32(gridManageTickets.Rows[e.RowIndex].Cells["ticket_id"].Value);

                TicketViewerForm ticketDetailsForm = new TicketViewerForm(this, ticketId, false);
                ticketDetailsForm.ShowDialog();
            }
        }

        private void btnEditProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(authenticatedUser, this);
            profileForm.ShowDialog();
        }

        private void RetrieveAndDisplayPicture(int? pictureId)
        {
            using (SqlConnection connection = Database.GetDatabase().GetConnection())
            {
                using (SqlCommand command = new SqlCommand("GetUserPicture", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", authenticatedUser.UserId);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        byte[] pictureData = (byte[])result;

                        using (MemoryStream ms = new MemoryStream(pictureData))
                        {
                            pbProfilePicture.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pbProfilePicture.Image = null;
                    }
                }
            }
        }
    }
}
