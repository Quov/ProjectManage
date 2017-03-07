using eTeamProjectManagement.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeamProjectManagement.Models.ProjectViewModels
{
    public class SingleProjectViewModel
    {
        public ProjectData ProjectData { get; set; }
        public IEnumerable<ProjectContactData> ProjectContacts { get; set; }
        public IEnumerable<ProjectTeamUpdate> ProjectTeamUpdates { get; set; }
        public IEnumerable<ProjectITUpdate> ProjectITUpdates { get; set; }

        public IEnumerable<ProjectStatuses> AllStatus { get; set; }
        public IEnumerable<ProjectPriorities> AllPriorities { get; set; }
        public IEnumerable<ProjectTypes> AllProjectTypes { get; set; }
        public IEnumerable<ProjectUpdatePartys> AllUpdateParties { get; set; }
        public IEnumerable<ProjectUpdateTypes> AllUpdateTypes { get; set; }
        public IEnumerable<UserTeams> AllTeams { get; set; }
    }
}
