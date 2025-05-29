using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.DataAccess.Models;

namespace Users.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly UserDbContext _userDbContext; 
        public UserRepository(UserDbContext userDbContext) {
            _userDbContext = userDbContext;
        }

        public List<User> GetUsers()
        {
            return _userDbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            User user = _userDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public List<User> GetType(string type)
        {
            List<User> users = _userDbContext.Users.Where(u => u.UserType.Equals(type)).ToList();
            return users;
        }

        public void AddUser(User user)
        {
            _userDbContext.Users.Add(user);
            _userDbContext.SaveChanges();
        }

        public int UpdateUser(User user)
        {
            User userUpdate = GetUserById(user.Id);
            if (userUpdate == null)
            {
                return -1;
            }
            else
            {
                userUpdate.FirstName = user.FirstName;
                userUpdate.LastName = user.LastName;
                userUpdate.PhoneNumber = user.PhoneNumber;
                userUpdate.EmailAddress = user.EmailAddress;
                userUpdate.UserType = user.UserType;
                userUpdate.Password = user.Password;
                _userDbContext.SaveChanges();
                return 1;
            }
        }

        public int DeleteUser(int id)
        {
            User userDelete = GetUserById(id);
            if (userDelete == null)
            {
                return -1;
            }
            else
            {
                _userDbContext.Users.Remove(userDelete);
                _userDbContext.SaveChanges();
                return 1;
            }
        }
    }
}
