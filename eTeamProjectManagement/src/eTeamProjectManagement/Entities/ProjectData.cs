using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTeamProjectManagement.Entities
{

    public class ProjectData
    {
        public int Id { get; set; }
        [Required, MaxLength(6)]
        [Display(Name = "Client Number")]
        public string ClientNumber { get; set; }
        [Required, MaxLength(6)]
        [Display(Name = "Bill To Client Number")]
        public string BillToClientNumber { get; set; }
        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        public string Cst { get; set; }
        [Required]
        [Display(Name = "Project Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }
        [Required]
        [Display(Name = "Project Type")]
        public int ProjectTypeId { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Project Owner")]
        public string ProjectOwner { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        [Required]
        [Display(Name = "Assigned Team")]
        public int AssignedTeam { get; set; }
        [Required]
        public bool isActive { get; set; }  
    }
}
