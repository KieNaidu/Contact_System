using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_System
{
    public class Category
    {
        // Constructor
        public Category()
        {
        }

        public Category(int id, string name, bool active)
        {
            ID = id;
            Name = name;
            Active = active;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

    }
}
