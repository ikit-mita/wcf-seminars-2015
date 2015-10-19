using System.Collections.Generic;
using BookStore.Model;

namespace BookStore.BusinessLogic
{
    public interface IOrdersLogic : IBusinessLogic
    {
        string ValidateOrder(int branchId, List<OrderedBookDescription> orderedBooks);
        Order SaveOrder(int branchId, int customerId, int employeeId, List<OrderedBookDescription> orderedBooks);
    }
}
