using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTeamProjectManagement.Entities
{

    public class ProjectTeamUpdate
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ProjectUpdateId { get; set; }
        public DateTime InitialUpdate { get; set; }
        public DateTime LastModified { get; set; }
        public string Description { get; set; }
        public int UpdateFromId { get; set; }
        public int UpdateTypeId { get; set; }
        public string UpdatedBy { get; set; }
    }
}
