using System.ComponentModel.Composition;

namespace BookStore.BusinessLogic.WCF.OrdersWcfService
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    partial class OrdersWcfServiceClient
    {
    }
}
