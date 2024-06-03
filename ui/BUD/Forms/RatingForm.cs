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

namespace BUD.Forms
{
    public partial class RatingForm : Form
    {

        private int ticketId;
        public RatingForm(int ticketId)
        {
            InitializeComponent();
            this.ticketId = ticketId;
        }

        public int rated;

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int rating = 0;

            if (rd0.Checked)
            {
                rating = 0;
            }
            else if (rd1.Checked)
            {
                rating = 1;
            }
            else if (rd2.Checked)
            {
                rating = 2;
            }
            else if (rd3.Checked)
            {
                rating = 3;
            }
            else if (rd4.Checked)
            {
                rating = 4;
            }
            else if (rd5.Checked)
            {
                rating = 5;
            }
            else
            {
                MessageBox.Show("Please select a rating.");
                return;
            }

            string connectionString = Database.GetDatabase().GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SetTicketRating", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ticket_id", this.ticketId));
                    command.Parameters.Add(new SqlParameter("@rating", rating));

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnValue);

                 
                        connection.Open();
                        command.ExecuteNonQuery();
                        int result = (int)returnValue.Value;

                        if (result == 1)
                        {
                            MessageBox.Show("Rating updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rated = rating;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update rating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    
               
                }
            }
        }

        private void RatingForm_Load(object sender, EventArgs e)
        {
            rd0.Checked = false;
            rd1.Checked = false;
            rd2.Checked = false;
            rd3.Checked = false;
            rd4.Checked = false;
            rd5.Checked = false;
        }
    }
}
