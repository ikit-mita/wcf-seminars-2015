using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using BookStore.BusinessLogic;
using BookStore.Model;
using Microsoft.Practices.ServiceLocation;

namespace BookStore.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrdersWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OrdersWcfService.svc or OrdersWcfService.svc.cs at the Solution Explorer and start debugging.
    public class OrdersWcfService : IOrdersWcfService, IDisposable
    {
        [Import]
        private IOrdersLogic OrdersLogic { get; set; }

        public OrdersWcfService()
        {
            var container = ServiceLocator.Current.GetInstance<CompositionContainer>();
            container.ComposeParts(this);
        }

        public string ValidateOrder(int branchId, List<OrderedBookDescription> orderedBooks)
        {
            return OrdersLogic.ValidateOrder(branchId, orderedBooks);
        }

        public Order SaveOrder(int branchId, int customerId, int employeeId, List<OrderedBookDescription> orderedBooks)
        {
            var order = OrdersLogic.SaveOrder(branchId, customerId, employeeId, orderedBooks);
            return order;
        }

        public void Dispose()
        {
            if(OrdersLogic != null) OrdersLogic.Dispose();
        }
    }
}
