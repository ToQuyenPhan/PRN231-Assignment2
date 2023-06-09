using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessObject.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using ProjectParticipantManagementSystemWebClient.Utils;

namespace ProjectParticipantManagementSystemWebClient.Pages.CustomerPages
{
    [Authorize(Roles = nameof(Role.Customer))]
    public class ProfileModel : PageModel
    {
        public ProfileModel() { }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HttpClient client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            string EmployeeApiUrl = "https://localhost:44351/odata/Employees(" + id
                + ")?$expand=Department&$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(EmployeeApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            Employee = JsonSerializer.Deserialize<Employee>(strData, options);
            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
