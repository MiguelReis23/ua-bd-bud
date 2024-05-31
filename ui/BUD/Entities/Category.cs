using BUD.CustomControls;
using BUD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUD
{
    internal class Category
    {
        private int __id;
        private string _name;
        private string _description;
        private int _minimum_role;

        private List<Field> _fields = new List<Field>();

        public Category(int id, string name, string description, int minimum_role)
        {
            __id = id;
            _name = name;
            _description = description;
            _minimum_role = minimum_role;
        }

        public int CategoryId
        {
            get { return __id; }
            set { __id = value; }
        }

        public string CategoryName
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int MinimumRole
        {
            get { return _minimum_role; }
            set { _minimum_role = value; }
        }

        public List<Field> Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }

        public void AddField(int field_id, string field_name)
        {
            switch (field_id)
            {
                case 1:
                    _fields.Add(new Field(InputType.DROPDOWN, field_id, field_name, "SELECT name FROM BUD.department"));
                    break;
                case 17:
                    _fields.Add(new Field(InputType.DROPDOWN, field_id, field_name, "SELECT name FROM BUD.room"));
                    break;
                default:
                    _fields.Add(new Field(InputType.FREE_TEXT, field_id, field_name));
                    break;
            }
        }
    }
}
