using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUD
{
    internal class Service
    {
        private int _service_id;
        private string _service_name;
        private string _service_description;

        private List<Category> _categories = new List<Category>();

        public Service(int service_id, string service_name, string service_description)
        {
            _service_id = service_id;
            _service_name = service_name;
            _service_description = service_description;
        }

        public int ServiceId
        {
            get { return _service_id; }
            set { _service_id = value; }
        }

        public string ServiceName
        {
            get { return _service_name; }
            set { _service_name = value; }
        }

        public string ServiceDescription
        {
            get { return _service_description; }
            set { _service_description = value; }
        }

        public List<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }
    }
}
