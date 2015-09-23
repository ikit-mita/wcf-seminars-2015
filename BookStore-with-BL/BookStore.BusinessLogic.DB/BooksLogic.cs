using Mita.DataAccess;

namespace BookStore.BusinessLogic.DB
{
    public class BooksLogic : IBooksLogic
    {
        private IRepositoryProvider RepositoryProvider { get; set; }
    }
}
