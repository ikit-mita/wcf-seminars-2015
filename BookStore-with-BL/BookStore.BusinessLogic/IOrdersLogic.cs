using BookStore.Model;

namespace BookStore.BusinessLogic
{
    public interface IOrdersLogic : IBusinessLogic
    {
        string ValidateOrder(Order order, int branchId);
        void SaveOrder(Order order, int branchId);
    }
}
