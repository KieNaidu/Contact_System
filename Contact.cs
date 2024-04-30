using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_System
{
    public class Contact
    {

        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CellNumber { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Active { get; set; }

        // Constructor
        public Contact()
        {
        }

        public Contact(int id, int categoryId, string firstName, string lastName, DateTime? dateOfBirth, string cellNumber, string email, byte[] image, DateTime dateCreated, bool active)
        {
            ID = id;
            CategoryID = categoryId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            CellNumber = cellNumber;
            Email = email;
            Image = image;
            DateCreated = dateCreated;
            Active = active;
        }
    }
}
