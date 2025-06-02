using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.DataAccess.Models;

namespace Users.DataAccess.Repositories
{
    public class MissionSkillRepository
    {
        private readonly UserDbContext _missionDbContext;
        public MissionSkillRepository(UserDbContext missionDbContext)
        {
            _missionDbContext = missionDbContext;
        }

        public List<MissionSkiil> GetMissionSkills()
        {
            return _missionDbContext.MissionSkills.ToList();
        }

        public MissionSkiil GetMissionSkillById(int id)
        {
            MissionSkiil user = _missionDbContext.MissionSkills.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public List<MissionSkiil> GetSkill(string skill)
        {
            List<MissionSkiil> users = _missionDbContext.MissionSkills.Where(u => u.SkillName.Equals(skill)).ToList();
            return users;
        }

        public void AddMissionSkill(MissionSkiil mSkill)
        {
            _missionDbContext.MissionSkills.Add(mSkill);
            _missionDbContext.SaveChanges();
        }

        public int UpdateMissionSkill(MissionSkiil mSkill)
        {
            MissionSkiil mSkillUpdate = GetMissionSkillById(mSkill.Id);
            if (mSkillUpdate == null)
            {
                return -1;
            }
            else
            {
                mSkillUpdate.SkillName = mSkill.SkillName;
                mSkillUpdate.Status = mSkill.Status;
                _missionDbContext.SaveChanges();
                return 1;
            }
        }

        public int DeleteMissionSkill(int id)
        {
            MissionSkiil mSkillDelete = GetMissionSkillById(id);
            if (mSkillDelete == null)
            {
                return -1;
            }
            else
            {
                _missionDbContext.MissionSkills.Remove(mSkillDelete);
                _missionDbContext.SaveChanges();
                return 1;
            }
        }
    }
}
