using Mission.Entities.Entities;
using Mission.Entities.Models.CommonModels;

namespace Mission.Services.IServices
{
    public interface ICommonService
    {
        List<DropDownResponseModel> CountryList();

        List<DropDownResponseModel> CityList(int countryId);

        List<DropDownResponseModel> MissionCountryList();

        List<DropDownResponseModel> MissionCityList();

        List<DropDownResponseModel> MissionThemeList();

        List<DropDownResponseModel> MissionSkillList();

        List<DropDownResponseModel> MissionTitleList();

        List<DropDownResponseModel> GetUserSkill(int userId);
        Task<bool> AddUserSkill(UserSkills skills);
    }
}
