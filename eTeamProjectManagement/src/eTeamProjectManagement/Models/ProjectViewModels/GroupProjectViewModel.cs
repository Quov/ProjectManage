using eTeamProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeamProjectManagement.Models.ProjectViewModels
{
    public class GroupProjectViewModel
    {
        public IEnumerable<ProjectData> Projects { get; set; }
        public IEnumerable<ProjectTypes> ProjectTypes { get; set; }
        public IEnumerable<UserTeams> AllTeams { get; set; }
    }
}
