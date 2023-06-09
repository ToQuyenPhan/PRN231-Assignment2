using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using ProjectParticipantManagementSystemWebClient.Utils;

namespace ProjectParticipantManagementSystemWebClient.Pages.AdminPages.ParticipatingProjects
{
    [Authorize(Roles = nameof(Role.Admin))]
    public class IndexModel : PageModel
    {
        private HttpClient client= new HttpClient();
        private string CompanyProjectApiUrl = "";
        public IndexModel()
        {
        }

        public IList<ParticipatingProject> ParticipatingProjects { get;set; }
        public IList<ParticipatingProject> OldParticipatingProjects { get; set; }

        [BindProperty]
        public string SearchString { get; set; }

        [BindProperty]
        public int? CompanyProjectId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            CompanyProjectId = id;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CompanyProjectApiUrl = "https://localhost:44351/odata/CompanyProjects(" + id
                + ")?$expand=ParticipatingProjects&$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(CompanyProjectApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var companyProject = JsonSerializer.Deserialize<CompanyProject>(strData, options);
            ParticipatingProjects = companyProject.ParticipatingProjects.ToList();
            foreach (var item in ParticipatingProjects)
            {
                string EmployeeApiUrl = "https://localhost:44351/odata/Employees(" + item.EmployeeID + ")?$format=application/json;odata.metadata=none";
                response = await client.GetAsync(EmployeeApiUrl);
                strData = await response.Content.ReadAsStringAsync();
                var employee = JsonSerializer.Deserialize<Employee>(strData, options);
                item.Employee = employee;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CompanyProjectApiUrl = "https://localhost:44351/odata/CompanyProjects(" + CompanyProjectId
                + ")?$expand=ParticipatingProjects&$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(CompanyProjectApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var companyProject = JsonSerializer.Deserialize<CompanyProject>(strData, options);
            ParticipatingProjects = companyProject.ParticipatingProjects.ToList();
            foreach (var item in ParticipatingProjects)
            {
                string EmployeeApiUrl = "https://localhost:44351/odata/Employees(" + item.EmployeeID + ")?$format=application/json;odata.metadata=none";
                response = await client.GetAsync(EmployeeApiUrl);
                strData = await response.Content.ReadAsStringAsync();
                var employee = JsonSerializer.Deserialize<Employee>(strData, options);
                item.Employee = employee;
            }
            if (SearchString != null)
            {
                var list = new List<ParticipatingProject>();
                foreach (var item in ParticipatingProjects)
                {
                    if (item.Employee.FullName.Contains(SearchString))
                    {
                        list.Add(item);
                    }
                }
                if (list.Count > 0)
                {
                    ParticipatingProjects = list;
                }
                else
                {
                    ParticipatingProjects = new List<ParticipatingProject>();
                }
            }
            return Page();
        }
    }
}
