using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void btnManageTickets_Click(object sender, EventArgs e)
        {
            sectionsTabs.SelectTab(1);
        }

        private void btnNewTicket_Click(object sender, EventArgs e)
        {
            new NewTicketForm().ShowDialog();
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
    }
}
