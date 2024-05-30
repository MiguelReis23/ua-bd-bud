using BUD.Entities;
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

namespace BUD.CustomControls
{
    public partial class Field : UserControl
    {

        private InputType _inputType;
        private int _field_id;
        private string _field_name;
        private Boolean _readonly;

        public Field(InputType inputType,int field_id, string name, string query = null)
        {
            InitializeComponent();

            this._inputType = inputType;
            this._field_id = field_id;
            this._field_name = name;

            label.Text = name;

            if (inputType == InputType.FREE_TEXT)
            {
                cmbSel.Visible = false;
                txtFree.Visible = true;
            }
            else if (inputType == InputType.DROPDOWN)
            {
                fetchData(query);
                txtFree.Visible = false;
                cmbSel.Visible = true;
            }
        }

        public Field()
        {
            InitializeComponent();

            this._inputType = InputType.FREE_TEXT;
        }

        public InputType InputType
        {
            get { return _inputType; }
            set { _inputType = value; }
        }

        public string FieldName
        {
            get { return _field_name; }
            set { _field_name = value; }
        }

        public int FieldId
        {
            get { return _field_id; }
            set { _field_id = value; }
        }

        public Boolean ReadOnly
        {
            get { return _readonly; }
            set
            {
                _readonly = value;
                txtFree.ReadOnly = value;
                cmbSel.Enabled = !value;
            }
        }


        public string Value
        {
            get
            {
                if (_inputType == InputType.FREE_TEXT)
                {
                    return txtFree.Text;
                }
                else if (_inputType == InputType.DROPDOWN)
                {
                    if (cmbSel.SelectedItem == null)
                    {
                        return null;
                    }
                    return cmbSel.SelectedItem.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (_inputType == InputType.FREE_TEXT)
                {
                    txtFree.Text = value;
                }
                else if (_inputType == InputType.DROPDOWN)
                {
                    cmbSel.SelectedItem = value;
                }
            }
        }

        public int ValueIndex
        {
            get
            {
                return cmbSel.SelectedIndex + 1;
            }
            set
            {
                cmbSel.SelectedIndex = value;
            }
        }

        private Service[] fetchData(string query)
        {
            List<Service> services = new List<Service>();

            using (SqlConnection connection = Database.GetDatabase().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbSel.Items.Add(reader[0].ToString());
                        }
                    }
                }
            }

            return services.ToArray();
        }

        
    }
}
