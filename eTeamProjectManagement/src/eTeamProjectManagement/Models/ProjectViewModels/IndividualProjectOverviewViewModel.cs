using eTeamProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeamProjectManagement.Models.ProjectViewModels
{
    public class IndividualProjectOverviewViewModel
    {
        public ProjectData Project { get; set; }
        public IEnumerable<ProjectTypes> ProjectTypes { get; set; }
        public IEnumerable<UserTeams> AllTeams { get; set; }

        public IEnumerable<ProjectTeamUpdate> TeamUpdates { get; set; }
        public IEnumerable<ProjectITUpdate> ITUpdates { get; set; }
    }
}
