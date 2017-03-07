using eTeamProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeamProjectManagement.Models.ProjectViewModels
{
    public class IndividualITUpdateViewModel
    {
        public ProjectITUpdate teamITUpdates { get; set; }
        public IEnumerable<ProjectUpdatePartys> updatePartys { get; set; }
        public IEnumerable<ProjectUpdateTypes> updateTypes { get; set; }
    }
}
