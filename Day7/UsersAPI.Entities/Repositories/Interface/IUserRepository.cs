using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Data.Models;
using UsersAPI.Entities.Entities;
using UsersAPI.Entity.Models;


namespace UsersAPI.Entities.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<IList<User>> GetAllUser(FilterVM filterRequest);
    }
}
