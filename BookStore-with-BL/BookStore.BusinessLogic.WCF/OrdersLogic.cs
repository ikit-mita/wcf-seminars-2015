using System;
using System.ComponentModel.Composition;
using BookStore.Model;

namespace BookStore.BusinessLogic.WCF
{
    [Export(typeof (IOrdersLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OrdersLogic : IOrdersLogic
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string ValidateOrder(Order order, int branchId)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order, int branchId)
        {
            throw new NotImplementedException();
        }
    }
}
