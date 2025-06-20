using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Entities.Entities;
using Mission.Entities.Models.CommonModels;
using Mission.Services;
using Mission.Services.IServices;

namespace Mission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController(ICommonService commonService, IWebHostEnvironment hostingEnvironment) : ControllerBase
    {
        private readonly ICommonService _commonService = commonService;
        private readonly IWebHostEnvironment _hostingEnvironment = hostingEnvironment;
        ResponseResult result = new ResponseResult();

        //[HttpPost]
        //[Route("ContactUs")]



        [HttpGet]
        [Route("CountryList")]
        [Authorize]
        public ResponseResult CountryList()
        {
            try
            {
                result.Data = _commonService.CountryList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("CityList/{countryId}")]
        [Authorize]
        public ResponseResult CityList(int countryId)
        {
            try
            {
                result.Data = _commonService.CityList(countryId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("MissionCountryList")]
        public ResponseResult MissionCountryList()
        {
            try
            {
                result.Data = _commonService.MissionCountryList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("MissionCityList")]
        public ResponseResult MissionCityList()
        {
            try
            {
                result.Data = _commonService.MissionCityList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("MissionThemeList")]
        public ResponseResult MissionThemeList()
        {
            try
            {
                result.Data = _commonService.MissionThemeList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("MissionSkillList")]
        public ResponseResult MissionSkillList()
        {
            try
            {
                result.Data = _commonService.MissionSkillList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("MissionTitleList")]
        public ResponseResult MissionTitleList()
        {
            try
            {
                result.Data = _commonService.MissionTitleList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> UploadImage()
        {
            var fileList = new List<string>();
            try
            {
                var files = Request.Form.Files;

                if (files == null || files.Count == 0)
                {
                    return BadRequest(new { success = false, message = "No files received" });
                }

                foreach (var file in files)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    var extension = Path.GetExtension(file.FileName);
                    var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    var newFileName = $"{fileName}_{timestamp}{extension}";

                    string relativePath = Path.Combine("UploadedImage", "Mission", newFileName);
                    string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadMissionImage", "Mission");

                    // Log paths to console
                    Console.WriteLine("Saving to: " + rootPath);
                    Console.WriteLine("Relative Path: " + relativePath);

                    if (!Directory.Exists(rootPath))
                    {
                        Directory.CreateDirectory(rootPath);
                    }

                    var fullPath = Path.Combine(rootPath, newFileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    fileList.Add(relativePath.Replace("\\", "/")); // Ensure URL compatibility
                }

                return Ok(new { success = true, data = fileList });
            }
            catch (Exception ex)
            {
                Console.WriteLine("UPLOAD ERROR: " + ex.Message); // log error
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetUserSkill/{userId}")]
        public ResponseResult GetUserSkill(int userId)
        {
            try
            {
                result.Data = _commonService.GetUserSkill(userId);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("AddUserSkill")]
        public async Task<ResponseResult> AddUserSkill(UserSkills skills)
        {
            try
            {
                result.Data = await _commonService.AddUserSkill(skills);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        //[HttpPost]
        //[Route("UploadImage")]
        //public async Task<ResponseResult> UploadImage([FromForm] List<IFormFile> files)
        //{
        //    List<string> fileList = new List<string>();
        //    try
        //    {
        //        if (files != null && files.Count > 0)
        //        {
        //            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages", "MissionImages");

        //            if (!Directory.Exists(uploadFolder))
        //                Directory.CreateDirectory(uploadFolder);

        //            foreach (IFormFile file in files)
        //            {
        //                if (file.Length > 0)
        //                {
        //                    var name = Path.GetFileNameWithoutExtension(file.FileName);
        //                    var ext = Path.GetExtension(file.FileName);
        //                    var unique = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ext;

        //                    var filePath = Path.Combine(uploadFolder, unique);

        //                    using (var stream = new FileStream(filePath, FileMode.Create))
        //                    {
        //                        await file.CopyToAsync(stream);
        //                    }

        //                    var fPath = Path.Combine("UploadedImages", "MissionImages", unique);
        //                    fileList.Add(fPath);
        //                }
        //            }

        //            return new ResponseResult()
        //            {
        //                Data = fileList,
        //                Message = "Success",
        //                Result = ResponseStatus.Success
        //            };
        //        }
        //        else
        //        {
        //            return new ResponseResult()
        //            {
        //                Data = null,
        //                Message = "No files received.",
        //                Result = ResponseStatus.Error
        //            };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("UPLOAD ERROR: " + ex.Message);
        //        return new ResponseResult()
        //        {
        //            Data = null,
        //            Message = "Upload failed. Error: " + ex.Message,
        //            Result = ResponseStatus.Error
        //        };
        //    }
        //}

    }
}
