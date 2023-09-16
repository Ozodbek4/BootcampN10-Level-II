using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37Home1.Models
{
    internal class User
    {
        public User(string firstName, string lastName, string status)
        {
            FirstName = firstName;
            LastName = lastName;
            Status = status;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string Status { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}