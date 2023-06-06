using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject.Models;
using ProjectParticipantManagementSystemWebClient.ViewModels;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace ProjectParticipantManagementSystemWebClient.Pages.AdminPages.CompanyProjects
{
    public class CreateModel : PageModel
    {
        public CreateModel()
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CompanyProjectViewModel CompanyProject { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                HttpClient client = new HttpClient();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string CompanyProjectApiUrl = "https://localhost:44351/odata/CompanyProjects";
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
                HttpResponseMessage response = await client.PostAsync(CompanyProjectApiUrl, content);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
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
