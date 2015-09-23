using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using BookStore.Model;

namespace BookStore.BusinessLogic.WCF
{
    [Export(typeof (IBooksLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BooksLogic : IBooksLogic
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<BookAmount> SearchBooks(int branchId, string isbn = null, string searchString = null, bool onHandOnly = false)
        {
            throw new NotImplementedException();
        }
    }
}
