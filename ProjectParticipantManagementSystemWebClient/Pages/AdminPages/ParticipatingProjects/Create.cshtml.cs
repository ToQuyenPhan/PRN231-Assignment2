using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using ProjectParticipantManagementSystemWebClient.ViewModels;
using BusinessObject;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using ProjectParticipantManagementSystemWebClient.Utils;

namespace ProjectParticipantManagementSystemWebClient.Pages.AdminPages.ParticipatingProjects
{
    [Authorize(Roles = nameof(Role.Admin))]
    public class CreateModel : PageModel
    {
        private HttpClient client = null;
        private string ParticipatingProjectApiUrl = "";
        private readonly BusinessObject.Context.ProjectParticipatingDbContext _context;

        public CreateModel(BusinessObject.Context.ProjectParticipatingDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            CompanyProjectId = id;
            var list = GetEmployees().Result;
            List<SelectListItem> roleList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "1", Text = "Project Manager" },
                    new SelectListItem { Value = "2", Text = "Project Member" }
                };
            ViewData["ProjectRole"] = new SelectList(roleList, "Value", "Text");
            ViewData["EmployeeID"] = new SelectList(list, "EmployeeID", "FullName");
            return Page();
        }

        [BindProperty]
        public ParticipatingProjectViewModel ParticipatingProject { get; set; }

        [ViewData]
        public string Message { get; set; }

        [BindProperty]
        public int? CompanyProjectId { get; set; }

        [BindProperty]
        public int? EmployeeId { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var id = CompanyProjectId;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (ParticipatingProject.EndDate.CompareTo(ParticipatingProject.StartDate) <= 0)
            {
                Message = "The end date must be later than start date!";
            }
            else if (EmployeeExist(ParticipatingProject.EmployeeID, (int)CompanyProjectId).Result == true)
            {
                Message = "This employee is already exist!";
            }
            else
            {
                try
                {
                    client = new HttpClient();
                    var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    ParticipatingProjectApiUrl = "https://localhost:44351/odata/ParticipatingProjects";
                    var participatingProject = new ParticipatingProject
                    {
                        CompanyProjectID = (int)CompanyProjectId,
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
                    HttpResponseMessage response = await client.PostAsync(ParticipatingProjectApiUrl, content);
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        Message = "Create successfully!";
                        return RedirectToPage("./Index", new { Id = id });
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }           
            var list = GetEmployees().Result;
            List<SelectListItem> roleList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "1", Text = "Project Manager" },
                    new SelectListItem { Value = "2", Text = "Project Member" }
                };
            ViewData["ProjectRole"] = new SelectList(roleList, "Value", "Text");
            ViewData["EmployeeID"] = new SelectList(list, "EmployeeID", "FullName");
            CompanyProjectId = id;
            return Page();
        }

        private async Task<IList<Employee>> GetEmployees()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            string EmployeeApiUrl = "https://localhost:44351/odata/Employees?$expand=Department&$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(EmployeeApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var list = JsonSerializer.Deserialize<Odata<Employee>>(strData, options);
            return list.Value;
        }

        private async Task<bool> EmployeeExist(int employeeId, int companyProjectId)
        {
            bool check = false;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ParticipatingProjectApiUrl = "https://localhost:44351/odata/ParticipatingProjects?$expand=Employee&employeeId=" + employeeId
                + "&companyProjectId=" + companyProjectId + "&$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(ParticipatingProjectApiUrl);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                check = true;
            }
            return check;
        }
    }
}
