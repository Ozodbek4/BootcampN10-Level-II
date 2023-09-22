using N43Home1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N43Home1.Services
{
    internal class UserService
    {
        public List<User> Users = new List<User>();

        public UserService() { }

        public UserService(User user)
        {
            Users.Add(user);
        }

        public User AddUser(User user)
        {
            
            Users.Add(user);
            return user;
        } 
    }
}
