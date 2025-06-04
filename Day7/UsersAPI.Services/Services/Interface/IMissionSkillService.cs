using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Data.Models;
using UsersAPI.Entities.Entities;

namespace UsersAPI.Services.Services.Interface
{
    public interface IMissionSkillService
    {
        void AddMissionSkill(MissionSkill mSkill);
        List<MissionSkill> GetAll();
        MissionSkill? GetMissionSkillById(int id);
        Task InsertMissionSkill(MissionSkill mSkill);
        MissionSkillDetails GetMissionSkillDetailsById(int id);
    }
}
