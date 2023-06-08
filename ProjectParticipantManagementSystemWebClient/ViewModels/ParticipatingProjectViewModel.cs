using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectParticipantManagementSystemWebClient.ViewModels
{
    public class ParticipatingProjectViewModel
    {
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Project Role")]
        public int ProjectRole { get; set; }

        [Required]
        public int CompanyProjectID { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public int EmployeeID { get; set; }
    }
}
