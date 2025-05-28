using Users.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Users.Services
{
    public class UserService
    {
        private List<User> _users;
        public UserService() 
        {
            _users = new List<User>();
            _users.Add(new User()
            {
                Id = 1,
                FirstName = "Rajvi",
                LastName = "Mangroliya",
                Email = "rm@gmail.com",
                PhoneNumber = "1234567890"
            });
            _users.Add(new User()
            {
                Id = 2,
                FirstName = "Alice",
                LastName = "Doe",
                Email = "ad@gmail.com",
                PhoneNumber = "1111111111"
            });
            _users.Add(new User()
            {
                Id = 3,
                FirstName = "John",
                LastName = "Smith",
                Email = "js@gmail.com",
                PhoneNumber = "2345678901"
            });
        }

        public List<User> GetUsers() 
        {
            return _users;
        }

        public User GetUserById(int id) 
        {
            User user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public void AddUser(User user) 
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
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
                userUpdate.Email = user.Email;
                userUpdate.PhoneNumber = user.PhoneNumber;
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
                _users.Remove(userDelete);
                return 1;
            }
        }
    }
}
