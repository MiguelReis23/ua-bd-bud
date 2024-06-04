using System;
using System.Linq;
using System.Windows.Forms;

namespace BUD.CustomControls
{
    public partial class ArticleCard : UserControl
    {
        private int _article_id;
        private string _title;
        private string _content;
        private string _author;
        private DateTime _date_published;
        private string _service;

        public int ArticleId => _article_id;


        public ArticleCard(int article_id, string title, string content, string author, DateTime date_published, string service)
        {
            InitializeComponent();
            _article_id = article_id;
            _title = title;
            _content = content;
            _author = author;
            _date_published = date_published;
            _service = service;

            lblTitle.Text = title;
            lblContent.Text = content.Split(' ').Length > 50 ? string.Join(" ", content.Split(' ').Take(50)) + "..." : content;
            lblService.Text = "Service: " + service;
            lblAuthor.Text = "Published by: " + author + " on " + date_published.ToString("dd/MM/yyyy");
        }
    }
}
