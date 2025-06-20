using Mission.Entities.Entities;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;
using Mission.Repositories.Repositories;
using Mission.Services.IServices;

namespace Mission.Services.Services
{
    public class MissionService(IMissionRepository missionRepository, IMissionSkillRepository missionSkillRepository, IMissionThemeRepository missionThemeRepository) : IMissionService
    {
        private readonly IMissionRepository _missionRepository = missionRepository;
        private readonly IMissionSkillRepository _missionSkillRepository = missionSkillRepository;
        private readonly IMissionThemeRepository _missionThemeRepository = missionThemeRepository;
        public List<Missions> GetMissionList()
        {
            return missionRepository.GetMissionList();
        }

        public Task<string> AddMission(AddMissionRequestModel model)
        {
            return missionRepository.AddMission(model);
        }

        public Task<List<MissionSkillViewModel>> GetAllMissionSkill()
        {
            return _missionSkillRepository.GetAllMissionSkill();
        }

        public Task<List<MissionThemeViewModel>> GetAllMissionTheme()
        {
            return _missionThemeRepository.GetAllMissionTheme();
        }

        public async Task<IList<MissionDetailResponseModel>> ClientSideMissionList(int userId)
        {
            var missions = await _missionRepository.ClientSideMissionList();

            return missions.Select(m => new MissionDetailResponseModel()
            {
                Id = m.Id,
                EndDate = m.EndDate,
                StartDate = m.StartDate,
                MissionDescription = m.MissionDescription,
                MissionImages = m.MissionImages,
                MissionTitle = m.MissionTitle,
                TotalSheets = m.TotalSheets,
                RegistrationDeadLine = m.RegistrationDeadLine,
                CityId = m.CityId,
                CityName = m.City.CityName,
                CountryId = m.CountryId,
                CountryName = m.Country.CountryName,
                MissionSkillId = m.MissionSkillId,
                MissionSkillName = _missionSkillRepository.GetMissionSkills(m.MissionSkillId),
                MissionThemeId = m.MissionThemeId,
                MissionThemeName = m.MissionTheme.ThemeName,

                MissionApplyStatus = m.MissionApplications.Any(m => m.UserId == userId) ? "Applied" : "Apply",
                MissionApproveStatus = m.MissionApplications.Any(m => m.UserId == userId && (m.Status == true && m.IsDeleted==false)) ? "Approved" : "Applied",
                MissionStatus = m.RegistrationDeadLine < DateTime.Now.AddDays(-1) ? "Closed" : "Available"
            }).ToList();

        }

        public async Task<bool> ApplyMission(AddMissionApplicationRequestModel model)
        {
            return await _missionRepository.ApplyMission(model);
        }

        public List<object> GetMissionApplicationList()
        {
            return _missionRepository.GetMissionApplicationList();
        }

        public async Task<bool> MissionApplicationApprove(UpdateMissionApplicationModel missionApplication)
        {
            return await _missionRepository.MissionApplicationApprove(missionApplication);
        }
        
        public async Task<bool> MissionApplicationDelete(UpdateMissionApplicationModel missionApplication)
        {
            return await _missionRepository.MissionApplicationDelete(missionApplication);
        }
    }
}
