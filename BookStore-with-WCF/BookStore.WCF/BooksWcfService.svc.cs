using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using BookStore.BusinessLogic;
using BookStore.Model;
using Microsoft.Practices.ServiceLocation;

namespace BookStore.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BooksWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BooksWcfService.svc or BooksWcfService.svc.cs at the Solution Explorer and start debugging.
    public class BooksWcfService : IBooksWcfService, IDisposable
    {
        [Import]
        private IBooksLogic BooksLogic { get; set; }

        public BooksWcfService()
        {
            var container = ServiceLocator.Current.GetInstance<CompositionContainer>();
            container.ComposeParts(this);
        }

        public List<BookAmount> SearchBooks(int branchId, string isbn = null, string searchString = null, bool onHandOnly = false)
        {
            var searchBooks = BooksLogic.SearchBooks(branchId, isbn, searchString, onHandOnly);
            return searchBooks;
        }

        public void Dispose()
        {
            if (BooksLogic != null) BooksLogic.Dispose();
        }
    }
}
