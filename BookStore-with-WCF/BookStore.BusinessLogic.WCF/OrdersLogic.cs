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

        public string ValidateOrder(Order order, int branchId)
        {
            return ServiceClient.ValidateOrder(order, branchId);
        }

        public void SaveOrder(Order order, int branchId)
        {
            ServiceClient.SaveOrder(order, branchId);
        }
    }
}
