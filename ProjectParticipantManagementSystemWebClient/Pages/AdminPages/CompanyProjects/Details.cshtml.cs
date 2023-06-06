using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Context;
using BusinessObject.Models;

namespace ProjectParticipantManagementSystemWebClient.Pages.AdminPages.CompanyProjects
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessObject.Context.ProjectParticipatingDbContext _context;

        public DetailsModel(BusinessObject.Context.ProjectParticipatingDbContext context)
        {
            _context = context;
        }

        public CompanyProject CompanyProject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyProject = await _context.CompanyProjects.FirstOrDefaultAsync(m => m.CompanyProjectID == id);

            if (CompanyProject == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
