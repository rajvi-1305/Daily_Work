using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mission.Entities.Entities;
using Mission.Entities.Models;

namespace Mission.Repositories.IRepositories
{
    public interface IMissionRepository
    {
        List<Missions> GetMissionList();
        Task<string> AddMission(AddMissionRequestModel model);


        //Task<IList<Missions>> ClientSideMissionList(int userId);
        Task<IList<Missions>> ClientSideMissionList();

        Task<bool> ApplyMission(AddMissionApplicationRequestModel model);

        //List<MissionApplication> GetMissionApplicationList();
        List<object> GetMissionApplicationList();
        Task<bool> MissionApplicationApprove(UpdateMissionApplicationModel missionApplication);
        
        Task<bool> MissionApplicationDelete(UpdateMissionApplicationModel missionApplication);

    }
}
