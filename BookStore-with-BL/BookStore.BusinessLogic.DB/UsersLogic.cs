using System.ComponentModel.Composition;
using System.Linq;
using BookStore.Model;
using Mita.DataAccess;

namespace BookStore.BusinessLogic.DB
{
    [Export(typeof(IUsersLogic))]
    public class UsersLogic : IUsersLogic
    {
        [Import]
        private IRepositoryProvider RepositoryProvider { get; set; }

        public User GetUserByLogin(string login)
        {
            var user = RepositoryProvider.GetRepository<User>().GetAll()
                .FirstOrDefault(u => u.Login == login);
            return user;
        }
    }
}
