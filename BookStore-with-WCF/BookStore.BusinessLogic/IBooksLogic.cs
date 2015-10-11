using System.Collections.Generic;
using BookStore.Model;

namespace BookStore.BusinessLogic
{
    public interface IBooksLogic : IBusinessLogic
    {
        List<BookAmount> SearchBooks(int branchId, string isbn = null, string searchString = null, bool onHandOnly = false);
    }
}
