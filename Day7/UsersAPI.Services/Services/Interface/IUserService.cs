using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Data.Models;
using UsersAPI.Entities.Repositories;

namespace UsersAPI.Services.Services.Interface
{
    public interface IUserService
    {
        Task<List<UserVM>> GetAllUsers(FilterVM filterRequest);

    }
}
