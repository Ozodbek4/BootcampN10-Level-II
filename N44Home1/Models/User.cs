using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N44Home2.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsNeighbor { get; set; }

        public User(int id, string firstName, string lastName, string email, bool isNeighbor)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IsNeighbor = isNeighbor;
        }

        public override string ToString()
        {
            return $"FirstName: {FirstName}\n" +
                $"LastName: {LastName}\n" +
                $"Email: {Email}\n" +
                $"IsNeigborhood: {IsNeighbor}\n";
        }
    }
}
