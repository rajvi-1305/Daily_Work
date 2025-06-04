using UsersAPI.Data.Models;
using UsersAPI.Entities.Repositories.Interface;
using UsersAPI.Services.Services.Interface;

namespace UsersAPI.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserVM>> GetAllUsers(FilterVM filterRequest)
        {
            var users = await _userRepository.GetAllUser(filterRequest);

            return users.Select(u => new UserVM()
            {
                Email = u.Email,
                Id = u.Id,
                Name = u.Name,
                Role = u.Role,
                MissionSkill = u.MissionSkillDetails.Select(u => new MissionSkill()
                {
                    Id = u.Id,
                    Description = u.Description,
                    MissionName = u.MissionName
                }).ToList()
            }).ToList();
        }

    }
}
