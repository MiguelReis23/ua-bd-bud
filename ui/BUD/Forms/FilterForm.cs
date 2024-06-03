using System;
using System.Collections;
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
    public partial class FilterForm : Form
    {
        private int selectedServiceId;
        private int selectedCategoryId;
        private int selectedStatusId;
        private int selectedPriorityId;

        public int SelectedServiceId { get => selectedServiceId; }
        public int SelectedCategoryId { get => selectedCategoryId; }
        public int SelectedStatusId { get => selectedStatusId; }
        public int SelectedPriorityId { get => selectedPriorityId; }
 
        public FilterForm()
        {
            InitializeComponent();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            selectedServiceId = (int)cmbService.SelectedValue;
            selectedCategoryId = (int)cmbCategory.SelectedValue;
            selectedStatusId = (int)cmbStatus.SelectedValue;
            selectedPriorityId = (int)cmbPriority.SelectedValue;

            this.Close();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cmbService.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbPriority.SelectedIndex = 0;

            selectedServiceId = -1;
            selectedCategoryId = -1;
            selectedStatusId = -1;
            selectedPriorityId = -1;
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            DataTable dtservice = new DataTable();
            DataTable dtcategory = new DataTable();
            DataTable dtstatus = new DataTable();
            DataTable dtpriority = new DataTable();

            using (SqlConnection connection = Database.GetDatabase().GetConnection())
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, name FROM BUD.service";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dtservice);
                    }
                }

                DataRow rowService = dtservice.NewRow();
                rowService["id"] = -1;
                rowService["name"] = "ANY";
                dtservice.Rows.InsertAt(rowService, 0);

                cmbService.DataSource = dtservice;
                cmbService.DisplayMember = "name";
                cmbService.ValueMember = "id";

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, name FROM BUD.category";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dtcategory);
                    }
                }

                DataRow rowCategory = dtcategory.NewRow();
                rowCategory["id"] = -1;
                rowCategory["name"] = "ANY";
                dtcategory.Rows.InsertAt(rowCategory, 0);

                cmbCategory.DataSource = dtcategory;
                cmbCategory.DisplayMember = "name";
                cmbCategory.ValueMember = "id";

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, name FROM BUD.status";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dtstatus);
                    }
                }

                DataRow rowStatus = dtstatus.NewRow();
                rowStatus["id"] = -1;
                rowStatus["name"] = "ANY";
                dtstatus.Rows.InsertAt(rowStatus, 0);

                cmbStatus.DataSource = dtstatus;
                cmbStatus.DisplayMember = "name";
                cmbStatus.ValueMember = "id";

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, name FROM BUD.priority";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dtpriority);
                    }
                }

                DataRow rowPriority = dtpriority.NewRow();
                rowPriority["id"] = -1;
                rowPriority["name"] = "ANY";
                dtpriority.Rows.InsertAt(rowPriority, 0);

                cmbPriority.DataSource = dtpriority;
                cmbPriority.DisplayMember = "name";
                cmbPriority.ValueMember = "id";
            }
        }

        private void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedServiceId;
            try {
                selectedServiceId  = (int)cmbService.SelectedValue;
            } catch (Exception ex)
            {
                return;
            }

            DataTable dtCategories = new DataTable();

            using (SqlConnection connection = Database.GetDatabase().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    if (selectedServiceId == -1)
                    {
                        command.CommandText = "SELECT id, name, description, minimum_role, service_id FROM BUD.category";
                    }
                    else
                    {
                        command.CommandText = "SELECT id, name, description, minimum_role, service_id FROM BUD.category WHERE service_id = @ServiceId";
                        command.Parameters.Add(new SqlParameter("@ServiceId", SqlDbType.Int)).Value = selectedServiceId;
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dtCategories);
                    }
                }
            }

            DataRow rowCategory = dtCategories.NewRow();
            rowCategory["id"] = -1;
            rowCategory["name"] = "ANY";
            dtCategories.Rows.InsertAt(rowCategory, 0);

            cmbCategory.DataSource = dtCategories;
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "id";
        }
    }
}
