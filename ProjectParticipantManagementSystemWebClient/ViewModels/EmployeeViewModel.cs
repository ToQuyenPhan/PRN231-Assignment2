using BusinessObject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectParticipantManagementSystemWebClient.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Skills { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}
