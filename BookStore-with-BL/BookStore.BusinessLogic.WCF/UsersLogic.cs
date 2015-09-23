using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using BookStore.Model;

namespace BookStore.BusinessLogic.WCF
{
    [Export(typeof (IUsersLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UsersLogic : IUsersLogic
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public User GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
