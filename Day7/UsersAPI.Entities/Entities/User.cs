using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UsersAPI.Entities.Entities;

namespace UsersAPI.Entity.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public virtual ICollection<MissionSkillDetails> MissionSkillDetails { get; set; } = [];
    }
}
