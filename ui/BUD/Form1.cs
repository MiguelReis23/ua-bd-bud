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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BUD
{
    public partial class Form1 : Form
    {
        public Form1()
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
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
