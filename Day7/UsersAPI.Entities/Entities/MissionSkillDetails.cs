using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Entity.Models;

namespace UsersAPI.Entities.Entities
{
    public class MissionSkillDetails
    {
        [Key]
        public int Id { get; set; }
        public string MissionName { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
