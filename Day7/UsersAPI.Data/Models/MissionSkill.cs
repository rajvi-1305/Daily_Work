using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAPI.Data.Models
{
    public class MissionSkill
    {
        public int Id { get; set; }
        public string MissionName { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
