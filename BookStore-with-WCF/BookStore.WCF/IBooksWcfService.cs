using System.Collections.Generic;
using System.ServiceModel;
using BookStore.Model;

namespace BookStore.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBooksWcfService" in both code and config file together.
    [ServiceContract]
    public interface IBooksWcfService
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<BookAmount> SearchBooks(int branchId, string isbn = null, string searchString = null, bool onHandOnly = false);
    }
}
