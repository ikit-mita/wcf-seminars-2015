using System;
using System.ComponentModel.Composition;
using System.Linq;
using BookStore.Model;
using Mita;

namespace BookStore.BusinessLogic.DB
{
    [Export(typeof(IOrdersLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OrdersLogic : BusinessLogicBase, IOrdersLogic
    {
        public string ValidateOrder(Order order, int branchId)
        {
            var bookAmountRepository = RepositoryProvider.GetRepository<BookAmount>();
            foreach (var orderedBook in order.OrderedBooks)
            {
                var bookAmount = bookAmountRepository.GetAll()
                    .Where(ba => ba.BookId == orderedBook.BookId)
                    .First(ba => ba.BranchId == branchId);

                if (orderedBook.Amount > bookAmount.Amount)
                {
                    return "Max amount for '{0}' is {1}".FormatWith(orderedBook.Book.Title, bookAmount.Amount);
                }
            }

            return null;
        }

        public void SaveOrder(Order order, int branchId)
        {
            var bookAmountRepository = RepositoryProvider.GetRepository<BookAmount>();
            foreach (var orderedBook in order.OrderedBooks)
            {
                var bookAmount = bookAmountRepository.GetAll()
                    .Where(ba => ba.BookId == orderedBook.BookId)
                    .First(ba => ba.BranchId == branchId);
                bookAmount.Amount -= orderedBook.Amount;
            }

            RepositoryProvider.GetRepository<Order>().Add(order);
            RepositoryProvider.SaveChanges();
        }
    }
}
