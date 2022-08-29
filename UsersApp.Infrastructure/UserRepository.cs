using System;
using System.Collections.Generic;
using System.Linq;
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
            if(_db.Users.Any(x => x.Login == user.Login))
            {
                throw new ArgumentException($"Login '{user.Login}' is already taken!");
            }

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
            var oldUser = _db.Users.First(x => x.ID == user.ID);

            if (oldUser.Login != user.Login && _db.Users.Any(x => user.Login == x.Login))
            {
                throw new ArgumentException($"Login '{user.Login}' is already taken!");
            }

            _db.Entry(oldUser).CurrentValues.SetValues(user);
            _db.SaveChanges();
        }
    }
}
