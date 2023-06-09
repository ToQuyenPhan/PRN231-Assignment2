using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using ProjectParticipantManagementSystemWebClient.Utils;

namespace ProjectParticipantManagementSystemWebClient.Pages.CustomerPages
{
    [Authorize(Roles = nameof(Role.Customer))]
    public class ParticipatingProjectsModel : PageModel
    {
        public ParticipatingProjectsModel() { }
        public IList<ParticipatingProject> ParticipatingProjects { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            HttpClient client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            string EmployeeApiUrl = "https://localhost:44351/odata/Employees(" + id 
                + ")?$expand=ParticipatingProjects&$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(EmployeeApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var employee = JsonSerializer.Deserialize<Employee>(strData, options);
            ParticipatingProjects = employee.ParticipatingProjects.ToList();
            foreach (var item in ParticipatingProjects)
            {
                string CompanyProjectApiUrl = "https://localhost:44351/odata/CompanyProjects(" + item.CompanyProjectID + ")?$format=application/json;odata.metadata=none";
                response = await client.GetAsync(CompanyProjectApiUrl);
                strData = await response.Content.ReadAsStringAsync();
                var companyProject = JsonSerializer.Deserialize<CompanyProject>(strData, options);
                item.CompanyProject = companyProject;
            }
            return Page();
        }
    }
}
