using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using BookStore.DataAccess;
using BookStore.Model;
using Mita;

namespace BookStore.BusinessLogic.DB
{
    [Export(typeof(IBooksLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BooksLogic : BusinessLogicBase, IBooksLogic
    {
        public List<BookAmount> SearchBooks(int branchId, string isbn = null, string searchString = null, bool onHandOnly = false)
        {
            var query = RepositoryProvider.GetRepository<BookAmount>()
                .GetAll(ba => ba.Book.Writers)
                .Where(ba => ba.BranchId == branchId);

            if (onHandOnly)
            {
                query = query.Where(ba => ba.Amount > 0);
            }

            if (!isbn.IsNullOrEmpty())
            {
                query = query.Where(ba => ba.Book.ISBN.Contains(isbn));
            }
            else if (!searchString.IsNullOrEmpty())
            {
                query = query.Where(ba => ba.Book.Title.Contains(searchString) ||
                                          ba.Book.Writers.Any(w => w.LastName.Contains(searchString)));
            }

            return query.ToList();
        }
    }
}
