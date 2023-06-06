using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject.Models;
using System.Net.Http;
using BusinessObject;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ProjectParticipantManagementSystemWebClient.Pages.AdminPages.CompanyProjects
{
    public class IndexModel : PageModel
    {
        private HttpClient client = null;
        private string CompanyProjectApiUrl = "";

        public IndexModel()
        {
        }

        public IList<CompanyProject> CompanyProjects { get;set; }

        [BindProperty]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CompanyProjectApiUrl = "https://localhost:44351/odata/CompanyProjects?$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(CompanyProjectApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var list = JsonSerializer.Deserialize<Odata<CompanyProject>>(strData, options);
            CompanyProjects = list.Value;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CompanyProjectApiUrl = "https://localhost:44351/odata/CompanyProjects?$filter=contains(ProjectName,'" + SearchString + "')"
                + "&$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(CompanyProjectApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var list = JsonSerializer.Deserialize<Odata<CompanyProject>>(strData, options);
            CompanyProjects = list.Value;
            return Page();
        }
    }
}
