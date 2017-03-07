using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeamProjectManagement.Entities
{
    public class ProjectContactData
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ProjectContactId { get; set; }
        public string ContactRole { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ContactTimeZone { get; set; }
        public string ContactNote { get; set; }
    }
}
