using eTeamProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeamProjectManagement.Models.ProjectViewModels
{
    public class EditProjectViewModel
    {
        public int Id { get; set; }
        public string ClientNumber { get; set; }
        public string BillToClientNumber { get; set; }
        public string ClientName { get; set; }
        public string Cst { get; set; }
        public DateTime BeginDate { get; set; }
        public int ProjectType { get; set; }
        public string Description { get; set; }
        public string ProjectOwner { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public int AssignedTeam { get; set; }

        public IEnumerable<ProjectStatuses> AllStatus { get; set; }
        public IEnumerable<ProjectPriorities> AllPriorities { get; set; }
        public IEnumerable<ProjectTypes> AllProjectTypes { get; set; }
        public IEnumerable<UserTeams> AllTeams { get; set; }
    }
}
