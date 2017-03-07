using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeamProjectManagement.Entities
{
    public class IssueUpdate
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public int IssueUpdateId { get; set; }
        public string Description { get; set; }
        public string UpdateType { get; set; }
        public DateTime InitialLogged { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string InitialLoggedBy { get; set; }
        public string ModifiedBy { get; set; }

    }
}
