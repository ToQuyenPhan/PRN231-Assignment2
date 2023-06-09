using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using BusinessObject;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProjectParticipantManagementSystemWebClient.Utils;

namespace ProjectParticipantManagementSystemWebClient.Pages.AdminPages.Employees
{
    [Authorize(Roles = nameof(Role.Admin))]
    public class IndexModel : PageModel
    {
        private HttpClient client = null;
        private string EmployeeApiUrl = "";

        public IndexModel()
        {
        }

        public IList<Employee> Employees { get;set; }

        [BindProperty]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            EmployeeApiUrl = "https://localhost:44351/odata/Employees?$expand=Department&$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(EmployeeApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var list = JsonSerializer.Deserialize<Odata<Employee>>(strData, options);
            Employees = list.Value;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            EmployeeApiUrl = "https://localhost:44351/odata/Employees?$expand=Department&$filter=contains(FullName,'" + SearchString + "')"
                + "&$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(EmployeeApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var list = JsonSerializer.Deserialize<Odata<Employee>>(strData, options);
            Employees = list.Value;
            return Page();
        }
    }
}
