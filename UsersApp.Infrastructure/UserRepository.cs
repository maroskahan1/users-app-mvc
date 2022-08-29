using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Core;

namespace UsersApp.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly UserEntities _db;

        public UserRepository()
        {
            _db = new UserEntities();
        }

        public void Create(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void Delete(int userId)
        {
            var user = _db.Users.Find(userId);
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _db.Users;
        }

        public User GetUserById(int? userId)
        {
            return _db.Users.Find(userId);
        }

        public void Update(User user)
        {
            _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
