using System;
using System.Collections.Generic;
using BUD.CustomControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUD.Entities;
using System.Linq;
using System.Data;

namespace BUD.Forms
{
    public partial class TicketViewerForm : Form
    {
        List<Field> fields = new List<Field>();
        private int ticketId;
        private string requester;
        private string responsible;
        private DateTime submitDate;
        private DateTime? closedDate;
        private string priority;
        private string status;
        private string category;
        private int? rating;

        private bool readOnlyref;

        DashboardForm dashboardFormRef;

        public TicketViewerForm(DashboardForm dashboardForm, int ticketId, bool readOnly = true)
        {
            InitializeComponent();

            this.readOnlyref = readOnly;

            this.ticketId = ticketId;
            FetchTicketFields(ticketId);
            DrawCommonFields(readOnly);
            DrawFields(readOnly);

            dashboardFormRef = dashboardForm;

            if (readOnly)
            {
                Text += " - View Ticket";
                btnUpdate.Visible = false;
                btnUpdate.Enabled = false;
            }
            else
            {
                Text += " - Update Ticket";
                btnUpdate.Visible = true;
                btnUpdate.Enabled = true;
            }

            DrawMessages();
        }

        private void FetchTicketFields(int ticketId)
        {
            using (SqlConnection connection = Database.GetDatabase().GetConnection())
            {
                // Fetch common ticket details
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT 
                            t.requester_id, 
                            (SELECT full_name FROM BUD.[user] WHERE id = t.requester_id) AS requester,
                            t.responsible_id,
                            (SELECT full_name FROM BUD.[user] WHERE id = t.responsible_id) AS responsible,
                            t.submit_date, 
                            t.closed_date,
                            t.rating,
                            s.[name] AS status,
                            p.[name] AS priority,
                            c.[name] AS category
                        FROM 
                            BUD.ticket t
                            JOIN BUD.status s ON t.status_id = s.id
                            JOIN BUD.priority p ON t.priority_id = p.id
                            JOIN BUD.category c ON t.category_id = c.id
                        WHERE 
                            t.id = @ticketId
                    ";

                    command.Parameters.AddWithValue("@ticketId", ticketId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            requester = reader["requester"].ToString();
                            responsible = reader["responsible"].ToString();
                            submitDate = reader.GetDateTime(reader.GetOrdinal("submit_date"));
                            closedDate = reader.IsDBNull(reader.GetOrdinal("closed_date")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("closed_date"));
                            rating = reader.IsDBNull(reader.GetOrdinal("rating")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("rating"));
                            status = reader["status"].ToString();
                            priority = reader["priority"].ToString();
                            category = reader["category"].ToString();
                        }
                    }
                }

                // Fetch ticket fields
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT 
                            tf.field_id, 
                            f.name, 
                            tf.value 
                        FROM 
                            BUD.ticket_field tf
                            JOIN BUD.field f ON tf.field_id = f.id
                        WHERE 
                            tf.ticket_id = @ticketId
                    ";

                    command.Parameters.AddWithValue("@ticketId", ticketId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int fieldId = reader.GetInt32(0);
                            string fieldName = reader.GetString(1);
                            string fieldValue = reader.GetString(2);

                            Field fieldControl;
                            if (fieldId == 1) // Example condition for dropdown field
                            {
                                fieldControl = new Field(InputType.DROPDOWN, fieldId, fieldName, "SELECT name FROM BUD.department");
                            }
                            else
                            {
                                fieldControl = new Field(InputType.FREE_TEXT, fieldId, fieldName);
                            }
                            fieldControl.ReadOnly = true;
                            fieldControl.Value = fieldValue;
                            fields.Add(fieldControl);
                        }
                    }
                }
            }

            if (this.readOnlyref) CheckAskForRate();
        }

        private void CheckAskForRate()
        {
            if (status == "Closed" && !rating.HasValue)
            {
                DialogResult result = MessageBox.Show("Would you like to rate this ticket?", "Rate Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    RatingForm ratingForm = new RatingForm(ticketId);
                    ratingForm.ShowDialog();
                    this.rating = ratingForm.rated;
                }
            }
        }

        private void DrawCommonFields(Boolean readOnly = false)
        {
            Field requesterField = new Field(InputType.FREE_TEXT, 0, "Requester")
            {
                Value = requester,
                ReadOnly = true
            };
            flowLayoutDetails.Controls.Add(requesterField);

            Field responsibleField = new Field(InputType.FREE_TEXT, 0, "Responsible")
            {
                Value = responsible,
                ReadOnly = true
            };
            flowLayoutDetails.Controls.Add(responsibleField);

            Field submitDateField = new Field(InputType.FREE_TEXT, 0, "Submit Date")
            {
                Value = submitDate.ToString("g"),
                ReadOnly = true
            };
            flowLayoutDetails.Controls.Add(submitDateField);

            Field closedDateField = new Field(InputType.FREE_TEXT, 0, "Closed Date")
            {
                Value = closedDate.HasValue ? closedDate.Value.ToString("g") : "N/A",
                ReadOnly = true
            };
            flowLayoutDetails.Controls.Add(closedDateField);

            Field priorityField = new Field(InputType.DROPDOWN, 0, "Priority", "SELECT name FROM BUD.priority")
            {
                Value = priority,
                ReadOnly = readOnly
            };
            flowLayoutDetails.Controls.Add(priorityField);

            Field statusField = new Field(InputType.DROPDOWN, 0, "Status", "SELECT name FROM BUD.status")
            {
                Value = status,
                ReadOnly = readOnly
            };
            flowLayoutDetails.Controls.Add(statusField);

            Field categoryField = new Field(InputType.FREE_TEXT, 0, "Category")
            {
                Value = category,
                ReadOnly = true
            };
            flowLayoutDetails.Controls.Add(categoryField);

            Field ratingField = new Field(InputType.FREE_TEXT, 0, "Rating")
            {
                Value = rating.HasValue ? rating.Value.ToString() : "N/A",
                ReadOnly = true
            };
            flowLayoutDetails.Controls.Add(ratingField);
        }

        private void DrawFields(bool readOnly = true)
        {
            foreach (Field field in fields)
            {
                field.ReadOnly = true;
                flowLayoutDetails.Controls.Add(field);
            }
        }

        private void TicketViewerForm_Load(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int? responsibleId = AuthenticatedUser.GetAuthenticatedUser().UserId;
            int? priorityId = 0;
            int? statusId = 0;
            int ticketId = this.ticketId;

            if (flowLayoutDetails.Controls.Count >= 7)
            {
                Control priorityControl = flowLayoutDetails.Controls[4];
                if (priorityControl is Field fifthField)
                {
                    priorityId = fifthField.ValueIndex;
                }

                Control statusControl = flowLayoutDetails.Controls[5];
                if (statusControl is Field sixthField)
                {
                    statusId = sixthField.ValueIndex;
                }
            }

            using (SqlConnection conn = new SqlConnection(Database.GetDatabase().GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateTicket", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ticket_id", ticketId);
                    cmd.Parameters.AddWithValue("@status_id", (object)statusId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@priority_id", (object)priorityId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@responsible_id", (object)responsibleId ?? DBNull.Value);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            Console.WriteLine("Ticket updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Ticket update failed.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            dashboardFormRef.LoadAllTickets();
        }

        private void DrawMessages()
        {
            messagesLayout.Controls.Clear();

            using (SqlConnection connection = new SqlConnection(Database.GetDatabase().GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("GetMessagesByTicket", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ticket_id", ticketId));

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Control> messages = new List<Control>();

                        while (reader.Read())
                        {
                            int messageId = reader.GetInt32(reader.GetOrdinal("message_id"));
                            int senderId = reader.GetInt32(reader.GetOrdinal("sender_id"));
                            string content = reader.GetString(reader.GetOrdinal("content"));
                            DateTime timeStamp = reader.GetDateTime(reader.GetOrdinal("time_stamp"));

                            string fileName = reader.IsDBNull(reader.GetOrdinal("file_name")) ? null : reader.GetString(reader.GetOrdinal("file_name"));
                            byte[] data = reader.IsDBNull(reader.GetOrdinal("data")) ? null : (byte[])reader["data"];

                            Label message = new Label
                            {
                                Text = content,
                                AutoSize = false,
                                Width = 370,
                                Height = 33,
                                Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                                TextAlign = senderId == AuthenticatedUser.GetAuthenticatedUser().UserId ? System.Drawing.ContentAlignment.MiddleRight : System.Drawing.ContentAlignment.MiddleLeft
                            };

                            messages.Add(message);

                            if (fileName != null)
                            {
                                Console.WriteLine($"Attachment File Name: {fileName}");
                                Console.WriteLine($"Attachment Data: {BitConverter.ToString(data)}");
                            }

                            Console.WriteLine();
                        }

                        foreach (var message in messages)
                        {
                            messagesLayout.Controls.Add(message);
                        }
                    }
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Message cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int senderId = AuthenticatedUser.GetAuthenticatedUser().UserId;
            int ticketId = this.ticketId;
            string connectionString = Database.GetDatabase().GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SendMessage", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add(new SqlParameter("@sender_id", senderId));
                    command.Parameters.Add(new SqlParameter("@ticket_id", ticketId));
                    command.Parameters.Add(new SqlParameter("@content", message));

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnValue);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        int result = (int)returnValue.Value;

                        if (result != 1)
                        {
                            MessageBox.Show("Failed to send message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            DrawMessages();
            txtMessage.Clear();
        }

        private void TicketViewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dashboardFormRef.LoadAllTickets();
            dashboardFormRef.LoadUserTickets();
        }
    }
}
