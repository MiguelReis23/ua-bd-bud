using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUD
{
    [Serializable()]
    public class User
    {
        private int _user_id;
        private string _full_name;
        private string _email;
        private int? _picture;
        private int[] _department_codes;
        private string[] _department_names;
        private int[] _role_ids;
        private string[] _role_names;
        private int[] _nmecs;
        private DateTime[] _role_begin_dates;
        private DateTime[] _role_end_dates;
        private DateTime[] _department_begin_dates;
        private DateTime[] _department_end_dates;

        public int UserId
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        public string FullName
        {
            get { return _full_name; }
            set { _full_name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int? Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        public int[] DepartmentCodes
        {
            get { return _department_codes; }
            set { _department_codes = value; }
        }

        public string[] DepartmentNames
        {
            get { return _department_names; }
            set { _department_names = value; }
        }

        public int[] RoleIds
        {
            get { return _role_ids; }
            set { _role_ids = value; }
        }

        public string[] RoleNames
        {
            get { return _role_names; }
            set { _role_names = value; }
        }

        public int[] Nmecs
        {
            get { return _nmecs; }
            set { _nmecs = value; }
        }

        public DateTime[] RoleBeginDates
        {
            get { return _role_begin_dates; }
            set { _role_begin_dates = value; }
        }

        public DateTime[] RoleEndDates
        {
            get { return _role_end_dates; }
            set { _role_end_dates = value; }
        }

        public DateTime[] DepartmentBeginDates
        {
            get { return _department_begin_dates; }
            set { _department_begin_dates = value; }
        }

        public DateTime[] DepartmentEndDates
        {
            get { return _department_end_dates; }
            set { _department_end_dates = value; }
        }

        public bool UserIdentifiesAs(string role_name)
        {
            return _role_names.Contains(role_name);
        }

        public int getHighestRole()
        {
            int highest_role = 0;
            foreach (int role in _role_ids)
            {
                if (role > highest_role)
                {
                    highest_role = role;
                }
            }
            return highest_role;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public User() : base() { }

        public User(int user_id, string full_name, string email, int picture, int[] department_codes, string[] department_names, int[] role_ids, string[] role_names, int[] nmecs, DateTime[] role_begin_dates, DateTime[] role_end_dates, DateTime[] department_begin_dates, DateTime[] department_end_dates)
        {
            _user_id = user_id;
            _full_name = full_name;
            _email = email;
            _picture = picture;
            _department_codes = department_codes;
            _department_names = department_names;
            _role_ids = role_ids;
            _role_names = role_names;
            _nmecs = nmecs;
            _role_begin_dates = role_begin_dates;
            _role_end_dates = role_end_dates;
            _department_begin_dates = department_begin_dates;
            _department_end_dates = department_end_dates;
        }
    }
}
