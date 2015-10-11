using System.Collections.Generic;
using System.ComponentModel.Composition;
using BookStore.BusinessLogic.WCF.BooksWcfService;
using BookStore.Model;

namespace BookStore.BusinessLogic.WCF
{
    [Export(typeof(IBooksLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BooksLogic : IBooksLogic
    {
        [Import]
        private BooksWcfServiceClient ServiceClient { get; set; }

        public void Dispose()
        {
            ServiceClient.Close();
        }

        public List<BookAmount> SearchBooks(int branchId, string isbn = null, string searchString = null, bool onHandOnly = false)
        {
            return ServiceClient.SearchBooks(branchId, isbn, searchString, onHandOnly);
        }
    }
}
