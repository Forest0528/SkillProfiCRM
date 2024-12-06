using Microsoft.EntityFrameworkCore;
using SkillProfiCRM.Models;

namespace SkillProfiCRM.Data
{
    public class SkillProfiContext : DbContext
    {
        public SkillProfiContext(DbContextOptions<SkillProfiContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<HomePageBlock> HomePageBlocks { get; set; }
        public DbSet<MenuButton> MenuButtons { get; set; }
    }
}
