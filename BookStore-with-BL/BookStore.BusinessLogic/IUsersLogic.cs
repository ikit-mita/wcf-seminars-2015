using BookStore.Model;

namespace BookStore.BusinessLogic
{
    public interface IUsersLogic
    {
        User GetUserByLogin(string login);
    }
}
