using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Context;
using BusinessObject.Models;

namespace ProjectParticipantManagementSystemWebClient.Pages.AdminPages.ParticipatingProjects
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessObject.Context.ProjectParticipatingDbContext _context;

        public DetailsModel(BusinessObject.Context.ProjectParticipatingDbContext context)
        {
            _context = context;
        }

        public ParticipatingProject ParticipatingProject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParticipatingProject = await _context.ParticipatingProjects
                .Include(p => p.CompanyProject)
                .Include(p => p.Employee).FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (ParticipatingProject == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
