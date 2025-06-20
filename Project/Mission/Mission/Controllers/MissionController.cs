using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Entities.Models;
using Mission.Services.IServices;
using Mission.Services.Services;

namespace Mission.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionController(IMissionService missionService) : Controller
    {
        [HttpGet]
        [Route("MissionList")]
        public ResponseResult MissionList()
        {
            return new ResponseResult() { Data = missionService.GetMissionList(), Message = "", Result = ResponseStatus.Success };
        }

        [HttpPost]
        [Route("AddMission")]
        public ActionResult AddMission(AddMissionRequestModel model)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                var data = missionService.AddMission(model);
                result.Data = data;
                result.Message = "Success";
                result.Result = ResponseStatus.Success;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route("GetMissionThemeList")]
        public async Task<IActionResult> GetAllMissionTheme()
        {
            try
            {
                var res = await missionService.GetAllMissionTheme();
                return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
            }
            catch
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to get mission theme" });
            }
        }

        [HttpGet]
        [Route("GetMissionSkillList")]
        public async Task<IActionResult> GetAllMissionSkill()
        {
            try
            {
                var res = await missionService.GetAllMissionSkill();
                return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
            }
            catch
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to get mission Skill" });
            }
        }

        [HttpGet]
        [Route("MissionApplicationList")]
        public IActionResult MissionApplicationList()
        {
            var response = missionService.GetMissionApplicationList();
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        [HttpPost]
        [Route("MissionApplicationApprove")]
        public async Task<IActionResult> MissionApplicationApprove([FromBody] UpdateMissionApplicationModel missionApp)
        {
            try
            {
                var ret = await missionService.MissionApplicationApprove(missionApp);
                return Ok(new ResponseResult() { Data = ret, Message = string.Empty, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult() { Data = null, Message = ex.Message, Result = ResponseStatus.Error });
            }
        }
        [HttpPost]
        [Route("MissionApplicationDelete")]
        public async Task<IActionResult> MissionApplicationDelete([FromBody] UpdateMissionApplicationModel missionApp)
        {
            try
            {
                var ret = await missionService.MissionApplicationDelete(missionApp);
                return Ok(new ResponseResult() { Data = ret, Message = string.Empty, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult() { Data = null, Message = ex.Message, Result = ResponseStatus.Error });
            }
        }

        //[HttpGet]
        //[Route("MissionDetailById/{id:int}")]
        //public async Task<IActionResult> GetMissionById(int id)
        //{
        //    var response = await missionService.GetMissionById(id);
        //    return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        //}
        //[Route("UpdateMission")]
        //[Route("DeleteMission")]
    }
}
