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
    [Index(nameof(EmployeeID), nameof(CompanyProjectID))]
    public class ParticipatingProject
    {
        public ParticipatingProject() {
        }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int ProjectRole { get; set; }

        [Key]
        [Required]
        public int CompanyProjectID { get; set; }

        [ForeignKey("CompanyProjectID")]
        public virtual CompanyProject CompanyProject { get; set; }

        [Key]
        [Required]
        public int EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
    }
}
