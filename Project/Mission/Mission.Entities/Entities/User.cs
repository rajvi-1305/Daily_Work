using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mission.Entities.Entities;
using System.Collections;

namespace Mission.Entities
{
    [Table("User")] // Specify the table name
    public class User : BaseEntity // Assuming BaseEntity defines common properties
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("email_address")]
        public string EmailAddress { get; set; }

        [Column("user_type")]
        public string UserType { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("user_image")]
        public string UserImage { get; set; } = string.Empty;

        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;
        public virtual UserDetail UserDetail { get; set; }
        public virtual ICollection<MissionApplication> MissionApplications{get; set; } = [];
        public virtual ICollection<MissionComment> MissionComments { get; set; }=[];
        public virtual ICollection<MissionFavourites> MissionFavourites { get; set; } = [];
        public virtual ICollection<MissionRating> MissionRatings { get; set; } = [];
        public virtual ICollection<Story> Stories { get; set; } = [];
        public virtual ICollection<VolunteeringHours> VolunteeringHours {get; set;}= [];
        public virtual ICollection<VolunteeringGoals> VolunteeringGoals {get; set;}= []; 
    }
}
