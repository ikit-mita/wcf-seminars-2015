using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using BookStore.BusinessLogic;
using BookStore.Model;
using Microsoft.Practices.ServiceLocation;

namespace BookStore.WCF
{
    public class UsersWcfService : IUsersWcfService, IDisposable
    {
        [Import]
        private IUsersLogic UsersLogic { get; set; }

        public UsersWcfService()
        {
            var container = ServiceLocator.Current.GetInstance<CompositionContainer>();
            container.ComposeParts(this);
        }

        public User GetUserByLogin(string login)
        {
            return UsersLogic.GetUserByLogin(login);
        }

        public Employee GetEmployeeByUserId(int userId)
        {
            return UsersLogic.GetEmployeeByUserId(userId);
        }

        public List<Customer> GetAllCustomers()
        {
            return UsersLogic.GetAllCustomers();
        }

        public void Dispose()
        {
            if (UsersLogic != null) UsersLogic.Dispose();
        }
    }
}
