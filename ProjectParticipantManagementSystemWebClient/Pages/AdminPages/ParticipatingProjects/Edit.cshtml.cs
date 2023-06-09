using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using System.Net.Http;
using ProjectParticipantManagementSystemWebClient.ViewModels;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using ProjectParticipantManagementSystemWebClient.Utils;

namespace ProjectParticipantManagementSystemWebClient.Pages.AdminPages.ParticipatingProjects
{
    [Authorize(Roles = nameof(Role.Admin))]
    public class EditModel : PageModel
    {
        private HttpClient client = null;
        private string ParticipatingProjectApiUrl = "";

        public EditModel()
        {
        }

        [BindProperty]
        public ParticipatingProjectViewModel ParticipatingProject { get; set; }

        [ViewData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ParticipatingProjectApiUrl = "https://localhost:44351/odata/ParticipatingProjects?employeeId=" + id 
                + "&companyProjectId=" + id2 + "&$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(ParticipatingProjectApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var participatingProject = JsonSerializer.Deserialize<ParticipatingProject>(strData, options);
            var participatingProjectViewModel = new ParticipatingProjectViewModel
            {
                CompanyProjectID = participatingProject.CompanyProjectID,
                EmployeeID = participatingProject.EmployeeID,
                StartDate = participatingProject.StartDate,
                EndDate = participatingProject.EndDate,
                ProjectRole = participatingProject.ProjectRole
            };
            ParticipatingProject = participatingProjectViewModel;
            if (ParticipatingProject == null)
            {
                return NotFound();
            }
            List<SelectListItem> roleList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Project Manager" },
                new SelectListItem { Value = "2", Text = "Project Member" }
            };
            ViewData["ProjectRole"] = new SelectList(roleList, "Value", "Text");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(ParticipatingProject.EndDate.CompareTo(ParticipatingProject.StartDate) < 0)
            {
                Message = "The end date cannot be earlier than start date!";
                List<SelectListItem> roleList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "1", Text = "Project Manager" },
                    new SelectListItem { Value = "2", Text = "Project Member" }
                };
                ViewData["ProjectRole"] = new SelectList(roleList, "Value", "Text");
                return Page();
            }
            try
            {
                client = new HttpClient();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                ParticipatingProjectApiUrl = "https://localhost:44351/odata/ParticipatingProjects";
                var participatingProject = new ParticipatingProject
                {
                    CompanyProjectID = ParticipatingProject.CompanyProjectID,
                    EmployeeID = ParticipatingProject.EmployeeID,
                    StartDate = ParticipatingProject.StartDate.ToLocalTime(),
                    EndDate = ParticipatingProject.EndDate.ToLocalTime(),
                    ProjectRole = ParticipatingProject.ProjectRole
                };
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var jsonObject = JsonSerializer.Serialize(participatingProject, options);
                HttpContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PatchAsync(ParticipatingProjectApiUrl, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToPage("./Index", new { Id = ParticipatingProject.CompanyProjectID });
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Page();
            }
        }
    }
}
