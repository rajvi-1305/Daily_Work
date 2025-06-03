using Microsoft.EntityFrameworkCore;
using Users.DataAccess.Models;

namespace Users.DataAccess
{
    public class UserDbContext: DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options): base(options) 
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<MissionSkiil> MissionSkiils { get; set; }
    }
}
