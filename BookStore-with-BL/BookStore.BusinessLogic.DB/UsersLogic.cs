using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using BookStore.DataAccess;
using BookStore.Model;
using Mita.DataAccess;

namespace BookStore.BusinessLogic.DB
{
    [Export(typeof(IUsersLogic))]
    public class UsersLogic : BusinessLogicBase, IUsersLogic
    {
        public User GetUserByLogin(string login)
        {
            var user = RepositoryProvider.GetRepository<User>().GetAll()
                .FirstOrDefault(u => u.Login == login);
            return user;
        }

        public Employee GetEmployeeByUserId(int userId)
        {
            Employee employee = RepositoryProvider.GetRepository<Employee>()
                .GetAll(e => e.Branch, e => e.User)
                .First(e => e.Id == userId);

            return employee;
        }

        public List<Customer> GetAllCustomers()
        {
            return RepositoryProvider.GetRepository<Customer>().GetAll().ToList();
        }
    }
}
