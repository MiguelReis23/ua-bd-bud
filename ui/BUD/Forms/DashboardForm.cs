using BUD.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUD
{
    public partial class DashboardForm : Form
    {
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

            pbProfilePicture.Image = authenticatedUser.Picture == null ? Properties.Resources.default_profile_picture : Properties.Resources.default_profile_picture;
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
            LoadUserTickets();
        }

        private void btnManageTickets_Click(object sender, EventArgs e)
        {
            sectionsTabs.SelectTab(1);
            LoadAllTickets();
        }

        private void btnNewTicket_Click(object sender, EventArgs e)
        {
            new NewTicketForm(this).ShowDialog();
        }

        private void btnArticles_Click(object sender, EventArgs e)
        {
            sectionsTabs.SelectTab(2);
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

                    connection.Open();
                    command.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }

            // Reverse the order of the rows in the DataTable
            DataView dataView = dataTable.DefaultView;
            dataView.Sort = string.Join(" DESC, ", dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName)) + " DESC";
            DataTable reversedDataTable = dataView.ToTable();

            return reversedDataTable;
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

                TicketViewerForm ticketDetailsForm = new TicketViewerForm(ticketId, true);
                ticketDetailsForm.ShowDialog();
            }
        }

        private void gridManageTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gridManageTickets.Rows.Count)
            {
                int ticketId = Convert.ToInt32(gridManageTickets.Rows[e.RowIndex].Cells["ticket_id"].Value);

                TicketViewerForm ticketDetailsForm = new TicketViewerForm(ticketId, false);
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
                using (SqlCommand cmd = new SqlCommand("SELECT BUD.TotalTicketsWithStatus(2) AS ClosedTickets", connection))
                {
                    lblClosedTickets.Text = "Closed Tickets: " + cmd.ExecuteScalar().ToString();
                }

                // Tickets In Progress
                using (SqlCommand cmd = new SqlCommand("SELECT BUD.TotalTicketsWithStatus(3) AS TicketsInProgress", connection))
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
    }
}
