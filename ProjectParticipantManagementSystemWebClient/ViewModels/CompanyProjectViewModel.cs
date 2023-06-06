using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectParticipantManagementSystemWebClient.ViewModels
{
    public class CompanyProjectViewModel
    {
        public int CompanyProjectID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Project Discription")]
        public string ProjectDescription { get; set; }

        [Required]
        [Display(Name = "Estimated Start Date")]
        public DateTime EstimatedStartDate { get; set; }

        [Required]
        [Display(Name = "Expected End Date")]
        public DateTime ExpectedEndDate { get; set; }
    }
}
