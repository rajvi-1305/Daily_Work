using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Entities.Context;
using UsersAPI.Entities.Entities;
using UsersAPI.Entities.Repositories.Interface;

namespace UsersAPI.Entities.Repositories
{
    public class MissionSkillRepository(MissionSkillDbContext missionSkillDbContext) : IMissionSkillRepository
    {
        private readonly MissionSkillDbContext _dbContext = missionSkillDbContext;

        public async Task InsertMissionSkill(MissionSkillDetails missionSkillDetails)
        {
            await _dbContext.MissionSkillDetails.AddAsync(missionSkillDetails);
            await _dbContext.SaveChangesAsync();
        }

        public MissionSkillDetails GetById(int id)
        {
            return _dbContext.MissionSkillDetails.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
