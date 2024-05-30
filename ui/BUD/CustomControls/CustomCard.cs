using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUD
{
    public partial class CustomCard : UserControl
    {
        private int _id;
        public CustomCard(string title, string description, int id)
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblDescription.Text = description;
            _id = id;
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
