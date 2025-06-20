using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.Entities
{
    public class MissionComment
    {
        [Key]
        public int Id { get; set; }

        public int MissionId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(MissionId))]
        public virtual Missions Mission { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }

}
