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
            AddRoleLabels();

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
            if (user.DepartmentCodes == null || user.DepartmentCodes.ToArray().Length == 0)
            {
                Label label = new Label
                {
                    Text = "User is not associated with any department.",
                    AutoSize = false,
                    Width = 557,
                    Height = 95,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 9.75f)
                };

                flowLayoutPanel2.Controls.Add(label);
                return;
            }

            for (int i = 0; i < user.DepartmentCodes.ToArray().Length; i++)
            {
                string departmentName = user.DepartmentNames[i];
                string beginDate = user.DepartmentBeginDates[i].Value.ToString("dd-MM-yyyy");
                string endDate = null;

                string labelText = "";

                if (user.DepartmentEndDates[i].HasValue)
                {
                    endDate = user.DepartmentEndDates[i].Value.ToString("dd-MM-yyyy");
                    labelText = $"User was associated with {departmentName} from {beginDate} to {endDate}.";
                } else
                {
                    labelText = $"User is associated with {departmentName} since {beginDate}.";
                }

                Label label = new Label
                {
                    Text = labelText,
                    AutoSize = false,
                    Width = 557,
                    Height = 50,
                    Top = 5,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Microsoft Sans Serif", 9.50f),
                    BorderStyle = BorderStyle.FixedSingle,
                };

                flowLayoutPanel2.Controls.Add(label);
            }
        }

        private void AddRoleLabels()
        {
            if (user.RoleIds == null || user.RoleIds.Length == 0)
            {
                Label label = new Label
                {
                    Text = "User is not associated with any role.",
                    AutoSize = false,
                    Width = 557,
                    Height = 95,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Microsoft Sans Serif", 9.75f)
                };

                flowLayoutPanel3.Controls.Add(label);
                return;
            }

            for (int i = 0; i < user.RoleIds.ToArray().Length; i++)
            {
                string roleName = user.RoleNames[i];
                int? nmec = user.Nmecs[i];
                string beginDate = user.RoleBeginDates[i].Value.ToString("dd-MM-yyyy");
                string endDate = null;

                string labelText = "";

                if (user.RoleEndDates[i].HasValue)
                {
                    endDate = user.RoleEndDates[i].Value.ToString("dd-MM-yyyy");
                    labelText = $"User was {roleName} from {beginDate} to {endDate}. (NMEC: {nmec})";
                }
                else
                {
                    labelText = $"User is {roleName} since {beginDate}. (NMEC: {nmec})";
                }

                Label label = new Label
                {
                    Text = labelText,
                    AutoSize = false,
                    Width = 557,
                    Height = 50,
                    Top = 5,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Microsoft Sans Serif", 9.50f),
                    BorderStyle = BorderStyle.FixedSingle,
                };

                flowLayoutPanel3.Controls.Add(label);
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

                    SavePictureToDatabase(dlg.FileName);
                }
            }

            this.dashboardForm.RefreshProfilePic();
        }
    }
}
