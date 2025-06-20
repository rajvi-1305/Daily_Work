using Mission.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Repositories.IRepositories
{
    public interface ILoginRepository
    {
        LoginUserResponseModel LoginUser(LoginUserRequestModel model);

        Task<string> Register(RegisterUserModel model);

        //Task<LoginUserResponseModel?> GetLoginUserDetailById(int userId);

        UserResponseModel LoginUserDetailById(int id);
        Task<bool> LoginUserProfileUpdate(AddUserDetailsRequestModel requestModel);
    }
}
