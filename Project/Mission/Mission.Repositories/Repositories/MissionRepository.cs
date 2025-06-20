using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mission.Entities.Context;
using Mission.Entities.Entities;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;

namespace Mission.Repositories.Repositories
{
    public class MissionRepository(MissionDbContext dbContext) : IMissionRepository
    {

        public List<Missions> GetMissionList()
        {
            return dbContext.Missions
                .Where(x => !x.IsDeleted)
                .Include(m => m.MissionTheme)
                .ToList();
        }


        public async Task<string> AddMission(AddMissionRequestModel model)
        {
            var isExist = dbContext.Missions.Where(x =>
                            x.MissionTitle == model.MissionTitle
                            && x.StartDate == model.StartDate
                            && x.EndDate == model.EndDate
                            && x.CityId == model.CityId
                            && !x.IsDeleted
                        ).FirstOrDefault();

            if (isExist != null) throw new Exception("Mission already exist!");

            Missions missions = new Missions()
            {
                MissionTitle = model.MissionTitle,
                MissionDescription = model.MissionDescription,
                MissionImages = model.MissionImages,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                CountryId = model.CountryId,
                CityId = model.CityId,
                TotalSheets = model.TotalSheets,
                MissionThemeId = model.MissionThemeId,
                MissionSkillId = model.MissionSkillId,
                MissionOrganisationName = "",
                MissionOrganisationDetail = "",
                MissionType = "",
                MissionDocuments = "",
                MissionAvailability = "",
                MissionVideoUrl = "",


                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            await dbContext.Missions.AddAsync(missions);
            dbContext.SaveChanges();

            return "Added!";
        }

        //public async Task<IList<Missions>> ClientSideMissionList(int userId)
        public async Task<IList<Missions>> ClientSideMissionList()
        {
            return await dbContext.Missions
                .Include(m => m.City)
                .Include(m => m.Country)
               .Include(m => m.MissionTheme)
               .Include(m => m.MissionApplications)
                .Where(m => !m.IsDeleted)
                .OrderBy(m => m.CreatedDate)
                .ToListAsync();
        }

        public async Task<bool> ApplyMission(AddMissionApplicationRequestModel model)
        {
            try
            {
                var mission = dbContext.Missions.Where(x => x.Id == model.MissionId).FirstOrDefault();

                if (mission == null) throw new Exception("Mission not found");

                var application = dbContext.MissionApplications.Where(x => x.MissionId == model.MissionId && x.UserId == model.UserId).FirstOrDefault();

                if (application != null) throw new Exception("Already applied!");

                MissionApplication app = new MissionApplication()
                {
                    UserId = model.UserId,
                    MissionId = model.MissionId,
                    //Mission = model.MissionTitle,
                    //Mission = model.MissionTheme.
                    //User = model.UserName
                    AppliedDate = model.AppliedDate,
                    Seats = model.Sheet,
                    Status = model.Status,

                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                };

                mission.TotalSheets -= model.Sheet;

                await dbContext.MissionApplications.AddAsync(app);
                dbContext.Missions.Update(mission);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public List<MissionApplication> GetMissionApplicationList()
        //{
        //    return dbContext.MissionApplications.Where(x => !x.IsDeleted).ToList();

        //}
        public List<object> GetMissionApplicationList()
        {
            var applications = dbContext.MissionApplications
                .Include(ma => ma.Mission)
                    .ThenInclude(m => m.MissionTheme)
                .Include(ma => ma.User)
                .Where(x => !x.IsDeleted)
                .Select(ma => new
                {
                    id = ma.Id,
                    MissionTitle = ma.Mission.MissionTitle,
                    ThemeTitle = ma.Mission.MissionTheme.ThemeName,
                    UserName = ma.User.FirstName + " " + ma.User.LastName,
                    ma.AppliedDate,
                    ma.Seats,
                    ma.Status
                })
                .ToList<object>();

            return applications;
        }



        public async Task<bool> MissionApplicationApprove(UpdateMissionApplicationModel missionApplication)
        {
            var tMissionApp = dbContext.MissionApplications.Where(x => x.Id == missionApplication.Id).FirstOrDefault();

            if (tMissionApp == null) throw new Exception("Mission application not found");

            tMissionApp.Status = true;
            tMissionApp.ModifiedDate = DateTime.Now;

            dbContext.MissionApplications.Update(tMissionApp);
            await dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> MissionApplicationDelete(UpdateMissionApplicationModel missionApplication)
        {
            var tMissionApp = dbContext.MissionApplications.Where(x => x.Id == missionApplication.Id).FirstOrDefault();

            if (tMissionApp == null) throw new Exception("Mission application not found");

            tMissionApp.IsDeleted = true;
            tMissionApp.ModifiedDate = DateTime.Now;

            dbContext.MissionApplications.Update(tMissionApp);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
