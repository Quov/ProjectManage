using eTeamProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeamProjectManagement.Models.ProjectViewModels
{
    public class ProjectContactViewModel
    {      
        public int CurrentRun { get; set; }
        public ProjectContactData Contact { get; set; }
    }
}
