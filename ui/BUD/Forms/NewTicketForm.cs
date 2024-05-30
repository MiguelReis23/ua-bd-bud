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
        private List<Service> services;
        public NewTicketForm()
        {
            InitializeComponent();
            stepsTabs.SelectedIndex = 0;

            services = fetchServices(AuthenticatedUser.GetAuthenticatedUser().getHighestRole());

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
                            DrawFields(category);
                        }
                    }
                }
                stepsTabs.SelectedIndex = 2;
            }
        }

        private void DrawFields(Category category)
        {
            flowLayoutCommonDetails.Controls.Clear();
            
            string[] segmented_name = authenticatedUser.FullName.Split(' ');
            string first_name = segmented_name.GetValue(0).ToString();
            string last_name = segmented_name.GetValue(segmented_name.Length - 1).ToString();

            Field requester = new Field(Entities.InputType.FREE_TEXT, 0, "Requester");
            requester.Value = first_name + " " + last_name + " - " + AuthenticatedUser.GetAuthenticatedUser().Email;
            requester.ReadOnly = true;

            Field priority = new Field(Entities.InputType.DROPDOWN, 0, "Priority", "SELECT name FROM BUD.priority");


            flowLayoutCommonDetails.Controls.Add(requester);
            flowLayoutCommonDetails.Controls.Add(priority);

            flowLayoutDetails.Controls.Clear();

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

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}
