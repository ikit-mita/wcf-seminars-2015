using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using BookStore.BusinessLogic.WCF.UsersWcfService;
using BookStore.Model;

namespace BookStore.BusinessLogic.WCF
{
    [Export(typeof(IUsersLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UsersLogic : IUsersLogic
    {
        [Import]
        private UsersWcfServiceClient ServiceClient { get; set; }

        public void Dispose()
        {
            ServiceClient.Close();
        }

        public User GetUserByLogin(string login)
        {
            return ServiceClient.GetUserByLogin(login);
        }

        public Employee GetEmployeeByUserId(int userId)
        {
            return ServiceClient.GetEmployeeByUserId(userId);
        }

        public List<Customer> GetAllCustomers()
        {
            return ServiceClient.GetAllCustomers();
        }
    }
}
