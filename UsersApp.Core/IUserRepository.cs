using System.Collections.Generic;

namespace UsersApp.Core
{
    public interface IUserRepository
    {
        void Create(User user);
        void Update(User user);
        void Delete(int userId);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int? userId);
    }
}
