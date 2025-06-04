using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Entities.Entities;
using UsersAPI.Entity.Models;

namespace UsersAPI.Entities.Context
{
    public class MissionSkillDbContext(DbContextOptions<MissionSkillDbContext> options) : DbContext(options)
    {
        public DbSet<MissionSkillDetails> MissionSkillDetails { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Name = "admin",
                Email = "admin@tatvasoft.com",
                Role = "Admin",
                Password = "admin"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
