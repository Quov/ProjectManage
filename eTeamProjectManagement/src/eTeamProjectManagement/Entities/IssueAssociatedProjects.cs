using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeamProjectManagement.Entities
{
    public class IssueAssociatedProjects
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public int ProjectId { get; set; }
    }
}
