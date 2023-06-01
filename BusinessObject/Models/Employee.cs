using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public enum Status { 
        Active, Inactive
    }

    public class Employee
    {
        public Employee()
        {
            this.ParticipatingProjects = new HashSet<ParticipatingProject>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set;}

        public virtual ICollection<ParticipatingProject> ParticipatingProjects { get; set; }
    }
}
