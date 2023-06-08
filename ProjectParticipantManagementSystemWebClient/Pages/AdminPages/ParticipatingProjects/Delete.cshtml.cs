using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ProjectParticipantManagementSystemWebClient.Pages.AdminPages.ParticipatingProjects
{
    public class DeleteModel : PageModel
    {
        private HttpClient client = null;
        private string ParticipatingProjectApiUrl = "";

        public DeleteModel()
        {
        }

        [BindProperty]
        public ParticipatingProject ParticipatingProject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? id2)
        {
            if (id == null)
            {
                return NotFound();
            }
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ParticipatingProjectApiUrl = "https://localhost:44351/odata/ParticipatingProjects?$expand=Employee&employeeId=" + id
                + "&companyProjectId=" + id2 + "&$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(ParticipatingProjectApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            ParticipatingProject = JsonSerializer.Deserialize<ParticipatingProject>(strData, options);
            if (ParticipatingProject == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ParticipatingProjectApiUrl = 
                "https://localhost:44351/odata/ParticipatingProjects/DeleteParticipatingProject?employeeId=" 
                + ParticipatingProject.EmployeeID + "&companyProjectId=" + ParticipatingProject.CompanyProjectID;
            HttpResponseMessage response = await client.DeleteAsync(ParticipatingProjectApiUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToPage("./Index", new { Id = ParticipatingProject.CompanyProjectID });
            }
            else
            {
                return Page();
            }
        }
    }
}
