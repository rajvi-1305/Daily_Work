using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.DataAccess.Models;
using Users.DataAccess.Repositories;

namespace Users.Services.Services
{
    public class MissionSkillService
    {
        private readonly MissionSkillRepository _missionSkillRepository;

        public MissionSkillService(MissionSkillRepository missionSkillRepository)
        {
            _missionSkillRepository = missionSkillRepository;
        }

        public List<MissionSkiil> GetMissionSkills()
        {
            return _missionSkillRepository.GetMissionSkills();
        }

        public MissionSkiil GetMissionSkillById(int id)
        {
            return _missionSkillRepository.GetMissionSkillById(id);
        }

        public List<MissionSkiil> GetSkill(string mSkill)
        {
            return _missionSkillRepository.GetSkill(mSkill);
        }

        public void AddMissionSkill(MissionSkiil mSkill)
        {
            _missionSkillRepository.AddMissionSkill(mSkill);
        }

        public int UpdateMissionSkill(MissionSkiil mSkill)
        {
            return _missionSkillRepository.UpdateMissionSkill(mSkill);
        }

        public int DeleteMissionSkill(int id)
        {
            return _missionSkillRepository.DeleteMissionSkill(id);
        }
    }
}
