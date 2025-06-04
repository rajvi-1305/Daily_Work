using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Data.Models;
using UsersAPI.Entities.Entities;
using UsersAPI.Entities.Repositories;
using UsersAPI.Entities.Repositories.Interface;
using UsersAPI.Services.Services.Interface;

namespace UsersAPI.Services.Services
{
    // For CRUD on books
    public class MissionSkillService : IMissionSkillService
    {
        private List<MissionSkill> _missionSkills;
        private readonly IMissionSkillRepository _missionSkillRepository;

        public MissionSkillService(IMissionSkillRepository missionSkillRepository)
        {
            _missionSkillRepository = missionSkillRepository;
            _missionSkills = new List<MissionSkill>();
        }

        // To Add Book
        public void AddMissionSkill(MissionSkill mSkill)
        {
            _missionSkills.Add(mSkill);
        }

        // To Get All Books
        public List<MissionSkill> GetAll()
        {
            return _missionSkills;
        }

        // To Get Single Book
        public MissionSkill? GetMissionSkillById(int id)
        {
            return _missionSkills.Find(x => x.Id == id);
        }

        public async Task InsertMissionSkill(MissionSkill mSkill)
        {
            var missionSkillDetails = new MissionSkillDetails()
            {
                MissionName = mSkill.MissionName,
                Description = mSkill.Description,
                UserId = mSkill.UserId
            };
            await _missionSkillRepository.InsertMissionSkill(missionSkillDetails);
        }


        public MissionSkillDetails GetMissionSkillDetailsById(int id)
        {
            return _missionSkillRepository.GetById(id);
        }

        // To Update Book
        // To Delete Book
    }
}
