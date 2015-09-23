using System.Collections.Generic;
using System.ServiceModel;
using SharedModel;

namespace UsersWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        List<User> FindUsers(string searchString);

        [OperationContract]
        User GetUser(string login);
    }
}
