using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProjectParticipantManagementSystemWebClient.Pages.AdminPages.CompanyProjects
{
    public class DeleteModel : PageModel
    {
        private HttpClient client = null;
        private string CompanyProjectApiUrl = "";

        public DeleteModel()
        {
        }

        [BindProperty]
        public CompanyProject CompanyProject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CompanyProjectApiUrl = "https://localhost:44351/odata/CompanyProjects(" + id + ")?$format=application/json;odata.metadata=none";
            HttpResponseMessage response = await client.GetAsync(CompanyProjectApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            CompanyProject = JsonSerializer.Deserialize<CompanyProject>(strData, options);
            if (CompanyProject == null)
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
            CompanyProjectApiUrl = "https://localhost:44351/odata/CompanyProjects(" + id + ")";
            HttpResponseMessage response = await client.DeleteAsync(CompanyProjectApiUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
