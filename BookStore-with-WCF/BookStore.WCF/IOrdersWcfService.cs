using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BookStore.Model;

namespace BookStore.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrdersWcfService" in both code and config file together.
    [ServiceContract]
    public interface IOrdersWcfService
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        string ValidateOrder(Order order, int branchId);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void SaveOrder(Order order, int branchId);
    }
}
