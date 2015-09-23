using System.ComponentModel.Composition;
using Mita.DataAccess;

namespace BookStore.BusinessLogic.DB
{
    public class BusinessLogicBase : IBusinessLogic
    {
        [Import]
        protected IRepositoryProvider RepositoryProvider { get; private set; }

        public void Dispose()
        {
            if (RepositoryProvider != null)
            {
                RepositoryProvider.Dispose();
                RepositoryProvider = null;
            }
        }
    }
}
