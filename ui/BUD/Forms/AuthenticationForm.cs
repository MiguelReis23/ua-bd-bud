using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BUD
{
    public partial class AuthenticationForm : Form
    {
        public AuthenticationForm()
        {
            InitializeComponent();
        }

        private void btnAuthenticate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter a username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = Database.GetDatabase().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "AuthenticateUser";
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 128)).Value = username;
                    command.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 255)).Value = password;

                    SqlParameter resultParam = new SqlParameter("@Result", SqlDbType.Int);
                    resultParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(resultParam);

                    connection.Open();
                    command.ExecuteNonQuery();

                    int result = (int)resultParam.Value;

                    if (result > 0)
                    {
                        MessageBox.Show("Authentication successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SetAuthenticatedUserData(result);

                        DashboardForm dashboardForm = new DashboardForm(this);
                        dashboardForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        txtUsername.Clear();
                        txtPassword.Clear();
                        MessageBox.Show("Invalid email or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    txtUsername.Clear();
                    txtPassword.Clear();
                }
            }
        }

        private void SetAuthenticatedUserData(int user_id)
        {
            using (SqlConnection connection = Database.GetDatabase().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM BUD.UserInfo WHERE user_id = @UserId";
                    command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int)).Value = user_id;

                    connection.Open();
                    command.ExecuteNonQuery();

                    var authenticatedUser = AuthenticatedUser.GetAuthenticatedUser();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var departmentCodes = new List<int?>();
                        var departmentNames = new List<string>();
                        var roleIds = new List<int?>();
                        var roleNames = new List<string>();
                        var nmecs = new List<int?>();
                        var roleBeginDates = new List<DateTime?>();
                        var roleEndDates = new List<DateTime?>();
                        var departmentBeginDates = new List<DateTime?>();
                        var departmentEndDates = new List<DateTime?>();

                        while (reader.Read())
                        {
                            authenticatedUser.UserId = reader.GetInt32(reader.GetOrdinal("user_id"));
                            authenticatedUser.FullName = reader.GetString(reader.GetOrdinal("full_name"));
                            authenticatedUser.Email = reader.GetString(reader.GetOrdinal("email"));
                            authenticatedUser.Picture = reader.IsDBNull(reader.GetOrdinal("picture")) ? null : (int?)reader.GetInt32(reader.GetOrdinal("picture"));

                            if (!reader.IsDBNull(reader.GetOrdinal("department_code")))
                                departmentCodes.Add(reader.GetInt32(reader.GetOrdinal("department_code")));
                            else
                                departmentCodes.Add(null);

                            if (!reader.IsDBNull(reader.GetOrdinal("department_name")))
                                departmentNames.Add(reader.GetString(reader.GetOrdinal("department_name")));
                            else
                                departmentNames.Add(null);

                            if (!reader.IsDBNull(reader.GetOrdinal("role_id")))
                                roleIds.Add(reader.GetInt32(reader.GetOrdinal("role_id")));
                            else
                                roleIds.Add(null);

                            if (!reader.IsDBNull(reader.GetOrdinal("role_name")))
                                roleNames.Add(reader.GetString(reader.GetOrdinal("role_name")));
                            else
                                roleNames.Add(null);

                            if (!reader.IsDBNull(reader.GetOrdinal("nmec")))
                                nmecs.Add(reader.GetInt32(reader.GetOrdinal("nmec")));
                            else
                                nmecs.Add(null);

                            if (!reader.IsDBNull(reader.GetOrdinal("role_begin_date")))
                                roleBeginDates.Add(reader.GetDateTime(reader.GetOrdinal("role_begin_date")));
                            else
                                roleBeginDates.Add(null);

                            if (!reader.IsDBNull(reader.GetOrdinal("role_end_date")))
                                roleEndDates.Add(reader.GetDateTime(reader.GetOrdinal("role_end_date")));
                            else
                                roleEndDates.Add(null);

                            if (!reader.IsDBNull(reader.GetOrdinal("department_startdate")))
                                departmentBeginDates.Add(reader.GetDateTime(reader.GetOrdinal("department_startdate")));
                            else
                                departmentBeginDates.Add(null);

                            if (!reader.IsDBNull(reader.GetOrdinal("department_enddate")))
                                departmentEndDates.Add(reader.GetDateTime(reader.GetOrdinal("department_enddate")));
                            else
                                departmentEndDates.Add(null);

                        }
                        authenticatedUser.DepartmentCodes = departmentCodes.ToArray();
                        authenticatedUser.DepartmentNames = departmentNames.ToArray();
                        authenticatedUser.RoleIds = roleIds.ToArray();
                        authenticatedUser.RoleNames = roleNames.ToArray();
                        authenticatedUser.Nmecs = nmecs.ToArray();
                        authenticatedUser.RoleBeginDates = roleBeginDates.ToArray();
                        authenticatedUser.RoleEndDates = roleEndDates.ToArray();
                        authenticatedUser.DepartmentBeginDates = departmentBeginDates.ToArray();
                        authenticatedUser.DepartmentEndDates = departmentEndDates.ToArray();
                    }
                }
            }
        }
    }
}
