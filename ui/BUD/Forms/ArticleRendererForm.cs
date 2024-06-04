using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BUD.Forms
{
    public partial class ArticleRendererForm : Form
    {
        private int _article_id;

        public int ArticleId => _article_id;

        public ArticleRendererForm(int article_id)
        {
            InitializeComponent();
            _article_id = article_id;

            LoadArticleDetails();
        }

        private void LoadArticleDetails()
        {
            using (SqlConnection connection = Database.GetDatabase().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT 
                            a.title,
                            a.author,
                            a.content,
                            a.[date],
                            s.[name] AS service_name
                        FROM 
                            BUD.article a
                        JOIN 
                            BUD.service s ON a.service_id = s.id
                        WHERE 
                            a.id = @article_id";

                    command.Parameters.AddWithValue("@article_id", _article_id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string title = reader.GetString(0);
                            string author = reader.GetString(1);
                            string content = reader.GetString(2);
                            DateTime date = reader.GetDateTime(3);
                            string serviceName = reader.GetString(4);

                            this.Text += title;
                            lblTitle.Text = title;
                            lblMetadata.Text = $"Published by {author} on {date:dd/MM/yyyy} regarding the service \"{serviceName}\"";
                            lblContent.Text = content;
                        }
                    }
                }
            }
        }
    }
}
