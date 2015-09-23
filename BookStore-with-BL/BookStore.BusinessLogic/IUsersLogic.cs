using System.Collections.Generic;
using BookStore.Model;

namespace BookStore.BusinessLogic
{
    public interface IUsersLogic : IBusinessLogic
    {
        User GetUserByLogin(string login);

        Employee GetEmployeeByUserId(int userId);

        List<Customer> GetAllCustomers();
    }
}
