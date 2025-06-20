using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.Models.CommonModels
{
    public class AddUserSkillRequestModel
    {
        public string Skill { get; set; }

        public int UserId { get; set; }
    }
}
