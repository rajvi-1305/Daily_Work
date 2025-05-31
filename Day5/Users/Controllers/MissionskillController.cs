using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.DataAccess.Models;
using Users.Services.Services;

namespace Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MissionskillController: ControllerBase
    {
        private readonly MissionSkillService _missionSkillService;

        public MissionskillController(MissionSkillService missionSkillService)
        {
            _missionSkillService = missionSkillService;
        }

        [HttpGet]
        public ActionResult<List<MissionSkiil>> GetAllMissionSkills()
        {
            List<MissionSkiil> mSkills = _missionSkillService.GetMissionSkills();
            if (mSkills == null || mSkills.Count == 0)
            {
                return NotFound("MissionSkill Not Found");
            }
            else
            {
                return Ok(mSkills);
            }
        }

        [HttpGet("id")]
        public ActionResult<List<MissionSkiil>> GetMissionSkill(int id)
        {
            MissionSkiil mSkill = _missionSkillService.GetMissionSkillById(id);
            if (mSkill == null)
            {
                return NotFound("MissionSkill Not Found");
            }
            else
            {
                return Ok(mSkill);
            }
        }

        [HttpGet("skill")]
        public ActionResult<List<MissionSkiil>> GetSkills(string type)
        {
            List<MissionSkiil> mSkills = _missionSkillService.GetSkill(type);
            if (mSkills == null || mSkills.Count == 0)
            {
                return NotFound("MissionSkill Type Not Found");
            }
            else
            {
                return Ok(mSkills);
            }
        }


        [HttpPost]
        public ActionResult AddMissionSkill(MissionSkiil book)
        {
            _missionSkillService.AddMissionSkill(book);
            return Ok("MissionSkill Cretaed successfully");
        }

        [HttpPut]
        public ActionResult UpdateMissionSkillDetails(MissionSkiil mSkillUpdate)
        {
            int mSkillStatus = _missionSkillService.UpdateMissionSkill(mSkillUpdate);
            if (mSkillStatus == -1)
            {
                return NotFound("MissionSkill Not Found");
            }
            else if (mSkillStatus == 1)
            {
                return Ok("MissionSkill Details updated successfully");
            }
            else
            {
                return BadRequest("Bad request");
            }
        }

        [HttpDelete]
        public ActionResult DeleteMissionSkillDetails(int id)
        {
            int deleteStatus = _missionSkillService.DeleteMissionSkill(id);
            if (deleteStatus == -1)
            {
                return NotFound("MissionSkill Not found");
            }
            else if (deleteStatus == 1)
            {
                return Ok("MissionSkill Details Deleted Successfully");
            }
            else
            {
                return BadRequest("Bad request");
            }
        }
    }
}
