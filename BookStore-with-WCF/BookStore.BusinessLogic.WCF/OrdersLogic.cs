using System.Collections.Generic;
using System.ComponentModel.Composition;
using BookStore.BusinessLogic.WCF.OrdersWcfService;
using BookStore.Model;

namespace BookStore.BusinessLogic.WCF
{
    [Export(typeof(IOrdersLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OrdersLogic : IOrdersLogic
    {
        [Import]
        private OrdersWcfServiceClient ServiceClient { get; set; }

        public void Dispose()
        {
            ServiceClient.Close();
        }

        public string ValidateOrder(int branchId, List<OrderedBookDescription> orderedBooks)
        {
            return ServiceClient.ValidateOrder(branchId, orderedBooks);
        }

        public Order SaveOrder(int branchId, int customerId, int employeeId, List<OrderedBookDescription> orderedBooks)
        {
            var order = ServiceClient.SaveOrder(branchId, customerId, employeeId, orderedBooks);
            return order;
        }
    }
}
