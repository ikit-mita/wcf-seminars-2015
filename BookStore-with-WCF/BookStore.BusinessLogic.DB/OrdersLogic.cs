using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using BookStore.DataAccess;
using BookStore.Model;
using Mita;

namespace BookStore.BusinessLogic.DB
{
    [Export(typeof(IOrdersLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OrdersLogic : BusinessLogicBase, IOrdersLogic
    {
        public string ValidateOrder(int branchId, List<OrderedBookDescription> orderedBooks)
        {
            var bookAmountRepository = RepositoryProvider.GetRepository<BookAmount>();
            foreach (var orderedBook in orderedBooks)
            {
                var bookAmount = bookAmountRepository.GetAll()
                    .Where(ba => ba.BookId == orderedBook.BookId)
                    .First(ba => ba.BranchId == branchId);

                if (orderedBook.Amount > bookAmount.Amount)
                {
                    return "Max amount for '{0}' is {1}".FormatWith(orderedBook.BookTitle, bookAmount.Amount);
                }
            }

            return null;
        }

        public Order SaveOrder(int branchId, int customerId, int employeeId, List<OrderedBookDescription> orderedBooks)
        {
            var order = new Order
            {
                Customer = RepositoryProvider.GetRepository<Customer>().Find(customerId),
                EmployeeId = employeeId,
                Date = DateTime.Now,
                OrderedBooks = new List<OrderedBook>(orderedBooks.Count)
            };

            var bookAmountRepository = RepositoryProvider.GetRepository<BookAmount>();
            foreach (var orderedBook in orderedBooks)
            {
                var bookAmount = bookAmountRepository.GetAll(ba => ba.Book)
                    .Where(ba => ba.BookId == orderedBook.BookId)
                    .First(ba => ba.BranchId == branchId);
                bookAmount.Amount -= orderedBook.Amount;
                order.OrderedBooks.Add(new OrderedBook
                {
                    BookId = bookAmount.Book.Id,
                    Price = bookAmount.Book.Price,
                    Amount = orderedBook.Amount
                });
            }

            RepositoryProvider.GetRepository<Order>().Add(order);
            RepositoryProvider.SaveChanges();

            return order;
        }
    }
}
