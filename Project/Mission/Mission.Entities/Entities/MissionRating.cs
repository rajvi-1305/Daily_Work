using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.Entities
{
    public class MissionRating
    {
        public int UserId { get; set; }
        public int MissionId { get; set; }
        public int Rating { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(MissionId))]
        public virtual Missions Mission { get; set; }
    }

}
