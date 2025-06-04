using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Entities.Entities;

namespace UsersAPI.Entities.Repositories.Interface
{
    public interface IMissionSkillRepository
    {
        Task InsertMissionSkill(MissionSkillDetails missionSkillDetails);
        MissionSkillDetails GetById(int id);
    }
}
