using System.Collections.Generic;
using System.ServiceModel;
using BookStore.BusinessLogic;
using BookStore.Model;

namespace BookStore.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrdersWcfService" in both code and config file together.
    [ServiceContract]
    public interface IOrdersWcfService
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        string ValidateOrder(int branchId, List<OrderedBookDescription> orderedBooks);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Order SaveOrder(int branchId, int customerId, int employeeId, List<OrderedBookDescription> orderedBooks);
    }
}
