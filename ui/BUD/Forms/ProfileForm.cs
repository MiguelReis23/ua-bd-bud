using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BUD.Forms
{
    public partial class ProfileForm : Form
    {
        private User user;
        private DashboardForm dashboardForm;

        public ProfileForm(User user, DashboardForm dashboardForm)
        {
            InitializeComponent();

            this.user = user;
            this.dashboardForm = dashboardForm;

            lblUserId.Text = user.UserId.ToString();
            lblFullName.Text = user.FullName;
            lblEmail.Text = user.Email;

            if (user.Picture != null)
            {
                RetrieveAndDisplayPicture(user.Picture);
            }

            AddDepartmentLabels();

            Console.WriteLine("User ID: " + user.UserId);
            Console.WriteLine("Full Name: " + user.FullName);
            Console.WriteLine("Email: " + user.Email);
            Console.WriteLine("Picture: " + user.Picture);
            Console.WriteLine("Department Codes: " + string.Join(", ", user.DepartmentCodes));
            Console.WriteLine("Department Names: " + string.Join(", ", user.DepartmentNames));
            Console.WriteLine("Role IDs: " + string.Join(", ", user.RoleIds));
            Console.WriteLine("Role Names: " + string.Join(", ", user.RoleNames));
            Console.WriteLine("NMECs: " + string.Join(", ", user.Nmecs));
            Console.WriteLine("Role Begin Dates: " + string.Join(", ", user.RoleBeginDates));
            Console.WriteLine("Role End Dates: " + string.Join(", ", user.RoleEndDates));
        }

        private void RetrieveAndDisplayPicture(int? pictureId)
        {
            using (SqlConnection connection = Database.GetDatabase().GetConnection())
            {
                using (SqlCommand command = new SqlCommand("GetUserPicture", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", user.UserId);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        byte[] pictureData = (byte[])result;

                        using (MemoryStream ms = new MemoryStream(pictureData))
                        {
                            pbPicture.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        // Optionally, handle the case where there is no picture
                        pbPicture.Image = null;
                    }
                }
            }
        }

        private void SavePictureToDatabase(string filePath)
        {
            byte[] pictureData;

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    pictureData = br.ReadBytes((int)fs.Length);
                }
            }

            using (SqlConnection connection = Database.GetDatabase().GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.CommandText = "SetUserPicture";
                            command.Parameters.AddWithValue("@UserId", user.UserId);
                            command.Parameters.AddWithValue("@PictureData", pictureData);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("An error occurred while saving the picture: " + ex.Message);
                    }
                }
            }
        }

        private void AddDepartmentLabels()
        {
            for (int i = 0; i < user.DepartmentCodes.ToArray().Length; i++)
            {
                string departmentName = user.DepartmentNames[i];
                string beginDate = user.DepartmentBeginDates[i].ToString("yyyy-MM-dd");
                //string endDate = user.DepartmentEndDates[i]?.ToString("yyyy-MM-dd") ?? "present";

                string endDate = "";

                string labelText = $"User is/was associated with {departmentName} from {beginDate} to {endDate}";
                Label label = new Label
                {
                    Text = labelText,
                    AutoSize = true
                };

                flowLayoutPanel1.Controls.Add(label);
            }
        }

        private void btnChangePic_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files(*.PNG;*.JPG;*.JPEG)|*.PNG;*.JPG;*.JPEG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pbPicture.Image = new Bitmap(dlg.FileName);

                    // Save the new picture to the database
                    SavePictureToDatabase(dlg.FileName);
                }
            }

            this.dashboardForm.RefreshProfilePic();
        }
    }
}
