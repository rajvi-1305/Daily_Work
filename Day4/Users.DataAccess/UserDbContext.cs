using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
