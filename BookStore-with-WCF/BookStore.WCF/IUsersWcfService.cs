using System.Collections.Generic;
using System.ServiceModel;
using BookStore.Model;

namespace BookStore.WCF
{
    [ServiceContract]
    public interface IUsersWcfService
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        User GetUserByLogin(string login);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Employee GetEmployeeByUserId(int userId);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<Customer> GetAllCustomers();
    }
}
