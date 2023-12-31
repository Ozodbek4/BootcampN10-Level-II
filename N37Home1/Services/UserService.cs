﻿using N37Home1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37Home1.Services
{
    internal class UserService
    {
        public IEnumerable<User> GetUser(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                yield return user;
            }
        }
    }
}
