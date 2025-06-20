using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mission.Entities.Entities;
using Mission.Entities.Models;

namespace Mission.Services.IServices
{
    public interface IMissionService
    {
        List<Missions> GetMissionList();
        Task<string> AddMission(AddMissionRequestModel model);

        Task<List<MissionSkillViewModel>> GetAllMissionSkill();
        Task<List<MissionThemeViewModel>> GetAllMissionTheme();
        Task<IList<MissionDetailResponseModel>> ClientSideMissionList(int userId);

        Task<bool> ApplyMission(AddMissionApplicationRequestModel model);
        //List<MissionApplication> GetMissionApplicationList();
        List<object> GetMissionApplicationList();
        Task<bool> MissionApplicationApprove(UpdateMissionApplicationModel missionApplication);
        Task<bool> MissionApplicationDelete(UpdateMissionApplicationModel missionApplication);
    }
}
