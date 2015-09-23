using System;
using System.Collections.Generic;
using System.Linq;
using SharedModel;

namespace UsersWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private List<User> _userStore = new List<User>
        {
            new User { Login = "L1", Name = "Leo Fargus" },
            new User { Login = "L2", Name = "Leo Davinci" },
            new User { Login = "L3", Name = "Steve Jobs" },
        }; 

        public List<User> FindUsers(string searchString)
        {
            var users = _userStore
                .Where(u => u.Name.Contains(searchString))
                .ToList();

            return users;
        }

        public User GetUser(string login)
        {
            var user = _userStore
                .FirstOrDefault(u => u.Login == login);
            return user;
        }
    }
}
