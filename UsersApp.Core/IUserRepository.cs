using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
