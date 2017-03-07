using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using eTeamProjectManagement.Models;
using eTeamProjectManagement.Entities;

namespace eTeamProjectManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<ProjectData> ProjectData { get; set; }
        public DbSet<ProjectTeamUpdate> ProjectTeamUpdates { get; set; }
        public DbSet<ProjectITUpdate> ProjectITUpdates { get; set; }

        public DbSet<ProjectStatuses> ProjectStatuses { get; set; }
        public DbSet<ProjectPriorities> ProjectPriorities { get; set; }
        public DbSet<ProjectTypes> ProjectTypes { get; set; }
        public DbSet<UserTeams> UserTeams { get; set; }

        public DbSet<ProjectUpdatePartys> ProjectUpdatePartys { get; set; }
        public DbSet<ProjectUpdateTypes> ProjectUpdateTypes { get; set; }

        public DbSet<IssueData> IssueData { get; set; }
        public DbSet<IssueUpdate> IssueUpdates { get; set; }
        public DbSet<ProjectContactData> ProjectContactData { get; set; }
    }
}
