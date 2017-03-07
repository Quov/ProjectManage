using eTeamProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeamProjectManagement.Models.ProjectViewModels
{
    public class OverviewUpdateViewModel
    {
        public ProjectTeamUpdate teamUpdate { get; set; }
        public ProjectITUpdate ITUpdate { get; set; }
    }
}
