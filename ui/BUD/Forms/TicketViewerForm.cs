using System;
using System.Collections.Generic;
using BUD.CustomControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUD.Entities;

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

        public TicketViewerForm(int ticketId, bool readOnly = true)
        {
            InitializeComponent();
            this.ticketId = ticketId;
            FetchTicketFields(ticketId);
            DrawCommonFields();
            DrawFields(readOnly);

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
                            fieldControl.Value = fieldValue;
                            fields.Add(fieldControl);
                        }
                    }
                }
            }
        }

        private void DrawCommonFields()
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

            Field priorityField = new Field(InputType.FREE_TEXT, 0, "Priority")
            {
                Value = priority,
                ReadOnly = true
            };
            flowLayoutDetails.Controls.Add(priorityField);

            Field statusField = new Field(InputType.FREE_TEXT, 0, "Status")
            {
                Value = status,
                ReadOnly = true
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
                field.ReadOnly = readOnly;
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
            // Update logic here
        }
    }
}
