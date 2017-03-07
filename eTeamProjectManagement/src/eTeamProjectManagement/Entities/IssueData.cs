using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeamProjectManagement.Entities
{

    public class IssueData
    {
        public int Id { get; set; }
        public IssueTypes IssueType { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime DateLogged { get; set; }
        public DateTime DateResolved { get; set; }
        public string LoggedBy { get; set; }
        public bool IsActive { get; set; }

    }
}
