using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Models;
using UsersAPI.Services.Services.Interface;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionSkillController : Controller
    {
        private readonly IMissionSkillService _missionSkillService;

        public MissionSkillController(IMissionSkillService missionSkillService)
        {
            _missionSkillService = missionSkillService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddMissionSkill(MissionSkill mSkill)
        {
            await _missionSkillService.InsertMissionSkill(mSkill);
            return Ok("Skill created !");
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            return Ok(_missionSkillService.GetAll());
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int id)
        {
            var res = _missionSkillService.GetMissionSkillDetailsById(id);

            if (res != null) { return Ok(res); }

            return NotFound("Skill not found!");
        }

        // To Update Book
        // To Delete Book
    }
}
