using BUD.CustomControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace BUD
{
    public partial class NewTicketForm : Form
    {
        User authenticatedUser = AuthenticatedUser.GetAuthenticatedUser();
        DashboardForm dashboardFormRef;
        private List<Service> services;
        public NewTicketForm(DashboardForm dashboardForm)
        {
            InitializeComponent();
            stepsTabs.SelectedIndex = 0;

            services = fetchServices(AuthenticatedUser.GetAuthenticatedUser().getHighestRole());
            dashboardFormRef = dashboardForm;

            drawServices();
        }

        private void ApplyEventRecursive(Control parent_control, EventHandler eventHandler)
        {
            foreach (Control control in parent_control.Controls)
            {
                control.Tag = parent_control;
                control.Click += eventHandler;
                ApplyEventRecursive(control, eventHandler);
            }

            parent_control.Click += eventHandler;
        }

        private void drawServices()
        {
            flowLayoutCategory.Controls.Clear();

            foreach (Service service in services)
            {
                CustomCard card = new CustomCard(service.ServiceName, service.ServiceDescription, service.ServiceId);
                ApplyEventRecursive(card, ServiceCard_Click);

                flowLayoutService.Controls.Add(card);
            }
        }

        private void ServiceCard_Click(object sender, EventArgs e)
        {
            flowLayoutDetails.Controls.Clear();

            Control clickedControl = sender as Control;
            CustomCard card = null;

            while (clickedControl != null && !(clickedControl is CustomCard))
            {
                clickedControl = clickedControl.Parent;
            }

            if (clickedControl is CustomCard)
            {
                card = (CustomCard)clickedControl;
            }

            if (card != null)
            {
                int serviceId = card.ID;

                foreach (Service service in services)
                {
                    if (service.ServiceId == serviceId)
                    {
                        DrawCategory(service);
                    }
                }
                stepsTabs.SelectedIndex = 1;
            }
        }

        private void DrawCategory(Service service)
        {
            flowLayoutCategory.Controls.Clear();

            foreach (Category category in service.Categories)
            {
                CustomCard card = new CustomCard(category.CategoryName, category.Description, category.CategoryId);
                ApplyEventRecursive(card, CategoryCard_Click);

                flowLayoutCategory.Controls.Add(card);
            }
            
        }

        private CustomCard selectedCategoryCard = null;

        private void CategoryCard_Click(object sender, EventArgs e)
        {
            Control clickedControl = sender as Control;
            CustomCard card = null;

            while (clickedControl != null && !(clickedControl is CustomCard))
            {
                clickedControl = clickedControl.Parent;
            }

            if (clickedControl is CustomCard)
            {
                card = (CustomCard)clickedControl;
            }

            if (card != null)
            {
                int categoryId = card.ID;

                foreach (Service service in services)
                {
                    foreach (Category category in service.Categories)
                    {
                        if (category.CategoryId == categoryId)
                        {
                            this.catId = categoryId;

                            foreach (Control control in flowLayoutCategory.Controls)
                            {
                                if (control is CustomCard)
                                {
                                    ((CustomCard)control).BorderStyle = BorderStyle.None;
                                }
                            }

                            card.BorderStyle = BorderStyle.FixedSingle;
                            selectedCategoryCard = card;

                            DrawFields(category);
                            btnSubmit.Enabled = true;
                            break;
                        }
                    }
                }
                stepsTabs.SelectedIndex = 2;
            }
        }

        private Field requester = new Field(Entities.InputType.FREE_TEXT, 0, "Requester");
        private Field priority = new Field(Entities.InputType.DROPDOWN, 0, "Priority", "SELECT name FROM BUD.priority");
        private int? catId = null;

        private void DrawFields(Category category)
        {
            flowLayoutDetails.Controls.Clear();
            
            string[] segmented_name = authenticatedUser.FullName.Split(' ');
            string first_name = segmented_name.GetValue(0).ToString();
            string last_name = segmented_name.GetValue(segmented_name.Length - 1).ToString();

            requester.Value = first_name + " " + last_name + " - " + AuthenticatedUser.GetAuthenticatedUser().Email;
            requester.ReadOnly = true;

            flowLayoutDetails.Controls.Add(requester);
            flowLayoutDetails.Controls.Add(priority);

            foreach (Field field in category.Fields)
            {
                flowLayoutDetails.Controls.Add(field);
            }
        }

        private List<Service> fetchServices(int role_id)
        {
            List<Service> services = new List<Service>();

            using (SqlConnection connection = Database.GetDatabase().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT 
                            service_id, service_name, service_description, 
                            category_id, category_name, category_description, category_minimum_role,
                            field_id, field_name
                        FROM 
                            BUD.ServiceCategoriesFields 
                        WHERE 
                            category_minimum_role <= @RoleId";
                    command.Parameters.Add(new SqlParameter("@RoleId", SqlDbType.Int)).Value = role_id;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Dictionary<int, Service> serviceDict = new Dictionary<int, Service>();

                        while (reader.Read())
                        {
                            int serviceId = reader.GetInt32(reader.GetOrdinal("service_id"));
                            string serviceName = reader.GetString(reader.GetOrdinal("service_name"));
                            string serviceDescription = reader.GetString(reader.GetOrdinal("service_description"));
                            int categoryId = reader.GetInt32(reader.GetOrdinal("category_id"));
                            string categoryName = reader.GetString(reader.GetOrdinal("category_name"));
                            string categoryDescription = reader.GetString(reader.GetOrdinal("category_description"));
                            int categoryMinimumRole = reader.GetInt32(reader.GetOrdinal("category_minimum_role"));
                            int fieldId = reader.GetInt32(reader.GetOrdinal("field_id"));
                            string fieldName = reader.GetString(reader.GetOrdinal("field_name"));

                            if (!serviceDict.ContainsKey(serviceId))
                            {
                                serviceDict[serviceId] = new Service(serviceId, serviceName, serviceDescription);
                            }

                            Service service = serviceDict[serviceId];
                            Category category = service.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
                            if (category == null)
                            {
                                category = new Category(categoryId, categoryName, categoryDescription, categoryMinimumRole);
                                service.AddCategory(category);
                            }

                            category.AddField(fieldId, fieldName);
                        }

                        services.AddRange(serviceDict.Values);
                    }
                }
            }

            return services;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            flowLayoutDetails.Controls.Clear();
            stepsTabs.SelectedIndex = 0;
        }

        private void stepsTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stepsTabs.SelectedIndex == 0)
            {
                drawServices();
                btnPrevious.Enabled = false;
                btnSubmit.Enabled = false;
            } else if (stepsTabs.SelectedIndex == 1)
            {
                btnPrevious.Enabled = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int? requesterId = authenticatedUser.UserId;
            int? priorityId = 0;
            int? categoryId = catId;

            if (flowLayoutDetails.Controls.Count >= 2)
            {
                Control secondControl = flowLayoutDetails.Controls[1];
                if (secondControl is Field secondField)
                {
                    priorityId = secondField.ValueIndex;
                }
            }

            List<Field> fields = new List<Field>();

            foreach (Control control in flowLayoutDetails.Controls.Cast<Control>().Skip(2))
            {
                if (control is Field field)
                {
                    fields.Add(field);
                }
            }

            // Checks for invalid fields or empty fields
            if (requesterId == null || priorityId < 0 || categoryId == null)
            {
                MessageBox.Show("Please fill in all fields.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Field field in fields)
            {
                if (field.Value == null || field.Value == "")
                {
                    MessageBox.Show("Please fill in all fields.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Console.WriteLine("Requester ID: " + requesterId);
            Console.WriteLine("Priority ID: " + priorityId);
            Console.WriteLine("Category ID: " + categoryId);
            foreach (Field field in fields)
            {
                Console.WriteLine(field.FieldName + ": " + field.Value);
            }

            using (SqlConnection connection = Database.GetDatabase().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand()) {
                    command.CommandText = "CreateTicket";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@requester_id", requesterId);
                    command.Parameters.AddWithValue("@priority_id", priorityId);
                    command.Parameters.AddWithValue("@category_id", categoryId);

                    DataTable fieldsTable = new DataTable();
                    fieldsTable.Columns.Add("field_id", typeof(int));
                    fieldsTable.Columns.Add("value", typeof(string));

                    foreach (Field field in fields)
                    {
                        fieldsTable.Rows.Add(field.FieldId, field.Value);
                    }

                    SqlParameter tvpParam = command.Parameters.AddWithValue("@fields", fieldsTable);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "ticket_fieldtype";

                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Ticket created successfully.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dashboardFormRef.LoadUserTickets();
                    this.Close();
                }
            }
        }

        private void NewTicketForm_Load(object sender, EventArgs e)
        {

        }
    }
}
