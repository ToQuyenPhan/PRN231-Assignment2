using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject.Models;
using System.Net.Http;
using ProjectParticipantManagementSystemWebClient.ViewModels;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace ProjectParticipantManagementSystemWebClient.Pages.AdminPages.CompanyProjects
{
    public class EditModel : PageModel
    {
        private HttpClient client = null;
        private string CompanyProjectApiUrl = "";

        public EditModel()
        {
        }

        [BindProperty]
        public CompanyProjectViewModel CompanyProject { get; set; }

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
            var companyProject = JsonSerializer.Deserialize<CompanyProject>(strData, options);
            var companyProjectViewModel = new CompanyProjectViewModel
            {
                CompanyProjectID = companyProject.CompanyProjectID,
                ProjectName = companyProject.ProjectName,
                ProjectDescription = companyProject.ProjectDescription,
                EstimatedStartDate = companyProject.EstimatedStartDate,
                ExpectedEndDate = companyProject.ExpectedEndDate
            };
            CompanyProject = companyProjectViewModel;
            if (CompanyProject == null)
            {
                return NotFound();
            }
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
            try
            {
                client = new HttpClient();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                CompanyProjectApiUrl = "https://localhost:44351/odata/CompanyProjects(" + CompanyProject.CompanyProjectID + ")";
                var companyProject = new CompanyProject
                {
                    CompanyProjectID = CompanyProject.CompanyProjectID,
                    ProjectName = CompanyProject.ProjectName,
                    ProjectDescription = CompanyProject.ProjectDescription,
                    EstimatedStartDate = CompanyProject.EstimatedStartDate.ToLocalTime(),
                    ExpectedEndDate = CompanyProject.ExpectedEndDate.ToLocalTime()
                };
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var jsonObject = JsonSerializer.Serialize(companyProject, options);
                HttpContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(CompanyProjectApiUrl, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
